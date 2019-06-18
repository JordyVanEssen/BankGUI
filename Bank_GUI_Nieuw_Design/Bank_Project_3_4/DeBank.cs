using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.Entity;
using System.Net.Http;
using BankDataLayer;
using Bank_Project_3_4.ViewModels;
using Syncfusion.WinForms.Controls;

/*
    - Author: Jordy van Essen | 0968981
    - Date: 01-03-2019
*/
namespace Bank_Project_3_4
{
    public partial class DeBank : SfForm
    {
        //instances 
        SerialPort myPort = new SerialPort();//create a serial port
        HttpRequest _httpRequest;
        UserTagViewModel _userTagView = new UserTagViewModel();

        private string serialInput;//incoming data is stored in String rxString

        //the password strings
        String _enteredPassword = string.Empty;
        String _lblPincodeText = string.Empty;

        //user NUID
        private String _currentClientNuid = String.Empty;

        //booleans for validation of the password
        public static bool _validPass = false;
        bool _loggedOut = false;
        bool _enterPassword = false;

        private int[] bill = { 10, 50, 100 };

        private static readonly HttpClient httpClient = new HttpClient();

        public DeBank()
        {
            InitializeComponent();
        }

        //when the form is loaded the following will be executed:
        private void DeBank_Load(object sender, EventArgs e)
        {
           
            this.Style.Border = new Pen(Color.Silver, 2);
            //setup the serial port
            myPort.BaudRate = 9600;
            myPort.PortName = "COM3";
            myPort.DataReceived += MyPort_DataReceived;

            try
            {
                //myPort.Open();
                //myPort.WriteLine("R");
                //myPort.WriteLine("R");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //the default bills
            cmbChooseBill.Items.Add("€10");
            cmbChooseBill.Items.Add("€50");
            cmbChooseBill.Items.Add("€100");
        }

        

        //===================\\
        //   The functions   \\
        //===================\\
        #region CustomFunctions

        //checks if the entered nuid exists
        private async void nuidValidation(String pNuid)
        {
            updateText("");
            myPort.WriteLine("P");
            _enterPassword = true;
            UpdateForm();
        }

        //checks if the user entered a valid password
        private async void checkPasswordValidation(String pPassword)
        {
            String lastChar = "";
            ClientPasswordCheck checkPass = new ClientPasswordCheck();
            if (pPassword != "#" && pPassword != "*" && !string.IsNullOrEmpty(pPassword))
            {
                _lblPincodeText += "X";
                _enteredPassword += pPassword;
                lastChar = pPassword;
                updateText(_lblPincodeText);
                _lblPincodeText = string.Empty;
            }
            else if (pPassword == "*")
            {
                if (_enteredPassword.Length >= 1)
                {
                    _enteredPassword = _enteredPassword.Remove(_enteredPassword.Length - 1);
                }
                updateText("<>");
            }
            else if(pPassword == "#")
            {
                //validates the password
                int response = await checkPass.validatePassword(_enteredPassword, _currentClientNuid);

                if (response == 0)
                    _validPass = false;
                else if (response == 1)
                    _validPass = true;
                else if (response == 2)
                    Helper.showMessage("Uw pas is geblokkeerd", MessageBoxIcon.Error);
                else if (response == 4)
                    Helper.showMessage("Connection time out", MessageBoxIcon.Error);

                //if the password is correct
                if (_validPass)
                {
                    //updates the form
                    UpdateForm();
                }
                else
                {
                    if (response == 0)
                    {
                        Helper.showMessage("Uw wachtwoord is incorrect, probeer het alstublieft opnieuw.");
                        myPort.Write("R");
                        _loggedOut = true;
                        _enterPassword = false;
                        UpdateForm();
                        updateText("");
                    }
                }
                _enteredPassword = string.Empty;
            }
        }

        public void updateMessage(String pInput)
        {
            //update the label text
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(updateMessage), new object[] { pInput });
                return;
            }

            lblMessage.Text = pInput;
        }

        //updates the label text
        public void updateText(String pInput)
        {
            //update the label text
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(updateText), new object[] { pInput });
                return;
            }

            if (_loggedOut)
            {
                lblMessage.Text = $"Welkom, houd uw pas voor de reader.";
            }
            else
            {
                lblMessage.Text = $"Graag uw pincode invoeren op het keypad ";

                if (pInput == "<>")
                {
                    _lblPincodeText = lblPinCode.Text.Substring(4);
                    if (_lblPincodeText.Length >= 1)
                    {
                        _lblPincodeText = _lblPincodeText.Remove(_lblPincodeText.Length - 1);
                    }
                    lblPinCode.Text = $"PIN:{_lblPincodeText}";
                    _lblPincodeText = string.Empty;
                }
                else
                {
                    lblPinCode.Text += pInput;
                }
            }
        }

        //transaction
        public async void transaction(String pAmount, String pBill)
        {
            if (!string.IsNullOrEmpty(pAmount) || !string.IsNullOrEmpty(pBill))
            {
                ExecuteTransaction exeTransaction = new ExecuteTransaction(_currentClientNuid);
                int status = await exeTransaction.executeTransaction(pBill, pAmount);

                rtbReceipt.Visible = true;
                rtbReceipt.Text = await exeTransaction.printReceipt();

                if (status == 0)
                {
                    this.Enabled = false;
                    using (FormLogOut logOutForm = new FormLogOut())
                    {
                        if (logOutForm.ShowDialog() == DialogResult.OK)
                        {
                            logOut();
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    Helper.showMessage($"Controleer op de volgende dingen:" +
                                        $"\n >> Alleen getallen ingevoerd?" +
                                        $"\n >> Al de velden inveguld?" +
                                        $"\n >> Heeft u genoeg saldo?");
                }
            }
        }

        //updates the text and visibility of the form
        public void UpdateForm()//show client data
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateForm));
                return;
            }

            if (_validPass)
            {
                _enterPassword = false;
                lblMessage.Visible = false;
                myPort.WriteLine("P");
                showPanel(pnlMenu);
            }
            else
            {
                lblMessage.Visible = true;
                rtbReceipt.Visible = false;
                showPanel(null);
            }

            if (_enterPassword)
            {
                lblPinCode.Text = "PIN: ";
                lblPinCode.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                lblPinCode.Visible = false;
                btnCancel.Visible = false;
            }
        }

        //logs out
        public void logOut()
        {
            //ucWelcomePage ucWelcome = new ucWelcomePage();
            //ucWelcome.BringToFront();

            _enterPassword = false;
            _validPass = false;
            UpdateForm();
            _loggedOut = true;
            _enteredPassword = string.Empty;
            rtbReceipt.Text = "";

            updateText("");
            
            myPort.WriteLine("R");
        }

        //gets the usefull data out of the input string
        private String stripString(String pBegin, String pEnd, String pMain)
        {
            String inputResult = String.Empty;

            int pFrom = pMain.IndexOf(pBegin) + pBegin.Length;
            int pTo = pMain.LastIndexOf(pEnd);
            inputResult = pMain.Substring(pFrom, pTo - pFrom);

            return inputResult;
        }

        //fills the dropdown with the bills which can be selected
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

        #endregion


        //=====================\\
        //   The Formfunctions \\
        //=====================\\
        #region FormFunctions

        //reads serial data when the arduino sends any
        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //reads the incoming serial data
            serialInput = myPort.ReadLine();

            if (serialInput.Contains("nuid{"))
            {
                String nuidResult = stripString("nuid{", "}", serialInput);
                nuidResult = nuidResult.Replace(" ","");

                _currentClientNuid = nuidResult.Substring(0, nuidResult.Length - 4).Trim();
                nuidValidation(nuidResult);
            }
            else if (serialInput.Contains("pw{"))
            {
                String pwResult = stripString("pw{", "}", serialInput);

                if (!string.IsNullOrEmpty(pwResult) && !_validPass)
                {
                    checkPasswordValidation(pwResult);
                }
                else
                {
                    if (pnlOtherTransaction.Visible)
                        addNumToTb(pwResult);
                }
            }
        }

        private void addNumToTb(String pInput)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(addNumToTb), new object[] { pInput });
                return;
            }

            tbAmount.Text += pInput;
        }

        //debug button
        private void btnReset_Click(object sender, EventArgs e)
        {
            myPort.WriteLine("R");
        }

        //makes panels visible or not
        private void showPanel(Panel pPanel)
        {
            Panel[] pnlList = { pnlMenu, pnlOtherTransaction, pnlSaldo, pnlTransaction, pnlBack };

            foreach (Panel panel in pnlList)
            {
                panel.Visible = false;

                if (panel == pPanel)
                    pPanel.Visible = true;

                if (_validPass)
                    pnlBack.Visible = true;
            }
        }

        //the user logs out, another user can log in
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            logOut();
        }

        //cancels the user attempt to log in
        private void btnCancel_Click(object sender, EventArgs e)
        {
            myPort.WriteLine("C");
            logOut();
        }

        //execute a transaction
        private void btnTransaction_Click(object sender, EventArgs e)
        {
            //transaction();
            showPanel(pnlTransaction);
        }

        //returns the saldo of the currentuser
        private async void btnGetSaldo_Click(object sender, EventArgs e)
        {
            showPanel(pnlSaldo);

            _httpRequest = new HttpRequest("ClientSaldo", $"{_currentClientNuid}");
            tbUserSaldo.Text = $"€{await HttpRequest.getSaldoAsync(_httpRequest.createUrl())}";
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            CheckValidUserInput check = new CheckValidUserInput();
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                if(check.validInput(tbAmount.Text, true))
                {
                    addItemsToDropDown(Convert.ToInt32(tbAmount.Text));
                }
            }
        }

        private void BtnOtherTransaction_Click(object sender, EventArgs e)
        {
            showPanel(pnlOtherTransaction);
        }

        private void BtnExeOtherTransaction_Click(object sender, EventArgs e)
        {
            transaction(tbAmount.Text, cmbChooseBill.Text);
        }

        private void Btn10_Click(object sender, EventArgs e)
        {
            transaction("10", cmbChooseBill.Text);
        }

        private void Btn50_Click(object sender, EventArgs e)
        {
            transaction("50", cmbChooseBill.Text);
        }

        private void Btn100_Click(object sender, EventArgs e)
        {
            transaction("100", cmbChooseBill.Text);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            showPanel(pnlMenu);
        }


        #endregion

        private async void BtnOtherUserValidation_Click(object sender, EventArgs e)
        {
            _httpRequest = new HttpRequest("Authentication");
            int response = await HttpRequest.AuthenticationAsync(_httpRequest.createUrl(), $"{tbOtherPassword.Text}/{tbOtherIban.Text}");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            APICentraleBankConnection f = new APICentraleBankConnection();
            f.Show();
        }
    }
}
