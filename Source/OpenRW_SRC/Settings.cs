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

            if(currLang == "EN")
            {
                comboBox1.SelectedIndex = 0;
            }
            else if (currLang == "DE")
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (currLang == "BE")
            {
                comboBox1.SelectedIndex = 8;
            }
            else if (currLang == "CS")
            {
                comboBox1.SelectedIndex = 2;
            }
            else if (currLang == "fa-IR")
            {
                comboBox1.SelectedIndex = 6;
            }
            else if (currLang == "FR")
            {
                comboBox1.SelectedIndex = 3;
            }
            else if (currLang == "HU")
            {
                comboBox1.SelectedIndex = 4;
            }
            else if (currLang == "pt-PT")
            {
                comboBox1.SelectedIndex = 5;
            }
            else if (currLang == "RU")
            {
                comboBox1.SelectedIndex = 9;
            }
            else if (currLang == "UK")
            {
                comboBox1.SelectedIndex = 10;
            }
            else if (currLang == "zh-Hans")
            {
                comboBox1.SelectedIndex = 7;
            }
            //Displays the current language

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MyIni.Write("Lang", "EN");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MyIni.Write("Lang", "DE");
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                MyIni.Write("Lang", "BE");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MyIni.Write("Lang", "CS");
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                MyIni.Write("Lang", "fa-IR");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                MyIni.Write("Lang", "FR");
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                MyIni.Write("Lang", "HU");
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                MyIni.Write("Lang", "pt-PT");
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                MyIni.Write("Lang", "RU");
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                MyIni.Write("Lang", "UK");
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                MyIni.Write("Lang", "zh-Hans");
            }
             
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
