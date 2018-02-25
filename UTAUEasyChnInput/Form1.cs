using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            listBox.Items.Clear();
            textBoxLyrics.Text.Replace(" ","");
            foreach (char itemWord in textBoxLyrics.Text)
            {
                string pinyinStr = new ChineseChar(itemWord).Pinyins[0].ToString();
                listBox.Items.Add(Regex.Replace(pinyinStr, @"\d", "").ToLower());
            }
        }
    }
}
