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
    public partial class ucSaldo : UserControl
    {
        public ucSaldo()
        {
            InitializeComponent();
        }

        private void UcSaldo_Load(object sender, EventArgs e)
        {

        }

        public void showSaldo(String pSaldo)
        {
            tbUserSaldo.Text = pSaldo;
        }
    }
}
