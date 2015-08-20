/*
	THIS FILE IS A PART OF OPENRW
      https://github.com/OpenRW		
	    © Felix Bartling 2015
    
    The selector is a form that shows
    three buttons to make the user
    choose the game he want to mod.
     
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRW_SRC
{
    public partial class Selector : Form
    {
        public Selector()
        {
            InitializeComponent();
        }

        //Some buttons
        private void button1_Click(object sender, EventArgs e)
        {
            //Hides the current form, DOES NOT close it.
            this.Hide();
            //Opens the Path form with an argument
            var pathForm = new Path(0);
            //When the new form closes, it quits the app

            
            pathForm.Closed += (s, args) => Application.Exit();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new Path(1);
            pathForm.Closed += (s, args) => Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new Path(2);
            pathForm.Closed += (s, args) => Application.Exit();
        }
    }
}
