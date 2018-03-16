using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Microsoft.International.Converters.PinYinConverter;
using NPinyin;

namespace UTAUEasyChnInput
{
    public partial class Form1 : Form
    {
        public int StartPoint = 0;
        public int PointCount = 0;
        public IniData UstData;
        string savePath;
        string UstHeader = "[#VERSION]\r\n" +
            "UST Version 1.20\r\n";

        public Form1(string ustPath)
        {
            InitializeComponent();
            savePath = ustPath;

            try
            {
                string ustFileStr = File.ReadAllText(ustPath).Replace("UST Version 1.20", "").Replace("[#VERSION]", "");

                UstData = new FileIniDataParser().Parser.Parse(ustFileStr);
                StartPoint = Convert.ToInt32(UstData.Sections.ElementAt(2).SectionName.Replace("#", ""));
                PointCount = UstData.Sections.Count -1;

                if (UstData["#PREV"].Count != 0)
                {
                    PointCount -= 1;
                }
                else
                {
                    StartPoint = 1;
                }
                if (UstData["#NEXT"].Count != 0)
                {
                    PointCount -= 1;
                }

                Text = "起始点：" + StartPoint + " 音符数：" + PointCount;

                List<string> lyricWordList = new List<string>();
                for (int i = 0; i < PointCount; i++)
                {
                    int pointNum = i + StartPoint;
                    
                    lyricWordList.Add(UstData["#" + pointNum.ToString("0000")]["Lyric"]);
                }
                listBoxWord.Items.AddRange(lyricWordList.ToArray());
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            listBoxWord.Items.Clear();
            textBoxLyrics.Text.Replace(" ","");
            if (nPinyinR.Checked)
            {
                foreach (char itemWords in textBoxLyrics.Text)
                {
                    listBoxWord.Items.Add(Regex.Replace(Pinyin.GetPinyin(itemWords), @"\d", "").ToLower());
                }
            }
            else
            {
                foreach (char itemWords in textBoxLyrics.Text)
                {
                    listBoxWord.Items.Add(Regex.Replace(new ChineseChar(itemWords).Pinyins[0].ToString(), @"\d", "").ToLower());
                }
            }
        }

        private void ListBoxWord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var myLyricsChars = textBoxLyrics.Text.ToCharArray();
            string myLyricsWordStr = myLyricsChars[listBoxWord.SelectedIndex].ToString();
            if (new ChineseChar(Convert.ToChar(myLyricsWordStr)).IsPolyphone)
            {
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

        private void ListBoxTone_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBoxWord.Items[listBoxWord.SelectedIndex] = Regex.Replace(listBoxTone.SelectedItem.ToString(), @"\d", "").ToLower();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //SaveBackgroundWorker.RunWorkerAsync();
            try
            {
                for (int i = 0; i < PointCount; i++)
                {
                    int pointNum = i + StartPoint;
                    UstData["#" + pointNum.ToString("0000")]["Lyric"] = listBoxWord.Items[i].ToString();
                }

                UstData.Sections.RemoveSection("#PREV");
                UstData.Sections.RemoveSection("#NEXT");

                File.WriteAllText(savePath, UstHeader + UstData.ToString().Replace(" = ", "=").Replace("\r\n\r\n", "\r\n"));
            }

            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            MessageBox.Show("OK!");
            Close();
        }

        private void SaveBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //moved
        }

        private void SaveBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
