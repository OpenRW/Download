using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRW
{
    public partial class Settings : Form
    {
        string currLang = "";
        IniFile MyIni = new IniFile("Settings.ini");
        public Settings()
        {
            InitializeComponent();
            
            if(MyIni.KeyExists("Lang"))
            { 
            currLang = MyIni.Read("Lang");
            }

            if(currLang == "en")
            {
                comboBox1.SelectedIndex = 0;
            }
            else if (currLang == "de")
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (currLang == "be")
            {
                comboBox1.SelectedIndex = 8;
            }
            else if (currLang == "cs")
            {
                comboBox1.SelectedIndex = 2;
            }
            else if (currLang == "fa-IR")
            {
                comboBox1.SelectedIndex = 6;
            }
            else if (currLang == "fr")
            {
                comboBox1.SelectedIndex = 3;
            }
            else if (currLang == "hu")
            {
                comboBox1.SelectedIndex = 4;
            }
            else if (currLang == "pt-PT")
            {
                comboBox1.SelectedIndex = 5;
            }
            else if (currLang == "ru")
            {
                comboBox1.SelectedIndex = 9;
            }
            else if (currLang == "uk")
            {
                comboBox1.SelectedIndex = 10;
            }
            else if (currLang == "zh-Hans")
            {
                comboBox1.SelectedIndex = 7;
            }
            //Displays the current language

            if(MyIni.KeyExists("Path0"))
            { 
            textBox1.Text = MyIni.Read("Path0");
            }
            else if (MyIni.KeyExists("Path10"))
            {
                textBox2.Text = MyIni.Read("Path10");
            }
            else if (MyIni.KeyExists("Path1"))
            {
                textBox3.Text = MyIni.Read("Path1");
            }
            else if (MyIni.KeyExists("Path11"))
            {
                textBox4.Text = MyIni.Read("Path11");
            }
            else if (MyIni.KeyExists("Path2"))
            {
                textBox5.Text = MyIni.Read("Path2");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MyIni.Write("Lang", "en");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MyIni.Write("Lang", "de");
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                MyIni.Write("Lang", "be");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MyIni.Write("Lang", "cs");
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                MyIni.Write("Lang", "fa-IR");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                MyIni.Write("Lang", "fr");
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                MyIni.Write("Lang", "hu");
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                MyIni.Write("Lang", "pt-PT");
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                MyIni.Write("Lang", "ru");
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                MyIni.Write("Lang", "uk");
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                MyIni.Write("Lang", "zh-Hans");
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyIni.DeleteKey("Path0");
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyIni.DeleteKey("Path10");
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyIni.DeleteKey("Path1");
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyIni.DeleteKey("Path11");
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MyIni.DeleteKey("Path2");
            Application.Restart();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyIni.DeleteKey("Path0");
            MyIni.DeleteKey("Path10");
            MyIni.DeleteKey("Path1");
            MyIni.DeleteKey("Path11");
            MyIni.DeleteKey("Path2");
            Application.Restart();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }

    class IniFile  //Written by Danny Beckett
    {
        string Path;
        string EXE = "OpenRW";

        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
