using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project_3_4
{
    public static class Helper
    {
        public static void showMessage(String pMessage)
        {
            showMessage(pMessage, MessageBoxIcon.Information);
        }

        public static void showMessage(String pMessage, MessageBoxIcon pIcon)
        {
            MessageBox.Show(pMessage, "", MessageBoxButtons.OK, pIcon);
        }

        
    }
}
