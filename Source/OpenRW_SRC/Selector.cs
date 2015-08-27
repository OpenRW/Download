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
            var pathForm = new Path(0, this.StartPosition);
            //When the new form closes, it quits the app

            
            pathForm.Closed += (s, args) => Application.Exit();
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new Path(10, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new Path(1, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new Path(11, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pathForm = new Path(2, this.StartPosition);
            pathForm.Closed += (s, args) => Application.Exit();
        }

        
    }
}
