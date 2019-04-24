using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project_3_4.UserControls
{
    class SetUserControlDefault
    {
        DeBank mainForm = new DeBank();

        public int height()
        {
            return mainForm.Height;
        }

        public int width()
        {
            return mainForm.Width - 222;
        }

        public Color backColor()
        {
            return mainForm.BackColor;
        } 
    }
}
