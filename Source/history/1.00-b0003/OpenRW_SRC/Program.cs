/*
	THIS FILE IS A PART OF OPENRW
      https://github.com/OpenRW			
	    © Felix Bartling 2015
    
    This part of OpenRW launches 
    the Selector and is the main
    entry point for the application.
     
*/
using System;
using System.Windows.Forms;

namespace OpenRW_SRC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Selector());
        }
    }
}
