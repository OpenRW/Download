using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRW
{
    public partial class Renamer : Form
    {
        public Renamer()
        {
            InitializeComponent();


        }

        public string ReturnNewName
        { 
            get; set; 
        }

        private void Renamer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ReturnNewName = textBox1.Text;
            this.Close();
        }
    }
}
