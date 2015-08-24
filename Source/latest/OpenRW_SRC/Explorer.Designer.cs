/*
	THIS FILE IS A PART OF OPENRW
      https://github.com/OpenRW		
	    © Felix Bartling 2015
     
*/

namespace OpenRW_SRC
{
    partial class Explorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Grand Theft Auto Vice City");
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.EmptyFolderLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.leftStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInWindowsExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInWindowsExplorerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExternalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.showInWindowsExplorerToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiescomingSoonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewInTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.getTheSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateOpenRWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.searchForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.neuToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.leftStrip.SuspendLayout();
            this.rightStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(386, 312);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // EmptyFolderLabel
            // 
            this.EmptyFolderLabel.AutoSize = true;
            this.EmptyFolderLabel.BackColor = System.Drawing.Color.White;
            this.EmptyFolderLabel.Location = new System.Drawing.Point(13, 10);
            this.EmptyFolderLabel.Name = "EmptyFolderLabel";
            this.EmptyFolderLabel.Size = new System.Drawing.Size(99, 13);
            this.EmptyFolderLabel.TabIndex = 2;
            this.EmptyFolderLabel.Text = "The folder is empty.";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // leftStrip
            // 
            this.leftStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInWindowsExplorerToolStripMenuItem,
            this.copyPathToolStripMenuItem});
            this.leftStrip.Name = "leftStrip";
            this.leftStrip.Size = new System.Drawing.Size(214, 48);
            // 
            // showInWindowsExplorerToolStripMenuItem
            // 
            this.showInWindowsExplorerToolStripMenuItem.Name = "showInWindowsExplorerToolStripMenuItem";
            this.showInWindowsExplorerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.showInWindowsExplorerToolStripMenuItem.Text = "Show in Windows Explorer";
            this.showInWindowsExplorerToolStripMenuItem.Click += new System.EventHandler(this.showInWindowsExplorerToolStripMenuItem_Click);
            // 
            // copyPathToolStripMenuItem
            // 
            this.copyPathToolStripMenuItem.Name = "copyPathToolStripMenuItem";
            this.copyPathToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.copyPathToolStripMenuItem.Text = "Copy path";
            this.copyPathToolStripMenuItem.Click += new System.EventHandler(this.copyPathToolStripMenuItem_Click);
            // 
            // rightStrip
            // 
            this.rightStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.showInWindowsExplorerToolStripMenuItem1,
            this.copyPathToolStripMenuItem1,
            this.propertiesToolStripMenuItem});
            this.rightStrip.Name = "rightStrip";
            this.rightStrip.Size = new System.Drawing.Size(214, 92);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // showInWindowsExplorerToolStripMenuItem1
            // 
            this.showInWindowsExplorerToolStripMenuItem1.Name = "showInWindowsExplorerToolStripMenuItem1";
            this.showInWindowsExplorerToolStripMenuItem1.Size = new System.Drawing.Size(213, 22);
            this.showInWindowsExplorerToolStripMenuItem1.Text = "Show in Windows Explorer";
            this.showInWindowsExplorerToolStripMenuItem1.Click += new System.EventHandler(this.showInWindowsExplorerToolStripMenuItem1_Click);
            // 
            // copyPathToolStripMenuItem1
            // 
            this.copyPathToolStripMenuItem1.Name = "copyPathToolStripMenuItem1";
            this.copyPathToolStripMenuItem1.Size = new System.Drawing.Size(213, 22);
            this.copyPathToolStripMenuItem1.Text = "Copy path";
            this.copyPathToolStripMenuItem1.Click += new System.EventHandler(this.copyPathToolStripMenuItem1_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Enabled = false;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.propertiesToolStripMenuItem.Text = "Properties (coming soon)";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openExternalFileToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.showInWindowsExplorerToolStripMenuItem2,
            this.copyPathToolStripMenuItem2,
            this.toolStripMenuItem4,
            this.propertiescomingSoonToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openExternalFileToolStripMenuItem
            // 
            this.openExternalFileToolStripMenuItem.Enabled = false;
            this.openExternalFileToolStripMenuItem.Name = "openExternalFileToolStripMenuItem";
            this.openExternalFileToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.openExternalFileToolStripMenuItem.Text = "Open external file (coming soon)";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(244, 6);
            // 
            // showInWindowsExplorerToolStripMenuItem2
            // 
            this.showInWindowsExplorerToolStripMenuItem2.Name = "showInWindowsExplorerToolStripMenuItem2";
            this.showInWindowsExplorerToolStripMenuItem2.Size = new System.Drawing.Size(247, 22);
            this.showInWindowsExplorerToolStripMenuItem2.Text = "Show in Windows Explorer";
            this.showInWindowsExplorerToolStripMenuItem2.Click += new System.EventHandler(this.showInWindowsExplorerToolStripMenuItem2_Click);
            // 
            // copyPathToolStripMenuItem2
            // 
            this.copyPathToolStripMenuItem2.Name = "copyPathToolStripMenuItem2";
            this.copyPathToolStripMenuItem2.Size = new System.Drawing.Size(247, 22);
            this.copyPathToolStripMenuItem2.Text = "Copy path";
            this.copyPathToolStripMenuItem2.Click += new System.EventHandler(this.copyPathToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(244, 6);
            // 
            // propertiescomingSoonToolStripMenuItem
            // 
            this.propertiescomingSoonToolStripMenuItem.Enabled = false;
            this.propertiescomingSoonToolStripMenuItem.Name = "propertiescomingSoonToolStripMenuItem";
            this.propertiescomingSoonToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.propertiescomingSoonToolStripMenuItem.Text = "Properties (coming soon)";
            this.propertiescomingSoonToolStripMenuItem.Click += new System.EventHandler(this.propertiescomingSoonToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.quitToolStripMenuItem.Text = "Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem1,
            this.viewInTextToolStripMenuItem,
            this.viewInHexToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewToolStripMenuItem.Text = "Edit";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Enabled = false;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.searchToolStripMenuItem.Text = "Search (coming soon)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.selectAllToolStripMenuItem.Text = "Select all (coming soon)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // viewInTextToolStripMenuItem
            // 
            this.viewInTextToolStripMenuItem.Enabled = false;
            this.viewInTextToolStripMenuItem.Name = "viewInTextToolStripMenuItem";
            this.viewInTextToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.viewInTextToolStripMenuItem.Text = "Open as TEXT (coming soon)";
            // 
            // viewInHexToolStripMenuItem
            // 
            this.viewInHexToolStripMenuItem.Enabled = false;
            this.viewInHexToolStripMenuItem.Name = "viewInHexToolStripMenuItem";
            this.viewInHexToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.viewInHexToolStripMenuItem.Text = "Open as HEX (coming soon)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.getTheSourceToolStripMenuItem,
            this.translateOpenRWToolStripMenuItem,
            this.toolStripMenuItem5,
            this.searchForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Enabled = false;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(252, 22);
            this.helpToolStripMenuItem1.Text = "Help (coming soon)";
            // 
            // getTheSourceToolStripMenuItem
            // 
            this.getTheSourceToolStripMenuItem.Name = "getTheSourceToolStripMenuItem";
            this.getTheSourceToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.getTheSourceToolStripMenuItem.Text = "Get the source!";
            this.getTheSourceToolStripMenuItem.Click += new System.EventHandler(this.getTheSourceToolStripMenuItem_Click);
            // 
            // translateOpenRWToolStripMenuItem
            // 
            this.translateOpenRWToolStripMenuItem.Enabled = false;
            this.translateOpenRWToolStripMenuItem.Name = "translateOpenRWToolStripMenuItem";
            this.translateOpenRWToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.translateOpenRWToolStripMenuItem.Text = "Translate OpenRW (coming soon)";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(249, 6);
            // 
            // searchForUpdatesToolStripMenuItem
            // 
            this.searchForUpdatesToolStripMenuItem.Name = "searchForUpdatesToolStripMenuItem";
            this.searchForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.searchForUpdatesToolStripMenuItem.Text = "Search for updates";
            this.searchForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.searchForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.EmptyFolderLabel);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(584, 312);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "GTAroot";
            treeNode1.Text = "Grand Theft Auto Vice City";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(194, 312);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.neuToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // neuToolStripButton
            // 
            this.neuToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.neuToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("neuToolStripButton.Image")));
            this.neuToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.neuToolStripButton.Name = "neuToolStripButton";
            this.neuToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.neuToolStripButton.Text = "Back";
            this.neuToolStripButton.Click += new System.EventHandler(this.neuToolStripButton_Click);
            // 
            // Explorer
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Explorer";
            this.Text = "OpenRW - Explorer";
            this.leftStrip.ResumeLayout(false);
            this.rightStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label EmptyFolderLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip leftStrip;
        private System.Windows.Forms.ToolStripMenuItem showInWindowsExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPathToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rightStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInWindowsExplorerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyPathToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton neuToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openExternalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showInWindowsExplorerToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem copyPathToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem propertiescomingSoonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getTheSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translateOpenRWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewInTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    }
}

