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
    public partial class ucOtherAmountTransaction : UserControl
    {
        DeBank _bank = new DeBank();
        private int[] bill = { 50, 100, 200, 500 };

        public ucOtherAmountTransaction()
        {
            InitializeComponent();
        }

        private void BtnFinishTransaction_Click(object sender, EventArgs e)
        {
            _bank.transaction(tbAmount.Text, cmbChooseBill.Text);
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            CheckValidUserInput check = new CheckValidUserInput();
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                if (check.validInput(tbAmount.Text, true))
                {
                    addItemsToDropDown(Convert.ToInt32(tbAmount.Text));
                }
            }
        }



        private void addItemsToDropDown(int pAmount)
        {
            for (int i = 0; i < bill.Length; i++)
            {
                cmbChooseBill.Items.Remove($"€{bill[i]}");
            }


            for (int i = 0; i < bill.Length; i++)
            {
                if (pAmount >= bill[i])
                {
                    cmbChooseBill.Items.Add($"€{bill[i]}");
                }
            }
        }

        public void updateAmount(String pNumber)
        {
            tbAmount.Text += pNumber;
        }
    }
}
