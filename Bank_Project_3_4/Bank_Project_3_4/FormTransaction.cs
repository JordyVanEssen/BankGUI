using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank_Project_3_4.ViewModels;
using BankDataLayer;
using Syncfusion.WinForms.Controls;

namespace Bank_Project_3_4
{
    public partial class FormTransaction : SfForm
    {
        private Client _currentClient;
        private Transaction _transaction;
        //private UserTag _newUserId;
        private CheckValidUserInput _checkInput;
        private HttpRequest _httpRequest;
        private PrintReceipt _print;
        private CheckUserSaldo _checkSaldo;

        private int _userTagId;
        private String _chosenBill = "";
        private int _billValue = 0;
        //the bills to choose from
        private int[] bill = {5, 10, 20, 50, 100, 200, 500};

        public FormTransaction(Client pCurrentClient, Transaction pTransaction, UserTagViewModel pUserTagViewModel)
        {
            InitializeComponent();
            _currentClient = pCurrentClient;
            _transaction = pTransaction;
            _userTagId = pUserTagViewModel.UserTagId;
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            _checkSaldo = new CheckUserSaldo(_currentClient, _userTagId.ToString());
            tbUserSaldo.Text = "€ " + Convert.ToString(_checkSaldo.getSaldo());//get the saldo of the current client

            //the default bills
            cmbChooseBill.Items.Add("€5");
            cmbChooseBill.Items.Add("€10");
            cmbChooseBill.Items.Add("€20");
            cmbChooseBill.Items.Add("€50");
            cmbChooseBill.Items.Add("€100");
            cmbChooseBill.Items.Add("€200");
            cmbChooseBill.Items.Add("€500");
        }

        #region functions

        //perform the transaction
        private void transaction(String pMode)
        {
            _checkInput = new CheckValidUserInput(_currentClient);
            bool validBillFormat = false;
            bool input = false;
            bool validInput = false;
            double oldSaldo = _currentClient.Saldo;
            bool tSuccesfull = false;//transaction succesfull

            //checks if the user entered the input fields
            if (!string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                double amount = 0;

                try
                {
                    input = true;
                    validInput = _checkInput.validInput(tbAmount.Text, input);

                    if (validInput)
                    {
                        amount = Convert.ToDouble(tbAmount.Text);
                    }
                }
                catch (OverflowException)
                {
                    Helper.showMessage("Uw hebt een te groot getal ingevoerd.", MessageBoxIcon.Error);
                }


                if (validInput)
                {
                    if (pMode.Equals("Deposit"))
                    {
                        //deposit
                        Deposit deposit = new Deposit(_currentClient, amount);
                        tSuccesfull = deposit.deposit();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cmbChooseBill.Text))
                        {
                            _chosenBill = cmbChooseBill.Text.Replace("€", "");
                            _billValue = Convert.ToInt32(_chosenBill);
                            //withdraw
                            if ((amount / _billValue) % 1 == 0)
                            {
                                Withdraw withDrawel = new Withdraw(_currentClient, _userTagId, amount);
                                tSuccesfull = withDrawel.withdrawMoney();
                                validBillFormat = true;
                            }
                        }
                    }

                    if (tSuccesfull)
                    {
                        //creates and prints the receipt
                        createReceipt(oldSaldo, _currentClient.Saldo, pMode);
                        if (rbtnWithdrawel.Checked)
                        {
                            _print = new PrintReceipt(_transaction, _currentClient, cmbChooseBill.Text, Convert.ToInt32(amount / _billValue));
                        }
                        else
                        {
                            _print = new PrintReceipt(_transaction, _currentClient);
                        }

                        btnPrintReceipt.Visible = true;
                        rtbReceipt.Text = _print.print();
                        Helper.showMessage("Transactie geslaagd");
                    }
                    else
                    {
                        if (amount > _currentClient.Saldo && pMode == "Withdrawel")
                        {
                            Helper.showMessage("Transactie mislukt. U hebt niet genoeg saldo.", MessageBoxIcon.Error);
                        }
                        else if(!validBillFormat)
                        {
                            Helper.showMessage($"Uw biljet keuze is niet geschikt '{cmbChooseBill.Text}'. Kies alstublieft een andere.", MessageBoxIcon.Error);
                        }
                        else
                        {
                            Helper.showMessage("Transactie mislukt. Controleer of u alleen getallen hebt ingevoerd.", MessageBoxIcon.Error);
                        }
                        rtbReceipt.Text = "";
                    }
                }
                else
                {
                    inputErrorMsg(validInput);
                }
            }
            else
            {
                Helper.showMessage("Graag al de velden invullen.", MessageBoxIcon.Error);
            }
        }

        //fills the dropdown with the bills which can be selected
        private void addItemsToDropDown(int pAmount)
        {
            for (int i = 0; i < bill.Length; i++)
            {
                cmbChooseBill.Items.Remove("€" + Convert.ToString(bill[i]));
            }


            for (int i = 0; i < bill.Length; i++)
            {
                if (pAmount >= bill[i])
                {
                    cmbChooseBill.Items.Add("€" + Convert.ToString(bill[i]));
                }
            }
        }

        //create the receipt
        private async void createReceipt(double pOldSaldo, double pNewSaldo, String pMode)
        {
            _transaction = new Transaction { Mode = pMode };
            DateTime now = DateTime.Now;

            _transaction.ClientId = _currentClient.ClientId;
            _transaction.Name = _currentClient.Name;
            _transaction.OldSaldo = pOldSaldo;
            _transaction.NewSaldo = pNewSaldo;
            _transaction.Time = now;
            _transaction.Mode = pMode;

            _httpRequest = new HttpRequest("TransactionItems");
            Object response = await HttpRequest.CreateAsync(_transaction, _httpRequest.createUrl());
        }

        //error message if the input is invalid
        private void inputErrorMsg(bool pInput)
        {
            if (!pInput)
            {
                if (!_checkInput.validUserInput)
                {
                    Helper.showMessage("U mag alleen getallen invoeren ", MessageBoxIcon.Error);
                }
                else
                {
                    Helper.showMessage("Gelieve AL de velden invullen.", MessageBoxIcon.Error);
                }
            }
        }

        //prints the receipt on screen
        private void printReceipt()
        {
            if (rbtnWithdrawel.Checked)
            {
                _print = new PrintReceipt(_transaction, _currentClient, cmbChooseBill.Text, Convert.ToInt32(Convert.ToInt16(tbAmount.Text) / _billValue));
            }
            else
            {
                _print = new PrintReceipt(_transaction, _currentClient);
            }
            rtbReceipt.Text = _print.print();
        }

        #endregion

        #region Form functions

        private void grpbChooseBill_Enter(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rbtnDeposit.Checked == true)
            {
                transaction("Deposit");
            }
            else
            {
                transaction("Withdrawel");
            }
        }

        private void rbtnDeposit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGetSaldo_Click(object sender, EventArgs e)
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(_currentClient, _userTagId.ToString());
            tbUserSaldo.Text = "€ " + Convert.ToString(checkSaldo.getSaldo());//get the saldo of the current client
        }

        private void rbtnWithdrawel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnWithdrawel.Checked == true)
            {
                lblBill.Visible = true;
                cmbChooseBill.Visible = true;
            }
            else
            {
                lblBill.Visible = false;
                cmbChooseBill.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                _checkInput = new CheckValidUserInput(_currentClient);
                if (_checkInput.validInput(tbAmount.Text, true))
                {
                    addItemsToDropDown(Convert.ToInt32(tbAmount.Text));
                }
            }
        }

        #endregion
    }
}
