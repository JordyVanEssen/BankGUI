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
        Client _currentClient;//the currentclient
        Transaction _transaction;
        ClientContext _db;
        Boolean _receipt = false;

        private string rxString;//incoming data is stored in String rxString

        //the password strings
        String enteredPassword = string.Empty;
        String readPass = string.Empty;

        //booleans for validation of the password
        bool waitForPass = false;
        bool validPass = false;

        bool addedClient = false;

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
                var result = _db.Clients.FirstOrDefault(x => x.PassId == rxString);//checks if the pass ID exists
                if (result == null)//if pass does not exist
                {
                    //the new client
                    result = new Client { PassId = rxString };

                    using (SetClientDialogBox clientForm = new SetClientDialogBox(result, _db))
                    {
                        //opens a new form to add the new client to the database
                        if (clientForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            myPort.WriteLine("R");
                        }
                    }
                    //the current client
                    _currentClient = result;
                    addedClient = true;
                }
                else
                {
                    _currentClient = result;
                    addedClient = false;

                    if (_currentClient.PassBlocked == false)
                    {
                        myPort.WriteLine("P");
                        //MessageBox.Show($"Graag uw wachtwoord invullen op het keypad: " + _currentClient.Name, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                UpdateForm(result);

                //result is a Client
            }

            if (readPass.Contains("pass") && waitForPass)
            {
                ClientPasswordCheck checkPass = new ClientPasswordCheck(_currentClient);
                readPass.Replace("pass", null);
                readPass = readPass.Substring(readPass.IndexOf('s') + 2);
                readPass = readPass.Trim();

                validPass = checkPass.validatePassword(readPass);
            }
                

            if (validPass && waitForPass)
            {
                UpdateForm(_currentClient);

                //myPort.WriteLine("R");//reset the 'sentPassID' value on the arduino
                validPass = false;
                invalidPassCount = 0;

                _currentClient.PassBlocked = false;
                _db.SaveChanges();//update new saldo
            }
            else
            {
                if (!addedClient && !_currentClient.PassBlocked)
                {
                    invalidPassCount += 1;
                    if (invalidPassCount > 3)
                    {
                        MessageBox.Show("Uw pas is geblokkeerd");

                        _currentClient.PassBlocked = true;
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

        public void updateText(Client pClient)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Client>(updateText), new object[] { pClient });
                return;
            }

            lblWelcome.Text = "Graag uw wachtwoord invoeren op het keypad " + pClient.Name;
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
                _receipt = false;
            }
            else
            {
                loadClients();
            }

            tbLoggedInUser.Text = pClient.Name;
        }

        private void createReceipt(double pOldSaldo, double pNewSaldo)
        {
            _transaction = new Transaction { Name = _currentClient.Name };
            DateTime now = DateTime.Now;

            _transaction.OldSaldo = pOldSaldo;
            _transaction.NewSaldo = pNewSaldo;
            _transaction.Time = now;

            _db.Transactions.Add(_transaction);
            _db.SaveChanges();
        }

        private void loadReceipt()//shows the transaction on screen
        {
            ClientViewModel cv = new ClientViewModel(_db);
            dgvReceipt.DataSource = cv.GetTransactions();
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
            CheckUserSaldo checkSaldo = new CheckUserSaldo(_currentClient.PassId, _db);
            tbUserSaldo.Text = Convert.ToString(checkSaldo.getSaldo());//get the saldo of the current client
        }

        private void btnWithdraw_Click(object sender, EventArgs e)//if button is pressed
        {
            if (!string.IsNullOrEmpty(tbWithdrawMoney.Text))
            {
                double amount = Convert.ToDouble(tbWithdrawMoney.Text);
                Withdraw withDrawel = new Withdraw(_currentClient, amount, _db);
                withDrawel.withdrawMoney();//withdraw money

                createReceipt(amount, _currentClient.Saldo);

                _receipt = true;
            }
            else
            {
                MessageBox.Show("Graag het veld invullen", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateForm(_currentClient);
        }

        private void btnDeposit_Click(object sender, EventArgs e)//if button is pressed
        {
            if (!string.IsNullOrEmpty(tbDepositMoney.Text))
            {
                double amount = Convert.ToDouble(tbDepositMoney.Text);
                Deposit depositMoney = new Deposit(_currentClient, amount, _db);
                depositMoney.deposit();//deposit money

                createReceipt(amount, _currentClient.Saldo);

                _receipt = true;
            }
            else
            {
                MessageBox.Show("Graag het veld invullen", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateForm(_currentClient);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            myPort.WriteLine("R");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            validPass = false;
            waitForPass = false;
            enteredPassword = string.Empty;
            myPort.WriteLine("R");
            UpdateForm(_currentClient);
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
    }
}
