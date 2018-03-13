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
        public Form1(string ustPath)
        {
            InitializeComponent();

            try
            {
                string str = File.ReadAllText(ustPath).Replace("UST Version 1.20", "");

                IniData inidata = new FileIniDataParser().Parser.Parse(str);
                int startPoint = Convert.ToInt32(inidata.Sections.ElementAt(4).SectionName.Replace("#", ""));
                int mPointCount = inidata.Sections.Count - 2;

                if (inidata["#PREV"].Count != 0)
                {
                    mPointCount -= 1;
                }
                else
                {
                    startPoint = 1;
                }

                if (inidata["#NEXT"].Count != 0)
                {
                    mPointCount -= 1;
                }

                Text = "起始点：" + startPoint + " 音符数：" + mPointCount;
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
    }
}
