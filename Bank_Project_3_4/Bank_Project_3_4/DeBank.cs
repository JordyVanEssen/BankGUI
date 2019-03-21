﻿using System;
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
using BankDataLayer;

/*
    - Author: Jordy van Essen | 0968981
    - Date: 01-03-2019
*/
namespace Bank_Project_3_4
{
    public partial class DeBank : Form
    {
        SerialPort myPort = new SerialPort();//create a serial port
        Client _newClient;
        Client _currentClient;//the currentclient
        UserTag _newUserId;
        Transaction _transaction;
        ClientContext _db;
        PrintReceipt _print;
        CheckValidUserInput _checkInput;

        Boolean _receipt = false;

        private string rxString;//incoming data is stored in String rxString

        //the password strings
        String enteredPassword = string.Empty;
        String readPass = string.Empty;

        //booleans for validation of the password
        bool waitForPass = false;
        bool validPass = false;

        bool addedClient = false;
        bool loggedOut = false;
        //keeps track of the tries
        int invalidPassCount = 0;



        public DeBank()
        {
            InitializeComponent();
        }

        //when the form is loaded the following will be executed:
        private void DeBank_Load(object sender, EventArgs e)
        {
            myPort.BaudRate = 9600;
            myPort.PortName = "COM3";
            myPort.DataReceived += MyPort_DataReceived;
            myPort.Open();
            myPort.WriteLine("R");

            _db = new ClientContext();
        }

        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //the password is by default false
            validPass = false;

            //reads the incoming serial data
            rxString = myPort.ReadLine();

            //filters the rubish out of the strings
            if (!rxString.Contains("VM") && waitForPass == false)
            {
                var result = _db.userTags.FirstOrDefault(x => x.PassId == rxString);//checks if the pass ID exists
                if (result == null)//if pass does not exist
                {
                    //the new client
                    var newClient = new UserTag { PassId = rxString };
                    _currentClient = createNewClient(newClient);

                    using (SetClientDialogBox clientForm = new SetClientDialogBox(_currentClient, _db, newClient))
                    {
                        //opens a new form to add the new client to the database
                        if (clientForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            myPort.WriteLine("R");
                        }
                    }
                    //the current client
                    addedClient = true;
                }
                else
                {
                    _currentClient = _db.Clients.FirstOrDefault(x => x.ClientId == result.UsertagId);//searches for matching id's

                    _newUserId = result;
                    addedClient = false;

                    if (_newUserId.PassBlocked == false)
                    {
                        myPort.WriteLine("P");
                        //MessageBox.Show($"Graag uw wachtwoord invullen op het keypad: " + _currentClient.Name, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loggedOut = false;
                        updateText(_currentClient);

                        while (true)
                        {
                            System.Threading.Thread.Sleep(1000);
                            enteredPassword = myPort.ReadExisting();
                            if (enteredPassword.Contains("pass"))
                            {
                                break;
                            }
                        }

                        //readPass = myPort.ReadLine();
                        readPass = enteredPassword.Substring(enteredPassword.IndexOf('p'));

                        waitForPass = true;
                    }
                    else
                    {
                        MessageBox.Show("Uw pas is geblokkeerd", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                UpdateForm(_currentClient);

                //result is a Client
            }

            if (readPass.Contains("pass") && waitForPass)
            {
                ClientPasswordCheck checkPass = new ClientPasswordCheck(_newUserId);
                readPass.Replace("pass", null);
                readPass = readPass.Substring(readPass.IndexOf('s') + 2);
                readPass = readPass.Trim();

                validPass = checkPass.validatePassword(readPass);
            }
                

            if (validPass && waitForPass)
            {
                UpdateForm(_currentClient);

                //myPort.WriteLine("R");//reset the 'sentPassID' value on the arduino
                //validPass = false;
                invalidPassCount = 0;

                _newUserId.PassBlocked = false;
                _db.SaveChanges();//update new saldo
            }
            else
            {
                if (!addedClient && !_newUserId.PassBlocked)
                {
                    invalidPassCount += 1;
                    if (invalidPassCount > 3)
                    {
                        MessageBox.Show("Uw pas is geblokkeerd");

                        _newUserId.PassBlocked = true;
                        _db.SaveChanges();
                    }
                    else
                    {
                        waitForPass = false;
                        MessageBox.Show("Uw wachtwoord is incorrect, probeer het alstublieft opnieuw. \n 1) lees uw pas in \n 2) voer uw wachtwoord in");
                    }
                }

                myPort.WriteLine("R");
            }
        }

        private Client createNewClient(UserTag pNewClient)
        {
            Client newClient = new Client();

            newClient.UserTagId = pNewClient.UsertagId;

            return newClient;
        }

        public void updateText(Client pClient)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Client>(updateText), new object[] { pClient });
                return;
            }
            if (loggedOut)
            {
                lblWelcome.Text = "Welkom, hou uw pas voor de reader.";
            }
            else
            {
                lblWelcome.Text = "Graag uw wachtwoord invoeren op het keypad " + pClient.Name;
            }

        }

        private void inputErrorMsg(bool pInput)
        {
            if (!pInput)
            {
                if (!_checkInput.validUserInput && _checkInput.inputLength == 4)
                {
                    Helper.showMessage("U mag alleen getallen invoeren ", MessageBoxIcon.Error);
                }
                else if (_checkInput.inputLength < 4 || _checkInput.inputLength > 4)
                {
                    Helper.showMessage("U mag alleen een getal invoeren wat maximaal bestaat uit 4 karakters. Nu heeft u er: " + _checkInput.inputLength, MessageBoxIcon.Error);
                }
                else
                {
                    Helper.showMessage("Gelieve AL de velden invullen.", MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateForm(Client pClient)//show client data
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Client>(UpdateForm), new object[] { pClient });
                return;
            }

            if (validPass)
            {
                lblWelcome.Visible = false;
                grpbUserInterface.Visible = true;
            }
            else
            {
                grpbUserInterface.Visible = false;
                lblWelcome.Visible = true;
            }

            if (_receipt)
            {
                loadReceipt();
                lblWelcome.Visible = false;
                grpbUserInterface.Visible = true;
                _receipt = false;
            }
            else
            {
                loadClients();
            }

            tbLoggedInUser.Text = pClient.Name;
        }

        private void createReceipt(double pOldSaldo, double pNewSaldo, string pMode)
        {
            _transaction = new Transaction { Mode = pMode };
            DateTime now = DateTime.Now;

            _transaction.ClientId = _currentClient.ClientId;
            _transaction.Name = _currentClient.Name;
            _transaction.OldSaldo = pOldSaldo;
            _transaction.NewSaldo = pNewSaldo;
            _transaction.Time = now;
            _transaction.Mode = pMode;

            _db.Transactions.Add(_transaction);
            _db.SaveChanges();
        }

        private void loadReceipt()//shows the transaction on screen
        {
            ClientViewModel cv = new ClientViewModel(_db);
            dgvReceipt.DataSource = cv.GetTransactions(_currentClient.ClientId);
            dgvReceipt.AutoGenerateColumns = true;
        }

        private void loadClients()//show the client database on screen
        {
            ClientViewModel cv = new ClientViewModel(_db);
            dgvClient.DataSource = cv.GetClients();
            dgvClient.AutoGenerateColumns = true;
        }

        private void DeBank_Shown(object sender, EventArgs e)//show all clients a bit after the form loaded
        {
            loadClients();
        }

        private void btnGetSaldo_Click(object sender, EventArgs e)//if button is pressed
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(_currentClient, _db);
            tbUserSaldo.Text = Convert.ToString(checkSaldo.getSaldo());//get the saldo of the current client
        }

        private void btnWithdraw_Click(object sender, EventArgs e)//if button is pressed
        {
            bool input = false;
            bool validInput = false;
            double amount = Convert.ToDouble(tbWithdrawMoney.Text);
            double oldSaldo = _currentClient.Saldo;
            bool tSuccesfull = false;//transaction succesfull

            if (!string.IsNullOrWhiteSpace(tbWithdrawMoney.Text))
            {
                input = true;
                Withdraw withDrawel = new Withdraw(_currentClient, _newUserId, amount, _db);
                tSuccesfull = withDrawel.withdrawMoney();//withdraw money
            }
            else
            {
                Helper.showMessage("Graag al de velden invullen.", MessageBoxIcon.Error);
            }

            if (tSuccesfull)
            {
                createReceipt(oldSaldo, _currentClient.Saldo, "Withdrawel");

                _receipt = true;
                UpdateForm(_currentClient);
                btnPrintReceipt.Visible = true;

                _print = new PrintReceipt(_transaction, _currentClient);
                rtbReceipt.Text = _print.print();
                Helper.showMessage("Transactie geslaagd");
            }
            else
            {
                if (amount > _currentClient.Saldo)
                {
                    Helper.showMessage("Transactie mislukt. U hebt niet genoeg saldo.", MessageBoxIcon.Error);
                }
                else
                {
                    Helper.showMessage("Transactie mislukt. Controleer of u alleen getallen hebt ingevoerd.", MessageBoxIcon.Error);
                }
            }

            //validInput = _checkInput.validInput(tbWithdrawMoney.Text, input);

            //if (validInput)
            //{
                
            //}
            //else
            //{
            //    inputErrorMsg(validInput);
            //}
        }

        private void btnDeposit_Click(object sender, EventArgs e)//if button is pressed
        {
            bool input = false;
            bool validInput = false;
            double amount = Convert.ToDouble(tbDepositMoney.Text);
            double oldSaldo = 0;
            bool tSuccesfull = false;//transaction succesfull

            if (!string.IsNullOrWhiteSpace(tbDepositMoney.Text))
            {
                input = true;
                Deposit depositMoney = new Deposit(_currentClient, amount, _db);
                tSuccesfull = depositMoney.deposit();//deposit money

                if (amount > _currentClient.Saldo)
                {
                    oldSaldo = amount - _currentClient.Saldo;
                }
                else
                {
                    oldSaldo = _currentClient.Saldo - amount;
                }

                if (tSuccesfull)
                {
                    createReceipt(oldSaldo, _currentClient.Saldo, "Deposit");

                    _receipt = true;
                    UpdateForm(_currentClient);
                    btnPrintReceipt.Visible = true;

                    _print = new PrintReceipt(_transaction, _currentClient);
                    rtbReceipt.Text = _print.print();

                    Helper.showMessage("Transactie geslaagd");
                }
                else
                {
                    Helper.showMessage("Transactie mislukt", MessageBoxIcon.Error);
                }
            }
            else
            {
                Helper.showMessage("Graag al de velden invullen", MessageBoxIcon.Error);
            }
            
            
            //validInput = _checkInput.validInput(tbDepositMoney.Text, input);

            //if (validInput)
            //{
               
                
               
            //}
            //else
            //{
            //    inputErrorMsg(validInput);
            //}

           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            myPort.WriteLine("R");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            validPass = false;
            waitForPass = false;
            loggedOut = true;

            enteredPassword = string.Empty;
            lblWelcome.Text = "";
            rtbReceipt.Text = "";
            dgvReceipt.DataSource = null;

            UpdateForm(_currentClient);

            myPort.WriteLine("R");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new ClientContext())
            {
                // Create and save a new Blog

                var trans = new Transaction {  };
                db.Transactions.Add(trans);
                db.SaveChanges();

                // Display all Blogs from the database
                //var query = from b in db.Clients
                //            orderby b.Name
                //            select b;
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            _print = new PrintReceipt(_transaction, _currentClient);
            rtbReceipt.Text = _print.print();
        }
    }
}
