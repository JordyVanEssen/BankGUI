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
using System.Threading;

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
        HttpRequest _httpRequest = new HttpRequest();
        UserTagViewModel _userTagView = new UserTagViewModel();

        private string serialInput;//incoming data is stored in String rxString

        //the password strings
        String _enteredPassword = string.Empty;
        String _lblPincodeText = string.Empty;

        //user NUID
        private String _currentClientIban = String.Empty;

        //booleans for validation of the password
        public static bool _validPass = false;
        bool _loggedOut = false;
        bool _enterPassword = false;

        private int[] bill = { 10, 20, 50 };

        private int _Amount = 0;
        private Boolean _wantReceipt = false;

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
                myPort.Open();
                myPort.WriteLine("R");
                myPort.WriteLine("R");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //the default bills
            cmbChooseBill.Items.Add("R10");
            cmbChooseBill.Items.Add("R20");
            cmbChooseBill.Items.Add("R50");
        }

        

        //===================\\
        //   The functions   \\
        //===================\\
        #region CustomFunctions

        //checks if the entered nuid exists
        private void nuidValidation(String pNuid)
        {
            updateMessage("Voer uw PIN in op het keypad.\r\n# = enter,\r\n* = backspace");
            _enterPassword = true;
            _validPass = false;
            UpdateForm();
        }

        //checks if the user entered a valid password
        private async void checkPasswordValidation(String pPassword)
        {
            if (pPassword != "#" && pPassword != "*" && !string.IsNullOrEmpty(pPassword))
            {
                // the 'X' is added to the label
                _lblPincodeText += "X";
                _enteredPassword += pPassword;
                _loggedOut = false;
                updateText(_lblPincodeText);
                _lblPincodeText = string.Empty;
            }
            else if (pPassword == "*")
            {
                // the last 'X' is removed
                if (_enteredPassword.Length >= 1)
                {
                    _enteredPassword = _enteredPassword.Remove(_enteredPassword.Length - 1);
                }
                updateText("<>");
            }
            else if(pPassword == "#")
            {
                //validates the password
                // awaits the response from the server -> based on valid credentials
                int response = await _httpRequest.httpGetRequest($"Authentication/{_enteredPassword}/{_currentClientIban}");

                if (response == 0)
                {
                    _validPass = false;
                    updateMessage("Uw wachtwoord is incorrect,\nprobeer het alstublieft opnieuw.");
                }
                else if (response == 1)
                    _validPass = true;
                else if (response == 2)
                    updateMessage("Uw pas is geblokkeerd");
                else if (response == 4)
                    updateMessage("Uw bank is niet aangemeld bij de centrale bank");

                Thread.Sleep(2000);

                //if the password is correct
                if (_validPass)
                {
                    //updates the form
                    UpdateForm();
                }
                else
                {
                    // logs out if the server returns something other then 1
                    if (response != 1)
                    {
                        myPort.Write("R");
                        _loggedOut = true;
                        _enterPassword = false;
                        Thread.Sleep(2000);

                        logOut();
                    }
                }
            }
        }

        public void updateMessage(String pInput)
        {
            //update the label message text to inform the user
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(updateMessage), new object[] { pInput });
                return;
            }

            lblMessage.Text = string.Empty;
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
                updateMessage($"Welkom, houd uw pas voor de reader.");
                lblPinCode.Visible = false;
            }
            else
            {
                updateMessage($"Voer uw PIN in op het keypad.\r\n# = enter,\r\n* = backspace");
                lblPinCode.Visible = true;

                if (pInput == "<>")
                {
                    // removes the last X
                    _lblPincodeText = lblPinCode.Text.Substring(4);
                    if (_lblPincodeText.Length >= 1)
                    {
                        _lblPincodeText = _lblPincodeText.Remove(_lblPincodeText.Length - 1);
                    }
                    lblPinCode.Text = $"PIN: {_lblPincodeText}";
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
            if (!string.IsNullOrEmpty(pAmount) && !string.IsNullOrEmpty(pBill))
            {

                try
                {
                    if (!spMoneyDispenser.IsOpen)
                    {
                        // opens the port to the moneydispenser
                        spMoneyDispenser.BaudRate = 9600;
                        spMoneyDispenser.PortName = "COM5";
                        spMoneyDispenser.Open();
                    }
                }
                catch (Exception ex)
                {
                    Helper.showMessage(ex.Message);
                }

                DateTime now = DateTime.Today;

                int status = 1;
                updateMessage("Aan het verwerken...");

                // if the port is open
                if (spMoneyDispenser.IsOpen)
                {
                    ExecuteTransaction exeTransaction = new ExecuteTransaction(_currentClientIban, spMoneyDispenser, _enteredPassword);
                    status = await exeTransaction.executeTransaction(pBill, pAmount);
                }
                else
                {
                    // if not
                    ExecuteTransaction exeTransaction = new ExecuteTransaction(_currentClientIban, _enteredPassword);
                    status = await exeTransaction.executeTransaction(pBill, pAmount);
                }

                if (status == 0)
                {
                    if (_wantReceipt)
                    {
                        // prints the receipt if the user wants it
                        updateMessage("Bon aan het printen...");

                        spMoneyDispenser.Write($"{pAmount}>{_currentClientIban.Remove(0, 11)}>{DateTime.Today.ToString("d")}>{DateTime.Now.ToString("HH:mm:ss tt")}");
                        Thread.Sleep(2000);
                        logOut();
                    }
                }
                else
                {
                    if (await _httpRequest.httpGetRequest($"ClientSaldo/{_currentClientIban}") < Convert.ToInt32(pAmount))
                    {
                        updateMessage("Te weinig saldo...");
                    }
                    else if (string.IsNullOrEmpty(pAmount) || string.IsNullOrEmpty(pBill))
                    {
                        updateMessage("Vul aub al de velden in");
                    }
                    else if(status == 2)
                    {
                        updateMessage("Getallen invoeren die deelbaar zijn door 10");
                    }
                    else
                    {
                        updateMessage("Graag alleen getallen invoeren.");
                    }
                    Thread.Sleep(2000);
                }
            }
            _Amount = 0;
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
                updateMessage("");
                showPanel(pnlMenu);
            }
            else
            {
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
            }
        }

        //logs out
        public void logOut()
        {
            updateMessage("Tot ziens!");
            Thread.Sleep(2000);

            _enterPassword = false;
            _validPass = false;
            _loggedOut = true;
            _enteredPassword = string.Empty;
            
            myPort.WriteLine("R");
            UpdateForm();
            updateText("");
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
        private async void addItemsToDropDown(int pAmount)
        {
            cmbChooseBill.Items.Clear();

            for (int i = 0; i < bill.Length; i++)
            {
                // gets the amount of the chosen bill 
                int amount = await _httpRequest.httpGetRequest($"BillItems/{bill[i]}");

                // if there is enough
                if (pAmount >= bill[i] && amount > 0)
                {
                    cmbChooseBill.Items.Add($"R{bill[i]}");
                }
            }

            // if there is no bill option
            if (cmbChooseBill.Items.Count < 1)
                cmbChooseBill.Items.Add("Geen biljet beschikbaar.");
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

            // if a pass is entered
            if (serialInput.Contains("nuid{"))
            {
                String nuidResult = stripString("nuid{", "}", serialInput);
                nuidResult = nuidResult.Replace(" ","");

                _currentClientIban = nuidResult.Trim();

                // some times it fails to read the pass correct
                if (_currentClientIban.Contains("failed") || _currentClientIban.Contains("?"))
                {
                    updateMessage("Uw pas is niet goed uitgelezen...");
                    myPort.Write("R");
                    Thread.Sleep(2000);
                    logOut();
                    myPort.DiscardInBuffer();
                    myPort.DiscardOutBuffer();
                }
                else
                {
                    nuidValidation(_currentClientIban);
                    myPort.DiscardInBuffer();
                    myPort.DiscardOutBuffer();
                }
            }
            else if (serialInput.Contains("pw{"))
            {
                // if the user typed the password

                String pwResult = stripString("pw{", "}", serialInput);

                // checks if the password is vald
                if (!string.IsNullOrEmpty(pwResult) && !_validPass)
                {
                    checkPasswordValidation(pwResult);
                }
                else
                {
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
            // the panels are used as frames to be shown to the user
            Panel[] pnlList = { pnlMenu, pnlOtherTransaction, pnlSaldo, pnlTransaction, pnlBack, pnlChooseBill, pnlReceipt };

            // finds the panel which has to shown
            foreach (Panel panel in pnlList)
            {
                panel.Visible = false;

                if (pPanel != null)
                {
                    if (pPanel.Equals(pnlTransaction) || pPanel.Equals(pnlOtherTransaction))
                        pnlChooseBill.Visible = true;
                }

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
            logOut();
        }

        //execute a transaction
        private void btnTransaction_Click(object sender, EventArgs e)
        {
            showPanel(pnlTransaction);
        }

        //returns the saldo of the currentuser
        private async void btnGetSaldo_Click(object sender, EventArgs e)
        {
            showPanel(pnlSaldo);
            // gets the clients saldo
            tbUserSaldo.Text = $"R{await _httpRequest.httpGetRequest($"ClientSaldo/{_currentClientIban}")}";
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            // checks if the user only entered numbers
            CheckValidUserInput check = new CheckValidUserInput();
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                if(check.validInput(tbAmount.Text, true))
                {
                    try
                    {
                        addItemsToDropDown(Convert.ToInt32(tbAmount.Text));
                    }
                    catch (OverflowException ex)
                    {
                        updateMessage("Te groot getal... niet doen aub :)");
                        Thread.Sleep(2000);
                    }
                }
            }
        }

        private void BtnOtherTransaction_Click(object sender, EventArgs e)
        {
            showPanel(pnlOtherTransaction);
        }

        private void BtnExeOtherTransaction_Click(object sender, EventArgs e)
        {
            // checks if all the inputs are valid
            if (!string.IsNullOrWhiteSpace(cmbChooseBill.Text))
            {
                if (_Amount == 0 || string.IsNullOrWhiteSpace(cmbChooseBill.Text))
                {
                    if (_Amount == 0 && string.IsNullOrWhiteSpace(tbAmount.Text))
                    {
                        updateMessage("Graag al de velden invullen");
                    }
                    else
                    {
                        showPanel(pnlReceipt);
                    }
                }
                else
                {
                    showPanel(pnlReceipt);
                }
            }
            else
            {
                updateMessage("Kies ook een biljet");
            }

        }

        // btn 10, 50, 100 -> fast transaction buttons
        private void Btn10_Click(object sender, EventArgs e)
        {
            _Amount = 10;
            addItemsToDropDown(_Amount);
        }

        private void Btn50_Click(object sender, EventArgs e)
        {
            _Amount = 20;
            addItemsToDropDown(_Amount);
        }

        private void Btn100_Click(object sender, EventArgs e)
        {
            _Amount = 50;
            addItemsToDropDown(_Amount);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            showPanel(pnlMenu);
            updateMessage("");
        }

        private void BtnOtherUserValidation_Click(object sender, EventArgs e)
        {
          // used for debugging  
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //APICentraleBankConnection f = new APICentraleBankConnection();
        }

        private void BtnReceiptyes_Click(object sender, EventArgs e)
        {
            // prints the receipt & executes the transaction
            _wantReceipt = true;

            if (tbAmount.Text == string.Empty)
                transaction(_Amount.ToString(), cmbChooseBill.Text);
            else
                transaction(tbAmount.Text, cmbChooseBill.Text);
            tbAmount.Text = string.Empty;
            logOut();
        }

        private void BtnReceiptNo_Click(object sender, EventArgs e)
        {
            // doesnt print and executes the transaction
            _wantReceipt = false;

            if (tbAmount.Text == string.Empty)
                transaction(_Amount.ToString(), cmbChooseBill.Text);
            else
                transaction(tbAmount.Text, cmbChooseBill.Text);
            tbAmount.Text = string.Empty;
            logOut();
        }

        private void BtnFastTransaction_Click(object sender, EventArgs e)
        {
            transaction(50.ToString(), 50.ToString());
            Thread.Sleep(2000);
            logOut();
        }
        #endregion

        private void DeBank_Shown(object sender, EventArgs e)
        {
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            APICentraleBankConnection f = new APICentraleBankConnection();
            f.Show();
            button1.Visible = false;
        }

        private void DeBank_FormClosing(object sender, FormClosingEventArgs e)
        {
            // closes all the open ports    
            if (myPort.IsOpen)
            {
                myPort.Close();
            }

            if (spMoneyDispenser.IsOpen)
            {
                myPort.Close();
            }
        }
    }
}
