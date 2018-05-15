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
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace UTAUEasyChnInput
{
    public partial class Form1 : Form
    {
        private int PointCount;
        private int IgnoreRNum;

        public IniData UstData;
        public string SavePath;
        private readonly Encoding EncodeJPN = Encoding.GetEncoding("Shift_JIS");
        private readonly string UstHeader = "[#VERSION]\r\n" + "UST Version 1.20\r\n";

        private enum AccentState
        {
            AccentEnableBlurbehind = 3
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public AccentState AccentState;
            private int AccentFlags;
            private int GradientColor;
            private int AnimationId;
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
            WcaAccentPolicy = 19
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        public Form1(string ustPath)
        {
            InitializeComponent();
            SavePath = ustPath;

            try
            {
                string ustFileStr = File.ReadAllText(ustPath, EncodeJPN)
                    .Replace(UstHeader, "")
                    .Replace("､｢", "あ");

                UstData = new FileIniDataParser().Parser.Parse(ustFileStr);

                UstData.Sections.RemoveSection("#PREV");
                UstData.Sections.RemoveSection("#NEXT");
                UstData.Sections.RemoveSection("#SETTING");

                //int StartPoint = Convert.ToInt32(UstData.Sections.ElementAt(0).SectionName.Replace("#", ""));
                PointCount = UstData.Sections.Count;
                List<string> lyricWordList = new List<string>();

                foreach (var itemSection in UstData.Sections)
                {
                    if (itemSection.Keys["Lyric"] == "R" && File.Exists("ignoreR.enable"))
                    {
                        IgnoreRNum += 1;
                    }
                    else
                    {
                        lyricWordList.Add(itemSection.Keys["Lyric"]);
                    }
                }

                listBoxWord.Items.AddRange(lyricWordList.ToArray());
                textBoxCount.Text = @" 音符数:" + (PointCount - IgnoreRNum);

                if (File.Exists("ignoreR.enable"))
                {
                    textBoxCount.Text += @"|忽视R";
                }
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
                AccentState = AccentState.AccentEnableBlurbehind
            };
            var accentStructSize = Marshal.SizeOf(accentPolicy);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accentPolicy, accentPtr, false);

            var dataWindows = new WindowCompositionAttributeData
            {
                Attribute = WindowCompositionAttribute.WcaAccentPolicy,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(Handle, ref dataWindows);
            Marshal.FreeHGlobal(accentPtr);

            if (Environment.OSVersion.Version.Major < 10 || File.Exists("blur.Disable"))
            {
                TransparencyKey = Color.Olive;
            }else
            {
                TransparencyKey = Color.WhiteSmoke;
            }

            if (File.Exists("auto.Disable"))
            {
                checkBoxDisV.Show();
                nPinyinRBox.Show();
                msIntPinyinRBox.Show();
                checkBoxDisV.Checked = false;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxLyrics.Text))
            {
                listBoxWord.Items.Clear();
                textBoxLyrics.Text = ChineseConverter.Convert(textBoxLyrics.Text, ChineseConversionDirection.TraditionalToSimplified);
                textBoxLyrics.Text = RemoveFormat(textBoxLyrics.Text);
                string[] sentence = textBoxLyrics.Text.Split('|');
                foreach (var itemSen in sentence)
                {
                    if (checkBoxDisV.Checked)
                    {
                        listBoxWord.Items.AddRange(ToPinyinDisV(itemSen));
                    }
                    else
                    {
                        foreach (char itemWord in itemSen.Replace("\n", "").Replace("\r", "").Replace(" ", ""))
                        {
                            if (nPinyinRBox.Checked)
                            {
                                listBoxWord.Items.Add(ToPinyin.ByNPingyin(itemWord));
                            }
                            else
                            {
                                listBoxWord.Items.Add(ToPinyin.ByMsIntPinyin(itemWord));
                            }
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show(@"歌词不能为空。");
            }

        }

        private void ListBoxWord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxLyrics.Text))
            {
                var myLyricsChars = textBoxLyrics.Text.Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("|","").ToCharArray();
                string myLyricsWordStr = myLyricsChars[listBoxWord.SelectedIndex].ToString();

                textBoxTone.Enabled = true;

                if (new ChineseChar(Convert.ToChar(myLyricsWordStr)).IsPolyphone)
                {
                    listBoxTone.Enabled = true;

                    var pinyinListR = new ChineseChar(Convert.ToChar(myLyricsWordStr)).Pinyins;
                    var pinyinList = new List<string>(pinyinListR);

                    RemoveNullElement(pinyinList);

                    listBoxTone.Items.Clear();
                    listBoxTone.Items.AddRange(items: pinyinList.ToArray());
                }
                else
                {
                    MessageBox.Show(@"这不是一个多音字。");
                }
            }
        }

        private void ListBoxTone_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBoxWord.Items[listBoxWord.SelectedIndex] = Regex.Replace(listBoxTone.SelectedItem.ToString(), @"\d", "").ToLower();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (listBoxWord.Items.Count != 0 && listBoxWord.Items.Count == (PointCount - IgnoreRNum))
            {
                SaveBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show(@"填词音符数不正确。");
            }
        }

        private void SaveBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int listIndex = 0;
                foreach (var itemSection in UstData.Sections)
                {
                    if (itemSection.Keys["Lyric"] == "R" && File.Exists("ignoreR.enable"))
                    {
                        
                    }
                    else
                    {
                        itemSection.Keys["Lyric"] = listBoxWord.Items[listIndex].ToString();
                        listIndex++;
                    }
                }

                File.WriteAllText(SavePath,
                    UstHeader + UstData.ToString().Replace(" = ", "=").Replace("\r\n\r\n", "\r\n"));
            }

            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }

        }

        private void SaveBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(@"OK!");
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
            List<string> wordList = dict.Dictionary.Keys.ToList();
            List<string> wordsLeft = Segmentation.SegMmDouble(str, ref wordList);

            if (wordsLeft == null)
            {
                MessageBox.Show(@"意外的错误，分词失败。");
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
                        pinyin = ToPinyin.ByMsIntPinyin(word.ToCharArray()[0]);
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

        private static string RemoveFormat(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace("，", "|");
            str = str.Replace("。", "|");
            str = Regex.Replace(str, "\\p{P}", "");
            str = Regex.Replace(str, @"[A-Za-z0-9]", "");
            return str;
        }

    }
}
