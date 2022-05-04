
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ISI.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;



namespace ISI.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            string _connStr = "";
            string _userID = "";
            _connStr = ConfigurationManager.AppSettings["CONSTRDB"].ToString();
            _userID = "UESR 1";
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new MDI());
            Application.Run(new MAS100LoginForm(_connStr));

        }
    }
}
