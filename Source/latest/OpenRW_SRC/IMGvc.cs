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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRW_SRC
{
    public partial class IMGvc : Form
    {
        string path1 = ""; //dir
        string path2 = ""; //img
        public IMGvc(string path, bool dirOrImg) //0 = dir 1 = img
        {


            if(dirOrImg)
            {
                path2 = path;
                path1 = path.Replace(".img", string.Empty) + ".dir";
            }
            else
            {
                path2 = path.Replace(".dir", string.Empty) + ".img";;
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
                return "(.col) Collision file";
            }
            else if (type.Contains(".cfg"))
            {
                return "(.cfg) Configuration file";
            }
            else if (type.Contains(".adf"))
            {
                return "(.adf) Radio station audio file";
            }
            else if (type.Contains(".dff"))
            {
                return "(.dff) Model file";
            }
            else if (type.Contains(".dat"))
            {
                return "(.dat) Data file";
            }
            else if (type.Contains(".gxt"))
            {
                return "(.gxt) text file";
            }
            else if (type.Contains(".ide"))
            {
                return "(.ide) item definition file";
            }
            else if (type.Contains(".ifp"))
            {
                return "(.ifp) animation file";
            }
            else if (type.Contains(".img"))
            {
                return "(.img) archive file";
            }
            else if (type.Contains(".ipl"))
            {
                return "(.ipl) item placement file";
            }
            else if (type.Contains(".raw"))
            {
                return "(.raw) sfx archive file";
            }
            else if (type.Contains(".sdt"))
            {
                return "(.sdt) sfx directory file";
            }
            else if (type.Contains(".rep"))
            {
                return "(.rep) replay file";
            }
            else if (type.Contains(".scm"))
            {
                return "(.scm) mission script file";
            }
            else if (type.Contains(".txd"))
            {
                return "(.txd) texture archive file";
            }
            else
            {
                return "Unknown file";
            }
        }

        public void dirReader()
        {
            //SEE DETAILED INFORMATION ABOUT THE .IMG AND .DIR FORMAT AT http://www.gtamodding.com/wiki/IMG_archive 

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
        }

        public void imgReader(int index)
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
            Directory.CreateDirectory("temp");
            FileStream fs = File.Create(@"temp\" + name, sizeInBytes);
            fs.Write(extrBytes, 0, sizeInBytes);
            fs.Close();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            imgReader(listView1.SelectedIndices[0]);
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
            imgReader(listView1.SelectedIndices[0]);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void extractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imgReader(listView1.SelectedIndices[0]);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }
    
    }
}


