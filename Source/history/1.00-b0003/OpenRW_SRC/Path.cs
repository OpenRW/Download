/*
	THIS FILE IS A PART OF OPENRW
      https://github.com/OpenRW		
	    © Felix Bartling 2015
    
    The Path form gets skipped, if
    the user already defined game pathes 
    earlier. The user can manually select
    a folder if it's not set yet.

    News: Now this project should be
    compatible with VS 2015.
    Hopefully it's still comp. with
    VS 2013, I couldn't test that yet :/
     
*/
using Microsoft.Win32;
using OpenRW_SRC;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenRW
{
    public partial class Path : Form
    {
        int intGame = 0; //0=GTA 3, 1=GTA:VC, 2=GTA:SA
        IniFile MyIni = new IniFile("Settings.ini"); //creates / loads the settings file
        public Path(int currGame)
        { 
            intGame = currGame;
            Boolean worked = false;
            if (MyIni.KeyExists("Path" + intGame)) //Path contains the pathes of the GTA folders.
            {
                var GamePath = MyIni.Read("Path" + intGame);
                if (Directory.Exists(GamePath))
                {
                    if (Directory.GetFiles(GamePath, gameEXE(intGame), SearchOption.TopDirectoryOnly).Count() > 0 || Directory.GetFiles(GamePath, "gta-sa.exe", SearchOption.TopDirectoryOnly).Count() == 1)
                    {
                        worked = true;
                        Explorer explorerForm = new Explorer(intGame, GamePath);
                        explorerForm.Closed += (s, args) => Application.Exit();
                        explorerForm.Show(); //Opens the explorer form, if the path was found and exists. Parameters: int of the current game and path of the current game.
                    }
                }
            }
            if (!(worked))
            {
                this.Show();
            }
            //Following lines search in the registry for game pathes
            InitializeComponent();
            label1.Text = label1.Text + " " + gameString(currGame) + "!";
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey sk1 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 12100"); // III Steam
            RegistryKey sk2 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 12110"); // Vice City Steam
            RegistryKey sk3 = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 12120"); // San Andreas Steam

            if (intGame == 0)
            {
                if (sk1 != null)
                {
                    if (sk1.GetValueNames().Contains("InstallLocation") && sk1.GetValue("InstallLocation").ToString() != "")
                    {
                        textBox1.Text = sk1.GetValue("InstallLocation").ToString();
                    }
                }
            }
            else if (intGame == 1)
            {
                if (sk2 != null)
                {
                    if (sk2.GetValueNames().Contains("InstallLocation") && sk2.GetValue("InstallLocation").ToString() != "")
                    {
                        textBox1.Text = sk2.GetValue("InstallLocation").ToString();
                    }
                }
            }
            else if (intGame == 2)
            {
                if (sk3 != null)
                {
                    if (sk3.GetValueNames().Contains("InstallLocation") && sk3.GetValue("InstallLocation").ToString() != "")
                    {
                        textBox1.Text = sk3.GetValue("InstallLocation").ToString();
                    }
                }
            }




        }

        //converts the currGame int to the game title
        private string gameString(int currGame)
        {
            if (currGame == 0)
            {
                return "GTA III";
            }
            else if (currGame == 1)
            {
                return "GTA Vice City";
            }
            else
            {
                return "GTA San Andreas";
            }
        }

        //converts the currGame int to the game-exe name. Note that San Andreas comes with a -sa and _sa file name (retail and steam version).
        private string gameEXE(int currGame)
        {
            if (currGame == 0)
            {
                return "gta3.exe";
            }
            else if (currGame == 1)
            {
                return "gta-vc.exe";
            }
            else
            {
                return "gta_sa.exe";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Opens the folderBrowserDialog. It's awful, I know, I know... Maybe VS 2015 comes with a better one, gonna upgrade soon.
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.Description = "Please select your " + gameString(intGame) + " directory!";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Saves the path to the ini file, if.. aah common you can read those error messages on your own...
            if (Directory.Exists(textBox1.Text))
            {
                if (Directory.GetFiles(textBox1.Text, gameEXE(intGame), SearchOption.TopDirectoryOnly).Count() == 1 || Directory.GetFiles(textBox1.Text, "gta-sa.exe", SearchOption.TopDirectoryOnly).Count() == 1)
                {
                    MyIni.Write("Path" + intGame, textBox1.Text);

                    this.Hide();
                    Explorer explorerForm = new Explorer(intGame, textBox1.Text);
                    explorerForm.Closed += (s, args) => Application.Exit();
                    explorerForm.Show();

                }
                else
                {
                    MessageBox.Show("The given folder does not contain the file " + gameEXE(intGame) + "!", gameEXE(intGame) + " not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The given folder does not exist!", "Folder not found",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //This fixes something. Aah yes. You can't continue without typing something. Makes sense, doesn't it!?
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

    }
    }


/*





namespace OpenRW_SRC
{
    public partial class Path : Form
    {
        
        

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Path));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the installation path of";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(18, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(391, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(415, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(18, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Continue";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // Path
            // 
            this.ClientSize = new System.Drawing.Size(502, 122);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Path";
            this.Text = "Select game folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        } //Don't ask me how this came here. I guess this one moved here when my project crashed the last time :D
    }

    //Not written by me. Does work, that's all I know. :-)
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
*/
