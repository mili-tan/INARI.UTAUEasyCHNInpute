using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Microsoft.International.Converters.PinYinConverter;
using System.Drawing;
using UTAUEasyChnInput.Helper;
using System.Runtime.InteropServices;

namespace UTAUEasyChnInput
{
    public partial class Form1 : Form
    {
        public int StartPoint = 0;
        public int PointCount = 0;
        public IniData UstData;
        public string savePath;
        private readonly Encoding EncodeJPN = Encoding.GetEncoding("Shift_JIS");
        private readonly string UstHeader = "[#VERSION]\r\n" + "UST Version 1.20\r\n";

        private enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        private enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        public Form1(string ustPath)
        {
            InitializeComponent();
            savePath = ustPath;

            try
            {
                string ustFileStr = File.ReadAllText(ustPath, EncodeJPN)
                    .Replace(UstHeader, "")
                    .Replace("､｢", "あ");

                UstData = new FileIniDataParser().Parser.Parse(ustFileStr);

                UstData.Sections.RemoveSection("#PREV");
                UstData.Sections.RemoveSection("#NEXT");

                StartPoint = Convert.ToInt32(UstData.Sections.ElementAt(1).SectionName.Replace("#", ""));
                PointCount = UstData.Sections.Count -1;

                textBoxCount.Text = " 音符数：" + PointCount+" ";

                List<string> lyricWordList = new List<string>();
                for (int i = 0; i < PointCount; i++)
                {
                    int pointNum = i + StartPoint;
                    
                    lyricWordList.Add(UstData["#" + pointNum.ToString("0000")]["Lyric"]);
                }
                listBoxWord.Items.AddRange(lyricWordList.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            var accentPolicy = new AccentPolicy
            {
                AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND
            };
            var accentStructSize = Marshal.SizeOf(accentPolicy);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accentPolicy, accentPtr, false);

            var dataWindows = new WindowCompositionAttributeData
            {
                Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(Handle, ref dataWindows);
            Marshal.FreeHGlobal(accentPtr);

            if (Environment.OSVersion.Version.Major < 10)
            {
                TransparencyKey = Color.Olive;
            }else
            {
                TransparencyKey = Color.WhiteSmoke;
            }
            
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxLyrics.Text))
            {
                listBoxWord.Items.Clear();
                textBoxLyrics.Text = RemoveFormat(textBoxLyrics.Text);

                if (checkBoxDisV.Checked)
                {
                    listBoxWord.Items.Clear();
                    listBoxWord.Items.AddRange(ToPinyinDisV(textBoxLyrics.Text));
                }
                else
                {
                    foreach (char itemWords in textBoxLyrics.Text.Replace("\n", "").Replace("\r", "").Replace(" ", ""))
                    {
                        if (nPinyinRBox.Checked)
                        {
                            listBoxWord.Items.Add(ToPinyin.ByNPingyin(itemWords));
                        }
                        else
                        {
                            listBoxWord.Items.Add(ToPinyin.ByMSIntPinyin(itemWords));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("歌词不能为空。");
            }

        }

        private void ListBoxWord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxLyrics.Text))
            {
                var myLyricsChars = textBoxLyrics.Text.Replace("\n", "").Replace("\r", "").Replace(" ", "").ToCharArray();
                string myLyricsWordStr = myLyricsChars[listBoxWord.SelectedIndex].ToString();

                textBoxTone.Enabled = true;

                if (new ChineseChar(Convert.ToChar(myLyricsWordStr)).IsPolyphone)
                {
                    listBoxTone.Enabled = true;

                    var pinyinListR = new ChineseChar(Convert.ToChar(myLyricsWordStr)).Pinyins;
                    var pinyinList = new List<string>(pinyinListR);

                    RemoveNullElement(pinyinList);

                    listBoxTone.Items.Clear();
                    listBoxTone.Items.AddRange(pinyinList.ToArray());
                }
                else
                {
                    MessageBox.Show("这不是一个多音字");
                }
            }
        }

        private void ListBoxTone_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBoxWord.Items[listBoxWord.SelectedIndex] = Regex.Replace(listBoxTone.SelectedItem.ToString(), @"\d", "").ToLower();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (listBoxWord.Items.Count != 0 && listBoxWord.Items.Count == PointCount)
            {
                SaveBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("填词音符数不正确。");
            }
        }

        private void SaveBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < PointCount; i++)
                {
                    int pointNum = i + StartPoint;
                    UstData["#" + pointNum.ToString("0000")]["Lyric"] = listBoxWord.Items[i].ToString();
                }

                File.WriteAllText(savePath, UstHeader + UstData.ToString().Replace(" = ", "=").Replace("\r\n\r\n", "\r\n"));
            }

            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }

        }

        private void SaveBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("OK!");
            Close();
        }

        private void TextBoxTone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBoxWord.Items[listBoxWord.SelectedIndex] = textBoxTone.Text;
                textBoxTone.Clear();
            }
        }

        private string[] ToPinyinDisV(string str)
        {
            Entity.PinyinDictionary dict = new Entity.PinyinDictionary();
            List<string> wordList = dict.Dictionary.Keys.ToList<string>();
            List<string> wordsLeft = Segmentation.SegMMDouble(str, ref wordList);

            if (wordsLeft == null)
            {
                MessageBox.Show("意外的错误，分词失败。");
                return null;
            }

            var pinyinList = new List<string>();
            foreach (string word in wordsLeft)
            {
                if (word.Length == 1 && !dict.Dictionary.ContainsKey(word))
                {
                    string pinyin;
                    if (nPinyinRBox.Checked)
                    {
                        pinyin = ToPinyin.ByNPingyin(word.ToCharArray()[0]);
                    }
                    else
                    {
                        pinyin = ToPinyin.ByMSIntPinyin(word.ToCharArray()[0]);
                    }
                    pinyinList.Add(pinyin);
                }
                else
                {
                    pinyinList.AddRange(Regex.Replace(dict.Dictionary[word].ToLower(), @"\d", "").Split(' '));
                }
            }
            return pinyinList.ToArray();
        }

        private static void RemoveNullElement<T>(List<T> list)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
                if (list[i] == null)
                {
                    int newCount = i++;

                    for (; i < count; i++)
                    {
                        if (list[i] != null)
                        {
                            list[newCount++] = list[i];
                        }
                    }
                    list.RemoveRange(newCount, count - newCount);
                    break;
                }
        }

        private string RemoveFormat(string str)
        {
            str = str.Replace(" ", "");
            str = Regex.Replace(str, "\\p{P}", "");
            str = Regex.Replace(str, @"[A-Za-z0-9]", "");
            return str;
        }

        private void TextBoxCount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Width = (int)(Width * 1.2);
            Height = (int)(Height * 1.2);
        }
    }
}
