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

        //the userTagId
        String _userTagId = String.Empty;

        //user NUID
        private String _currentClientNuid = String.Empty;

        //booleans for validation of the password
        bool _validPass = false;
        bool _loggedOut = false;
        bool _executeTransaction = false;

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
            }
            else if (returnedObject.StatusCode == 0)//if the pass exists and is not blocked
            {
                _httpRequest = new HttpRequest("ClientItems", _userTagView.UserTagId.ToString());
                _currentClient = await HttpRequest.GetClientAsync(_httpRequest.createUrl());

                //sends command to arduino to read the keypad
                myPort.WriteLine("P");
                _loggedOut = false;
                //update the shown text on screen
                updateText(_currentClient);
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
                UpdateForm(_currentClient);
            }
        }

        //checks if the user entered a valid password
        private async void checkPasswordValidation(String pPassword)
        {
            ClientPasswordCheck checkPass = new ClientPasswordCheck();

            //validates the password
            _validPass = await checkPass.validatePassword(pPassword, _currentClientNuid);

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
                updateText(_currentClient);
            }
        }

        //updates the label text
        public void updateText(Client pClient)
        {
            //update the label text
            if (InvokeRequired)
            {
                this.Invoke(new Action<Client>(updateText), new object[] { pClient });
                return;
            }

            if (_loggedOut)
            {
                lblWelcome.Text = "Welkom, houd uw pas voor de reader.";
            }
            else
            {
                lblWelcome.Text = "Graag uw wachtwoord invoeren op het keypad " + pClient?.Name;
            }

        }

        //shows the transaction form
        private void transaction()
        {
            _executeTransaction = true;
            UpdateForm(_currentClient);
            using (FormTransaction formTransaction = new FormTransaction(_currentClient, _transaction, _userTagView))
            {
                if (formTransaction.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
            _executeTransaction = false;
            UpdateForm(_currentClient);
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
                lblWelcome.Visible = false;
                btnCancel.Visible = false;
                grpbLoggedIn.Visible = true;
            }
            else
            {
                btnCancel.Visible = true;
                grpbLoggedIn.Visible = false;
                lblWelcome.Visible = true;
            }

            if (_executeTransaction)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
            }

            tbLoggedInUser.Text = pClient.Name;
        }

        //logs out
        private void logOut()
        {
            _validPass = false;
            _loggedOut = true;

            _enteredPassword = string.Empty;
            lblWelcome.Text = "Welkom hou u pas voor de cardreader";

            UpdateForm(_currentClient);
            btnCancel.Visible = false;

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

                checkPasswordValidation(pwResult);
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


        #endregion
    }
}
