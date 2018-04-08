using System;
using System.IO;
using System.Windows.Forms;

namespace UTAUEasyChnInput
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            if (!string.IsNullOrWhiteSpace(string.Join("", args)))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(string.Join("", args)));
                
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MessageBox.Show("没有包含应有的参数，请作为UTAU插件使用");
                if (File.Exists("test"))
                {
                    Application.Run(new Form1());
                }

            }
        }
    }
}
