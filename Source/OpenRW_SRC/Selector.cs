/*
	THIS FILE IS A PART OF OPENRW
      https://github.com/OpenRW		
	    © Felix Bartling 2015
    
    The selector is a form that shows
    three buttons to make the user
    choose the game he want to mod.
     
*/

using OpenRW;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace OpenRW_SRC
{
    public partial class Selector : Form
    {
        public Selector()
        {
            IniFile MyIni = new IniFile("Settings.ini");
            string lang = MyIni.Read("Lang");
            if (lang == "en" || lang == "de" || lang == "be" || lang == "cs" || lang == "fa-IR" || lang == "fr" || lang == "hu" || lang == "pt-PT" || lang == "ru" || lang == "uk" || lang == "zh-Hans")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(MyIni.Read("Lang"));
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(MyIni.Read("Lang"));
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
            

            InitializeComponent();
            
        }

        //Some buttons
        private void button1_Click(object sender, EventArgs e)
        {
            //Hides the current form, DOES NOT close it.
            this.Hide();
            //Opens the Path form with an argument
            var pathForm = new OpenRW.Path(0, this.StartPosition);
            //When the new form closes, it quits the app

            
            pathForm.Closed += (s, args) => Application.Exit();
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new OpenRW.Path(10, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new OpenRW.Path(1, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new OpenRW.Path(11, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new OpenRW.Path(2, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();
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
