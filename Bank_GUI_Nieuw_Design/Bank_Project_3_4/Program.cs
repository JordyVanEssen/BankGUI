using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    - Author: Jordy van Essen | 0968981
    - Date: 01-03-2019
*/

namespace Bank_Project_3_4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length != 0)
            {
                if (args[0] == 1.ToString())
                {
                    Application.Run(new APICentraleBankConnection());
                }
            }
            else
            {
                Application.Run(new DeBank());
            }

        }
    }
}
