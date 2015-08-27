/*
	THIS FILE IS A PART OF OPENRW
     https://github.com/OpenRW		
	    © Felix Bartling 2015
    
    The Explorer lets the user open GTA 
    related files and show them in file
    explorer.
    Parts of the following code are taken 
    from MSDN.

    News: Fixed a bug and made the project
    VS 2015 compatible.
    Updater works fine with the new GitHub
    repository
     
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;

namespace OpenRW_SRC
{

    public partial class Explorer : Form
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Explorer));
        int version = 1000004; //version = 1.00 build = 0003
        int intGame = 0; //You should know this one

        bool isWorking = false; //Is the Background Worker currently working? No, it isn't! Aaah whatever...
        string gamefolder = "";
        string currHier = ""; //Some great idea to build pathes. It even works!
        string filesystempath = "";
        
        FileInfo[] fileEntries = null; //array for displaying files
        DirectoryInfo[] folderEntries = null; ////array for displaying fodlers

        string currentPath = "";

        public Explorer(int currGame, string path)
        {
            InitializeComponent();
            
            //Disable some UI things
            openToolStripMenuItem1.Enabled = false;
            showInWindowsExplorerToolStripMenuItem2.Enabled = false;
            copyPathToolStripMenuItem2.Enabled = false;
            propertiesToolStripMenuItem1.Enabled = false;

            //turning into global vars
            intGame = currGame;
            gamefolder = path;

            //Other UI stuff
            DirectoryInfo root = new DirectoryInfo(gamefolder);
            treeView1.Nodes[0].Text = gameString(intGame);
            PrepareList();
            if (Directory.Exists(gamefolder))
            {
                try
                {
                    DirectoryInfo[] directories = root.GetDirectories();
                    if (directories.Length > 0)
                    {
                        foreach (DirectoryInfo directory in directories)
                        {
                            treeView1.Nodes[0].Nodes.Add(directory.Name, directory.Name, 0, 0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                treeView1.Nodes[0].Expand();
            }
        }

        //You should know this one already
        private string gameString(int currGame)
        {
            if (currGame == 0)
            {
                return "Grand Theft Auto III";
            }
            else if (currGame == 10)
            {
                return "Grand Theft Auto III (PS 2)";
            }
            else if (currGame == 1)
            {
                return "Grand Theft Auto: Vice City (PC)";
            }
            else if (currGame == 11)
            {
                return "Grand Theft Auto: Vice City (PS 2)";
            }
            else
            {
                return "Grand Theft Auto: San Andreas";
            }
        }


        //for displaying empty directories
        private void EmptyDirectory()
        {
            EmptyFolderLabel.Visible = true;
            listView1.Clear();
        }

        //for displaying directories with content
        private void ContentDirectory()
        {
            EmptyFolderLabel.Visible = false;
        }

        //add icons
        private void addImages(Icon iconForFile, String extension)
        {
            Invoke((MethodInvoker)(() => imageList1.Images.Add(extension, iconForFile))); 
        }

        //adds new items and images to the listView
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            isWorking = true;
            Invoke((MethodInvoker)(() => backToolStripButton.Enabled = false));


            Invoke((MethodInvoker)(() => listView1.Clear()));


            foreach (DirectoryInfo fentry in folderEntries)
            {
                
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                ListViewItem item = new ListViewItem(fentry.Name, 1);
                
                
                if(fentry.EnumerateFileSystemInfos().Count() > 0)
                {
                    iconForFile = OpenRW.Properties.Resources.full;

                    if (!imageList1.Images.ContainsKey("???"))
                    {

                        addImages(iconForFile, "???");


                    }
                    item.ImageKey = "???";
                }
                else
                {
                    iconForFile = OpenRW.Properties.Resources.empty;

                    if (!imageList1.Images.ContainsKey("????"))
                    {

                        addImages(iconForFile, "????");


                    }
                    item.ImageKey = "????";
                }

                try
                {
                    Invoke((MethodInvoker)(() => listView1.Items.Add(item)));
                }
                catch (Exception ex)
                {
                    //
                }

                

            }


            foreach (FileInfo fentry in fileEntries)
            {

                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                ListViewItem item = new ListViewItem(fentry.Name, 1);
                iconForFile = Icon.ExtractAssociatedIcon(fentry.FullName);
                
                
                // Check to see if the image collection contains an image 
                // for this extension, using the extension as a key. 
                if (!imageList1.Images.ContainsKey(fentry.Extension))
                {

                    addImages(iconForFile,fentry.Extension);
                    
                    
                }
                item.ImageKey = fentry.Extension; //wait a moment

                try { 
                Invoke((MethodInvoker)(() => listView1.Items.Add(item)));
                    }
                catch(Exception ex)
                {
                    //Application exits well while loading
                }
            }

            Invoke((MethodInvoker)(() => backToolStripButton.Enabled = true));
        }

        //prepares the listView
        private void PrepareList()
        {
            
                currHier = "";

                listView1.Clear();

                if (Directory.Exists(gamefolder))
                {

                if (Directory.EnumerateFileSystemEntries(gamefolder, "*", SearchOption.AllDirectories).Count() > 0)
                    {

                        ContentDirectory();

                        DirectoryInfo root = new DirectoryInfo(gamefolder);
                        fileEntries = root.GetFiles();
                        folderEntries = root.GetDirectories();
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        EmptyDirectory();
                    }
               }
            
        }
        //handles treeView mouse clicks
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (treeView1.SelectedNode.Bounds.Contains(e.Location) == true)
                {
                    leftStrip.Show(Cursor.Position);
                }
            }
            else
            {
                if (backgroundWorker1.IsBusy)
                {
                    try
                    {
                        backgroundWorker1.CancelAsync();
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        //Do nothing
                    }
                }
                else
                {
                    currHier = "";
                    if (e.Node.Name != "GTAroot")
                    {
                        currentPath = e.Node.Name;
                        currHier = e.Node.Name + @"\";
                    }


                    listView1.Clear();


                    string fullpath = e.Node.FullPath + "\\";
                    string rootname = treeView1.Nodes[0].Text;
                    string filepath = fullpath.Replace(rootname + "\\", "");
                    string filesystempath = gamefolder + "\\" + filepath;
                    if (Directory.Exists(filesystempath))
                    {


                        if (Directory.EnumerateFileSystemEntries(filesystempath, "*", SearchOption.AllDirectories).Count() > 0)
                        {

                            ContentDirectory();

                            DirectoryInfo root = new DirectoryInfo(filesystempath);
                            fileEntries = root.GetFiles();
                            folderEntries = root.GetDirectories();
                            backgroundWorker1.RunWorkerAsync();
                        }
                        else
                        {
                            EmptyDirectory();
                        }
                    }
                }
            }
        }

        private void showInWindowsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode.Name != "GTAroot")
            {
                Process.Start(gamefolder + @"\" + treeView1.SelectedNode.Name.ToString()); 
            }
            else
            {
                Process.Start(gamefolder); 
            }
        }

        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode.Name != "GTAroot")
            {
                Clipboard.SetText(gamefolder + @"\" + treeView1.SelectedNode.Name.ToString()); 
            }
            else
            {
                Clipboard.SetText(gamefolder); 
            }
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if(!(listView1.SelectedItems.Count > 1))
                    {
                        showInWindowsExplorerToolStripMenuItem1.Enabled = false;
                        if (listView1.SelectedItems[0].ImageKey == "????" || listView1.SelectedItems[0].ImageKey == "???")
                        {
                            showInWindowsExplorerToolStripMenuItem1.Enabled = true;
                        }
                        rightStrip.Show(Cursor.Position);
                    }             
                }
            }
        }

        private void showInWindowsExplorerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem.ImageKey == "????" || listView1.FocusedItem.ImageKey == "???")
            {
                Process.Start(gamefolder + @"\" + currHier + listView1.SelectedItems[0].Text); 
            }
             
        }

        private void copyPathToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(isWorking != true)
            {

                    
                    Clipboard.SetText(gamefolder + @"\" + currHier + listView1.SelectedItems[0].Text);

            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesLoader.ShowFileProperties(gamefolder + @"\" + currHier + listView1.SelectedItems[0].Text);
        }
        private void openFolder()
        {
            if (listView1.SelectedItems[0].ImageKey == "???" || listView1.SelectedItems[0].ImageKey == "????")
            {
                currHier = currHier + listView1.SelectedItems[0].Text + @"\";

                filesystempath = gamefolder + @"\" + currHier;
                if (Directory.Exists(filesystempath))
                {


                    if (Directory.EnumerateFileSystemEntries(filesystempath, "*", SearchOption.AllDirectories).Count() > 0)
                    {

                        ContentDirectory();

                        DirectoryInfo root = new DirectoryInfo(filesystempath);
                        fileEntries = root.GetFiles();
                        folderEntries = root.GetDirectories();
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        EmptyDirectory();
                    }
                    //Disable some UI things
                    openToolStripMenuItem1.Enabled = false;
                    showInWindowsExplorerToolStripMenuItem2.Enabled = false;
                    copyPathToolStripMenuItem2.Enabled = false;
                    propertiesToolStripMenuItem1.Enabled = false;
                    isWorking = false;
                }

            }

            else if ((listView1.SelectedItems[0].ImageKey == ".dir" || listView1.SelectedItems[0].ImageKey == ".DIR" || listView1.SelectedItems[0].ImageKey == ".img" || listView1.SelectedItems[0].ImageKey == ".IMG") && (intGame == 0 || intGame == 10 || intGame == 1 || intGame == 11))
            {
                if (listView1.SelectedItems[0].ImageKey == ".dir" || listView1.SelectedItems[0].ImageKey == ".DIR")
                {
                    IMGvc imgVCform = new IMGvc(gamefolder + @"\" + currHier + @"\" + listView1.SelectedItems[0].Text.ToString(), false);
                    imgVCform.Show();
                }
                else
                {
                    IMGvc imgVCform = new IMGvc(gamefolder + @"\" + currHier + @"\" + listView1.SelectedItems[0].Text.ToString(), true);
                    imgVCform.Show();
                }

            }
            else
            {
                Process.Start(gamefolder + @"\" + currHier + @"\" + listView1.SelectedItems[0].Text.ToString());
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFolder();
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                openFolder();
            }
        }


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void propertiescomingSoonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = new System.Net.Sockets.TcpClient("www.google.com", 80))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        //Check
        private void searchForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CheckForInternetConnection())
            {
                string url = @"https://raw.githubusercontent.com/OpenRW/Download/master/Update.ini";
            // Create an instance of WebClient
            WebClient client = new WebClient();
            // Hookup DownloadFileCompleted Event
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            // Start the download and copy the file to c:\temp
            client.DownloadFileAsync(new Uri(url), "Update.ini");
            }
            else
            {
                
                MessageBox.Show(OpenRW.Resources._internal.ResourceManager.GetString("noInetACC"));
            }
            
            
        }

        //Read result and ask for update
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            IniFile MyIni = new IniFile("Update.ini");
            if (MyIni.KeyExists("Version") && MyIni.KeyExists("File"))
            {
                string ver = MyIni.Read("Version");
                int xver = Int32.Parse(ver.Replace(".", string.Empty));
                if (xver > version)
                {
                    DialogResult dialogResult = MessageBox.Show(OpenRW.Resources._internal.ResourceManager.GetString("updAvaTXT"), OpenRW.Resources._internal.ResourceManager.GetString("updAvaDES"), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string url = MyIni.Read("File");
 
                        WebClient client = new WebClient();

                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFile2Completed);

                        client.DownloadFileAsync(new Uri(url), "Update.msi");
                    }

                }
                else
                {
                    MessageBox.Show(OpenRW.Resources._internal.ResourceManager.GetString("updNotNEC"));
                }

            }
            else
            {
                MessageBox.Show(OpenRW.Resources._internal.ResourceManager.GetString("updBRK"));
            }
        }
        //Perform update
            void client_DownloadFile2Completed(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start("Update.msi");
            Application.Exit();
        }

            private void listView1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if(listView1.SelectedItems.Count > 0)
                {
                    openToolStripMenuItem1.Enabled = true;
                    if (listView1.FocusedItem.ImageKey == "????" || listView1.FocusedItem.ImageKey == "???")
                    {
                        showInWindowsExplorerToolStripMenuItem2.Enabled = true;
                    }                    
                    copyPathToolStripMenuItem2.Enabled = true;
                    propertiesToolStripMenuItem1.Enabled = true;
            }
                else
                {
                    openToolStripMenuItem1.Enabled = false;
                    showInWindowsExplorerToolStripMenuItem2.Enabled = false;
                    copyPathToolStripMenuItem2.Enabled = false;
                propertiesToolStripMenuItem1.Enabled = false;
                }
            }

            private void getTheSourceToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Process.Start("https://github.com/OpenRW");
            }

            private void openToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                openFolder();
            }

            private void showInWindowsExplorerToolStripMenuItem2_Click(object sender, EventArgs e)
            {
                if (listView1.FocusedItem.ImageKey == "????" || listView1.FocusedItem.ImageKey == "???")
                {
                    Process.Start(gamefolder + @"\" + currHier + listView1.SelectedItems[0].Text);
                }
            }

            private void copyPathToolStripMenuItem2_Click(object sender, EventArgs e)
            {
                Clipboard.SetText(gamefolder + @"\" + currHier + listView1.SelectedItems[0].Text);
            }

            

        private void backToolStripButton_Click(object sender, EventArgs e)
        {
            if(currHier.Length > 0)
            { 
            string path = currHier.Remove(currHier.Length - 1);
            path = path.Substring(0, path.LastIndexOf(@"\") + 1);


                currHier = path;

                filesystempath = gamefolder + @"\" + currHier;
                if (Directory.Exists(filesystempath))
                {


                    if (Directory.EnumerateFileSystemEntries(filesystempath, "*", SearchOption.AllDirectories).Count() > 0)
                    {

                        ContentDirectory();

                        DirectoryInfo root = new DirectoryInfo(filesystempath);
                        fileEntries = root.GetFiles();
                        folderEntries = root.GetDirectories();
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        EmptyDirectory();
                    }
                    //Disable some UI things
                    openToolStripMenuItem1.Enabled = false;
                    showInWindowsExplorerToolStripMenuItem2.Enabled = false;
                    copyPathToolStripMenuItem2.Enabled = false;
                    propertiesToolStripMenuItem1.Enabled = false;
                    isWorking = false;
                }

            }
            
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
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

class PropertiesLoader //written by Power-Mosfet
{
    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SHELLEXECUTEINFO
    {
        public int cbSize;
        public uint fMask;
        public IntPtr hwnd;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpVerb;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpFile;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpParameters;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpDirectory;
        public int nShow;
        public IntPtr hInstApp;
        public IntPtr lpIDList;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string lpClass;
        public IntPtr hkeyClass;
        public uint dwHotKey;
        public IntPtr hIcon;
        public IntPtr hProcess;
    }

    private const int SW_SHOW = 5;
    private const uint SEE_MASK_INVOKEIDLIST = 12;
    public static bool ShowFileProperties(string Filename)
    {
        SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
        info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
        info.lpVerb = "properties";
        info.lpFile = Filename;
        info.nShow = SW_SHOW;
        info.fMask = SEE_MASK_INVOKEIDLIST;
        return ShellExecuteEx(ref info);
    }



}





