/*
	THIS FILE IS A PART OF OPENRW
      https://github.com/OpenRW		
	    © Felix Bartling 2015
    
    The IMGvc form is able to display
    IMG and dir files from GTA III
    and GTA:VC. It's called a 'tool'.     
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace OpenRW_SRC
{
    public partial class IMGvc : Form
    {
        bool isWorking = false;
        string path1 = ""; //dir
        string path2 = ""; //img
        bool exit = false;
        public IMGvc(string path, bool dirOrImg) //0 = dir 1 = img
        {


            if(dirOrImg)
            {
                path2 = path;
                if(path.Contains(".IMG"))
                {
                    path1 = path.Replace(".IMG", string.Empty) + ".dir";
                }
                else
                {
                    path1 = path.Replace(".img", string.Empty) + ".dir";
                }
                
            }
            else
            {
                if (path.Contains(".DIR"))
                {
                    path2 = path.Replace(".DIR", string.Empty) + ".img";
                }
                else
                {
                    path2 = path.Replace(".dir", string.Empty) + ".img";
                }
                path1 = path;
            }

            InitializeComponent();
            dirReader();
            

        }
        //Create DIR lists
        List<int> offsetList = new List<int>(); //List with all offsets
        List<int> sizeList = new List<int>(); // List with all sizes
        List<string> nameList = new List<string>(); //List with all filenames

        

        public string FileSizeConverter(int size) //calculates entity of file size
        {
            size = size * 2048;
            if (size < 1024)
            {
                return size + " Byte";
            }
            else if (size < 1048576)
            {
                return size / 1024 + " KB";
            }
            else if (size < 1073741824)
            {
                return size / 1024 / 1024 + " MB";
            }
            else
            {
                return size / 1024 / 1024 / 1024 + " GB";
            }

        }

        public string FileTypeReturner(string type) //checks if filename contains a file format
        {
            if (type.Contains(".col"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("col");
            }
            else if (type.Contains(".cfg"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("cfg");
            }
            else if (type.Contains(".adf"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("adf");
            }
            else if (type.Contains(".dff"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("dff");
            }
            else if (type.Contains(".dat"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("dat");
            }
            else if (type.Contains(".gxt"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("gxt");
            }
            else if (type.Contains(".ide"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("ide");
            }
            else if (type.Contains(".ifp"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("ifp");
            }
            else if (type.Contains(".img"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("img");
            }
            else if (type.Contains(".ipl"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("ipl");
            }
            else if (type.Contains(".raw"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("raw");
            }
            else if (type.Contains(".sdt"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("sdt");
            }
            else if (type.Contains(".rep"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("rep");
            }
            else if (type.Contains(".scm"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("scm");
            }
            else if (type.Contains(".txd") || type.Contains(".TXD"))
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("txd");
            }
            else
            {
                return OpenRW.Resources._internal.ResourceManager.GetString("unk");
            }
        }

        public void dirReader()
        {
            //SEE DETAILED INFORMATION ABOUT THE .IMG AND .DIR FORMAT AT http://www.gtamodding.com/wiki/IMG_archive 

           if(File.Exists(path1))
           {

            
            //Read .DIR file to HEX
            FileStream openFile = new FileStream(path1, FileMode.Open, FileAccess.Read);
            String fileSize = openFile.Length.ToString(); //filesize in Byte


            //Script taken from MSDN: https://msdn.microsoft.com/en-us/library/system.io.filestream.read(v=vs.110).aspx
            byte[] bytes = new byte[openFile.Length];//Read the source file into a byte array. 
            int numBytesToRead = (int)openFile.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                //Read may return anything from 0 to numBytesToRead. 
                int n = openFile.Read(bytes, numBytesRead, numBytesToRead);

                //Break when the end of the file is reached. 
                if (n == 0)
                { 
                    break;
                }

                    
                numBytesRead += n;
                numBytesToRead -= n;

            }
                                //numBytesToRead = bytes.Length;




            int pointer = 0;

            while (pointer < bytes.Length)
            {
                offsetList.Add(BitConverter.ToInt32(bytes, pointer)); //Reads offset
                pointer += 4;
                sizeList.Add(BitConverter.ToInt32(bytes, pointer)); //Reads size
                pointer += 4;

                int nameLength = 0; //Integer containing the actual filename length
                int localPointer = pointer; //Pointer to get the lenght of the filename
                byte[] nameByte = new byte[24];

                for (int i = 0; i < 24; i++)
                {
                    nameByte[i] = bytes[localPointer++];

                    if (nameByte[i] == 00) //Breaks, if the end of the filename is reached.
                    {
                        nameLength = i;
                        break;
                    }
                }

                nameList.Add(Encoding.ASCII.GetString(bytes, pointer, nameLength)); //Encodes the bytes to a string

                pointer += 24;

            }
            for (int i = 0; i < nameList.Count; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString(), 0, listView1.Groups[0]);
                item.SubItems.Add(nameList[i]);
                item.SubItems.Add(FileSizeConverter(sizeList[i]));
                item.SubItems.Add(FileTypeReturner(nameList[i]));
                listView1.Items.Add(item);
            }



                openFile.Close();
           }
            else
            {
                MessageBox.Show(OpenRW.Resources._internal.ResourceManager.GetString("notFoundTWO"));
                exit = true;
            }
           

        }

        public void imgReader(int index, Boolean fast)
        {
            //SEE DETAILED INFORMATION ABOUT THE .IMG AND .DIR FORMAT AT http://www.gtamodding.com/wiki/IMG_archive 

            //variables containing offset, size and filename of selected entry
            int offset = offsetList[index];
            int size = sizeList[index];
            string name = nameList[index];

            //calculate sectors
            int sizeInBytes = size * 2048;
            int offsetInBytes = offset * 2048;

            //Read .IMG file to HEX
            FileStream openFile = new FileStream(path2, FileMode.Open, FileAccess.Read);
            String fileSize = openFile.Length.ToString(); //filesize in Byte
            openFile.Seek(offsetInBytes, 0);
            byte[] extrBytes = new byte[sizeInBytes];
            openFile.Read(extrBytes, 0, sizeInBytes);
            
            if(fast == false)
            {
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = name.Substring(name.IndexOf("."));
                saveFileDialog1.FileName = name.Substring(0, name.IndexOf(".") + 1).Replace(".", "");
                saveFileDialog1.Filter = FileTypeReturner("." + saveFileDialog1.DefaultExt.ToString()).Substring(FileTypeReturner("." + saveFileDialog1.DefaultExt.ToString()).IndexOf(")")).Replace(")", "") + "|" + "*." + saveFileDialog1.DefaultExt.ToString();
                saveFileDialog1.ShowDialog();
                string folder = saveFileDialog1.FileName;
                FileStream fs = File.Create(saveFileDialog1.FileName, sizeInBytes);
                fs.Write(extrBytes, 0, sizeInBytes);
                fs.Close();
            }
            else
            {
                if(!isWorking)
                {
                    folderBrowserDialog1.ShowDialog();
                    isWorking = true;
                }                
                FileStream fs = File.Create(folderBrowserDialog1.SelectedPath + @"\" + name, sizeInBytes);
                fs.Write(extrBytes, 0, sizeInBytes);
                fs.Close();

            }
            
        }
        private void RenameFile(int rIndex, string rNewFile)
        {
            if(rNewFile.Length < 24)
            {
            FileStream openFile = new FileStream(path1, FileMode.Open, FileAccess.Write);
                openFile.Seek(rIndex*32,SeekOrigin.Begin);
                openFile.Seek(8, SeekOrigin.Current);
                openFile.Write(new byte[24],0,24);
                openFile.Seek(-24, SeekOrigin.Current);
                byte[] newName = new byte[24];
                Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());
                newName = enc.GetBytes(rNewFile);
                openFile.Write(newName, 0, newName.Length);
                openFile.Flush();
                openFile.Close();

                                                    //Encoding.ASCII.
                //openFile.Write()
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            } 
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                extractToolStripMenuItem1.Enabled = false;
            }
            else
            {
                extractToolStripMenuItem1.Enabled = true;
            }
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 1)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    imgReader(item.Index, true);
                }
                isWorking = false;

            }

            else
            {
                imgReader(listView1.SelectedIndices[0],false);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void extractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 1)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    imgReader(item.Index, true);
                }
                isWorking = false;

            }

            else
            {
                imgReader(listView1.SelectedIndices[0], false);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count > 1)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    imgReader(item.Index, true);
                }
                isWorking = false;

            }

            else
            {
                imgReader(listView1.SelectedIndices[0], false);
            }
        }

        private void IMGvc_Load(object sender, EventArgs e)
        {
            if(exit)
            {
                this.Close();
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openForm = new OpenRW.Renamer();
            var result = openForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string val = openForm.ReturnNewName;            //values preserved after close
                RenameFile(listView1.SelectedItems[0].Index, val);
            }
            
        }

        private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var openForm = new OpenRW.Renamer();
            var result = openForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string val = openForm.ReturnNewName;            //values preserved after close
                RenameFile(listView1.SelectedItems[0].Index, val);
            }
        }

        private void rebuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ctr = 0;
		foreach (int element in offsetList)
		{
		if(ctr!=0)
        { 
		    if((offsetList[ctr] - (sizeList[ctr -1]  + offsetList[ctr-1])) > 0)
		    {
                FileStream openFile = new FileStream(path2, FileMode.Open, FileAccess.ReadWrite);
                openFile.Seek(offsetList[ctr], SeekOrigin.Begin);
                byte[] myBytes = new Byte[(offsetList[offsetList.Count - 1] + sizeList[sizeList.Count - 1]) - (offsetList[ctr])];
                openFile.Read(myBytes,0, (offsetList[offsetList.Count - 1] + sizeList[sizeList.Count - 1]) - (offsetList[ctr]));
                openFile.Seek(-(offsetList[ctr] - (sizeList[ctr - 1] + offsetList[ctr - 1])), SeekOrigin.Current);
                openFile.SetLength(openFile.Length - (offsetList[ctr] - (sizeList[ctr - 1] + offsetList[ctr - 1])));
                openFile.Write(myBytes, 0, myBytes.Length);
                openFile.Flush();
                openFile.Close();
                
                foreach(int offset in offsetList)
                {

                }
                //Result: IMG is cleaned up, but changes have not been written to the .DIR files yet.
                //DO NOT TRY TO BUILD THIS CODE. IT WILL CRASH YOUR IMG FILES!
		        //The offsets of all bits, that were moved need to get edited in the DIR files.
		    }
		    else
		    {
			    //kein Platz
		    }
            
            //MessageBox.Show("Läuft");
        }
		ctr++;

		}
            

        }

        private void showOffsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(offsetList[listView1.SelectedItems[0].Index].ToString());
        }
    }
}


