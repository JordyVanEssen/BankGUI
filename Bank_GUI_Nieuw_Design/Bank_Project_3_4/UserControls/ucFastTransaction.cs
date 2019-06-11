using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank_Project_3_4.UserControls;

namespace Bank_Project_3_4.UserControls
{
    public partial class ucFastTransaction : UserControl
    {
        DeBank _bank = new DeBank();

        public ucFastTransaction()
        {
            InitializeComponent();
        }

        private void BtnAmount10_Click(object sender, EventArgs e)
        {
            _bank.transaction("10", "10");
        }

        private void BtnAmount50_Click(object sender, EventArgs e)
        {
            _bank.transaction("50", "50");
        }

        private void BtnAmount100_Click(object sender, EventArgs e)
        {
            _bank.transaction("100", "100");
        }

        private void BtnAmount200_Click(object sender, EventArgs e)
        {
            _bank.transaction("200", "200");
        }

        private void BtnOtherAmount_Click(object sender, EventArgs e)
        {
            ucOtherAmountTransaction uc = new ucOtherAmountTransaction();
            uc.BringToFront();
        }

        private void UcFastTransaction_Load(object sender, EventArgs e)
        {

        }
    }
}
