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
    //Hopefully it's still comp. with
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
        
        int intGame = 0; //0=GTA 3, 10=GTA 3 PS 2, 1=GTA:VC PC, 11=GTA:VC PS2, 2=GTA:SA
        IniFile MyIni = new IniFile("Settings.ini"); //creates / loads the settings file
        public Path(int currGame, FormStartPosition pos)
        {
            this.StartPosition = pos;
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
            label1.Text = label1.Text + " " + gameString(currGame) + OpenRW.Resources._internal.ResourceManager.GetString("lblATR") + "!";
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
                return "GTA III (PC)";
            }
            else if (currGame == 10)
            {
                return "GTA III (PS2)";
            }
            else if (currGame == 1)
            {
                return "GTA Vice City (PC)";
            }
            else if (currGame == 11)
            {
                return "GTA Vice City (PS2)";
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
            else if (currGame == 11 || currGame == 10)
            {
                return "SYSTEM.CNF";
            }
            else
            {
                return "gta_sa.exe";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.Description = Resources._internal.ResourceManager.GetString("pls1ST") + gameString(intGame) + Resources._internal.ResourceManager.GetString("plsLST");
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
                    MessageBox.Show(Resources._internal.ResourceManager.GetString("noFiTXT") + gameEXE(intGame) + "!", gameEXE(intGame) + Resources._internal.ResourceManager.GetString("noFiDES"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Resources._internal.ResourceManager.GetString("noFoTXT"), Resources._internal.ResourceManager.GetString("noFoDES"),
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