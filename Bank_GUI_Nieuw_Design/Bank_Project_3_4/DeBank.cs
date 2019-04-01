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
        Client _currentClient;//the currentclient
        HttpRequest _httpRequest;
        UserTagViewModel _userTagView;
        Transaction _transaction;


        private string serialInput;//incoming data is stored in String rxString

        //the password strings
        String _enteredPassword = string.Empty;
        String _readPass = string.Empty;
        String _lblPincodeText = string.Empty;


        //the userTagId
        String _userTagId = String.Empty;

        //user NUID
        private String _currentClientNuid = String.Empty;

        //booleans for validation of the password
        bool _validPass = false;
        bool _loggedOut = false;
        bool _enterPassword = false;

        private int[] bill = { 5, 10, 20, 50, 100, 200, 500 };

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
            myPort.Open();
            myPort.WriteLine("R");
            myPort.WriteLine("R");

            //the default bills
            cmbChooseBill.Items.Add("€5");
            cmbChooseBill.Items.Add("€10");
            cmbChooseBill.Items.Add("€20");
            cmbChooseBill.Items.Add("€50");
            cmbChooseBill.Items.Add("€100");
            cmbChooseBill.Items.Add("€200");
            cmbChooseBill.Items.Add("€500");
        }

        

        //===================\\
        //   The functions   \\
        //===================\\
        #region Functions

        //checks if the entered nuid exists
        private async void nuidValidation(String pNuid)
        {
            _httpRequest = new HttpRequest("UserTagItems", pNuid);
            ReturnObject returnedObject = await HttpRequest.GetUserTagAsync(_httpRequest.createUrl());
            _userTagView = returnedObject.ReturnUserTag;

            if (returnedObject.StatusCode == 3)//if pass does not exist
            {
                //the new client
                UserTag newUserTag = new UserTag { PassId = pNuid };
                Client newClient = new Client();
                _currentClient = newClient;

                //opens a new form to add the new user
                using (SetClientDialogBox clientForm = new SetClientDialogBox(_currentClient, newUserTag))
                {
                    //opens a new form to add the new client to the database
                    if (clientForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        myPort.WriteLine("R");
                    }
                }
                _enterPassword = false;
                UpdateForm(null);
            }
            else if (returnedObject.StatusCode == 0)//if the pass exists and is not blocked
            {
                _httpRequest = new HttpRequest("ClientItems", _userTagView.UserTagId.ToString());
                _currentClient = await HttpRequest.GetClientAsync(_httpRequest.createUrl());

                //sends command to arduino to read the keypad
                myPort.WriteLine("P");
                _loggedOut = false;
                //update the shown text on screen
                updateText(_currentClient, "");
            }
            else if (returnedObject.StatusCode == 2)//the user pass is blocked
            {
                //error, pass is blocked
                Helper.showMessage("Helaas, Uw pas is geblokkeerd", MessageBoxIcon.Error);
                myPort.WriteLine("R");
            }
            //update the form
            if (_currentClient != null)
            {
                _enterPassword = true;
                UpdateForm(_currentClient);
            }
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
                updateText(null, _lblPincodeText);
                _lblPincodeText = string.Empty;
            }
            else if (pPassword == "*")
            {
                
                _enteredPassword = _enteredPassword.Remove(_enteredPassword.Length - 1);
                updateText(null, "<>");
            }
            else if(pPassword == "#")
            {
                //validates the password
                _validPass = await checkPass.validatePassword(_enteredPassword, _currentClientNuid);

                //if the password is correct
                if (_validPass)
                {
                    //updates the form
                    UpdateForm(_currentClient);
                    //reset the invalid password counter
                }
                else
                {
                    Helper.showMessage("Uw wachtwoord is incorrect, probeer het alstublieft opnieuw. \n\n 1) lees uw pas in \n 2) voer uw wachtwoord in", MessageBoxIcon.Information);
                    myPort.Write("R");
                    _loggedOut = true;
                    _enterPassword = false;
                    UpdateForm(null);
                    updateText(_currentClient, "");
                }
                _enteredPassword = string.Empty;
            }
            
        }

        //updates the label text
        public void updateText(Client pClient, String pInput)
        {
            //update the label text
            if (InvokeRequired)
            {
                this.Invoke(new Action<Client, String>(updateText), new object[] { pClient, pInput });
                return;
            }

            if (_loggedOut)
            {
                lblWelcome.Text = "Welkom, houd uw pas voor de reader.";
                //_userControl.WelcomeLabel("Welkom, houd uw pas voor de reader");
            }
            else
            {
                lblWelcome.Text = "Graag uw pincode invoeren op het keypad ";

                if (pInput == "<>")
                {
                    _lblPincodeText = lblPinCode.Text.Substring(4);
                    _lblPincodeText = _lblPincodeText.Remove(_lblPincodeText.Length - 1);
                    lblPinCode.Text = $"PIN:{_lblPincodeText}";
                    _lblPincodeText = string.Empty;
                }
                else
                {
                    lblPinCode.Text += pInput;
                }
                //_userControl.WelcomeLabel("Graag uw pincode invoeren op het keypad");
            }
        }

        //shows the transaction form
        private void transaction()
        {
            //FormTransaction newTransaction = new FormTransaction(_currentClient, _transaction, _userTagView);
            //newTransaction.transaction();

            ExecuteTransaction exeTransaction = new ExecuteTransaction(_currentClient, _transaction, _userTagView);
            exeTransaction.executeTransaction(cmbChooseBill.Text, tbAmount.Text);

            if (!string.IsNullOrEmpty(tbAmount.Text) || !string.IsNullOrEmpty(cmbChooseBill.Text))
            {
                rtbReceipt.Text = exeTransaction.printReceipt();

                if (exeTransaction._tSuccesfull)
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
            }            
        }

        //updates the text and visibility of the form
        public void UpdateForm(Client pClient)//show client data
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Client>(UpdateForm), new object[] { pClient });
                return;
            }

            if (_validPass)
            {
                _enterPassword = false;
                lblWelcome.Visible = false;
                rtbReceipt.Visible = true;
                grpbLoggedIn.Visible = true;
            }
            else
            {
                lblWelcome.Visible = true;
                rtbReceipt.Visible = false;
                grpbLoggedIn.Visible = false;
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
        private void logOut()
        {
            _enterPassword = false;
            _validPass = false;
            UpdateForm(_currentClient);
            _loggedOut = true;
            _enteredPassword = string.Empty;
            rtbReceipt.Text = "";

            updateText(null, "");
            
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

        #endregion


        //=====================\\
        //   The Formbuttons   \\
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

                _currentClientNuid = nuidResult;
                nuidValidation(nuidResult);
            }
            else if (serialInput.Contains("pw{"))
            {
                String pwResult = stripString("pw{", "}", serialInput);

                if (!string.IsNullOrEmpty(pwResult))
                {
                    checkPasswordValidation(pwResult);
                }
            }
        }

        //debug button
        private void btnReset_Click(object sender, EventArgs e)
        {
            myPort.WriteLine("R");
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
            transaction();
        }

        //returns the saldo of the currentuser
        private void btnGetSaldo_Click(object sender, EventArgs e)
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(_currentClient, _userTagId);
            tbUserSaldo.Text = "€ " + Convert.ToString(checkSaldo.getSaldo());//get the saldo of the current client
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            CheckValidUserInput check = new CheckValidUserInput(_currentClient);
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                if(check.validInput(tbAmount.Text, true))
                {
                    addItemsToDropDown(Convert.ToInt32(tbAmount.Text));
                }
            }
        }


        #endregion

        private void pnlWelcome_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
