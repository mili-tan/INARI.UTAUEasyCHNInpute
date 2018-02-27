using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.International.Converters.PinYinConverter;

namespace UTAUEasyChnInput
{
    public partial class Form1 : Form
    {
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
            foreach (char itemWords in textBoxLyrics.Text)
            {
                string pinyinStr = new ChineseChar(itemWords).Pinyins[0].ToString();
                listBoxWord.Items.Add(Regex.Replace(pinyinStr, @"\d", "").ToLower());
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
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
                        if (list[i] != null)
                            list[newCount++] = list[i];

                    list.RemoveRange(newCount, count - newCount);
                    break;
                }
        }

        private void textBoxLyrics_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
