/*
	THIS FILE IS A PART OF OPENRW
     https://github.com/OpenRW			
	    © Felix Bartling 2015
    
    The About form displays some
    information about this program.
     
*/
using System.Windows.Forms;

namespace OpenRW_SRC
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            textBox1.SelectionStart = 0;
        }
    }
}
