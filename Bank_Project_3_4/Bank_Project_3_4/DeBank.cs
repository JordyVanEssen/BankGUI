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

/*
    - Author: Jordy van Essen | 0968981
    - Date: 01-03-2019
*/
namespace Bank_Project_3_4
{
    public partial class DeBank : Form
    {
        //instances 
        SerialPort myPort = new SerialPort();//create a serial port
        Client _currentClient;//the currentclient
        UserTag _newUserId;
        Transaction _transaction;
        ClientContext _db;
        PrintReceipt _print;
        CheckValidUserInput _checkInput;

        bool _receipt = false;

        private string rxString;//incoming data is stored in String rxString

        //the password strings
        String _enteredPassword = string.Empty;
        String _readPass = string.Empty;

        //booleans for validation of the password
        bool _waitForPass = false;
        bool _validPass = false;
        bool _addedClient = false;
        bool _loggedOut = false;
        bool _clearInput = false;
        //keeps track of the tries
        int _invalidPassCount = 0;

        //+the controller + parameters, https://localhost:44396/api/UsertagItems/1
        String apiUrl = "https://localhost:44396/api/";
        private static readonly HttpClient httpClient = new HttpClient();


        public DeBank()
        {
            InitializeComponent();
        }

        //when the form is loaded the following will be executed:
        private void DeBank_Load(object sender, EventArgs e)
        {
            //setup the serial port
            myPort.BaudRate = 9600;
            myPort.PortName = "COM3";
            myPort.DataReceived += MyPort_DataReceived;
            myPort.Open();
            myPort.WriteLine("R");

            //the database
            _db = new ClientContext();
        }

        private async void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //the password is by default false
            _validPass = false;

            //reads the incoming serial data
            rxString = myPort.ReadLine();

            //filters the rubish out of the strings
            if (!rxString.Contains("VM") && _waitForPass == false)
            {
                //var result = _db.UserTags.FirstOrDefault(x => x.PassId == rxString);//checks if the pass ID exists
                var result = await GetClientAsync(apiUrl + "UserTagItems/" + rxString);
                if (result == null)//if pass does not exist
                {
                    //the new client
                    var newClient = new UserTag { PassId = rxString };
                    _db.SaveChanges();
                    _currentClient = createNewClient(newClient);

                    //opens a new form to add the new user
                    using (SetClientDialogBox clientForm = new SetClientDialogBox(_currentClient, _db, newClient))
                    {
                        //opens a new form to add the new client to the database
                        if (clientForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            myPort.WriteLine("R");
                        }
                    }
                    //the client is added
                    _addedClient = true;
                }
                else
                {
                    //searches for matching id's
                    _currentClient = _db.Clients.FirstOrDefault(x => x.ClientId == result.UsertagId);

                    //the logged in user
                    _newUserId = result;
                    _addedClient = false;

                    checkPassIdBlocked();
                }
                //update the form
                UpdateForm(_currentClient);
            }
            //password validation
            checkPasswordValidation();
        }

        //===============\\
        // The functions \\
        //===============\\

        //checks if the pass of the user is blocked
        private void checkPassIdBlocked()
        {
            if (_newUserId.PassBlocked == false)
            {
                //sends command to arduino to read the keypad
                myPort.WriteLine("P");
                _loggedOut = false;
                //update the shown text on screen
                updateText(_currentClient);

                while (true)
                {
                    //keeps waiting for the arduino to send the password
                    System.Threading.Thread.Sleep(1000);
                    _enteredPassword = myPort.ReadExisting();
                    if (_enteredPassword.Contains("pass"))
                    {
                        break;
                    }
                }

                //strips all the rubish out of the input, so the input is: 'pass[password]'
                _readPass = _enteredPassword.Substring(_enteredPassword.IndexOf('p'));
                _waitForPass = true;
            }
            else
            {
                //error, pass is blocked
                MessageBox.Show("Uw pas is geblokkeerd", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //checks if the user entered a valid password
        private void checkPasswordValidation()
        {
            //the password
            if (_readPass.Contains("pass") && _waitForPass)
            {
                ClientPasswordCheck checkPass = new ClientPasswordCheck(_newUserId);
                _readPass.Replace("pass", null);
                _readPass = _readPass.Substring(_readPass.IndexOf('s') + 2);
                _readPass = _readPass.Trim();

                //validates the password
                _validPass = checkPass.validatePassword(_readPass);
            }

            //if the password is correct
            if (_validPass && _waitForPass)
            {
                //updates the form
                UpdateForm(_currentClient);

                //reset the invalid password counter
                _invalidPassCount = 0;
                _newUserId.PassBlocked = false;
                //saves the changes made in the database
                _db.SaveChanges();
            }
            else
            {
                //if the password is incorrect
                if (!_addedClient && !_newUserId.PassBlocked)
                {
                    _invalidPassCount += 1;
                    if (_invalidPassCount > 3)
                    {
                        //the pass is blocked
                        MessageBox.Show("Uw pas is geblokkeerd");

                        _newUserId.PassBlocked = true;
                        _db.SaveChanges();
                    }
                    else
                    {
                        _waitForPass = false;
                        MessageBox.Show("Uw wachtwoord is incorrect, probeer het alstublieft opnieuw. \n 1) lees uw pas in \n 2) voer uw wachtwoord in");
                    }
                }
                //reset arduino
                myPort.WriteLine("R");
            }
            
        }

        //creates a new client after the passId is read
        private Client createNewClient(UserTag pNewClient)
        {
            //create a new empty client
            Client newClient = new Client();
            newClient.UserTagId = pNewClient.UsertagId;
            _db.SaveChanges();
            return newClient;
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
                lblWelcome.Text = "Welkom, hou uw pas voor de reader.";
            }
            else
            {
                lblWelcome.Text = "Graag uw wachtwoord invoeren op het keypad " + pClient.Name;
            }

        }

        //error message if the input is invalid
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

        //updates the text and visibility of the form
        public void UpdateForm(Client pClient)//show client data
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Client>(UpdateForm), new object[] { pClient });
                return;
            }

            if(_clearInput)
            {
                tbDepositMoney.Text = "";
                tbUserSaldo.Text = "";
                tbWithdrawMoney.Text = "";
                _clearInput = false;
            }

            if (_validPass)
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

        //creates the receipt
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

        //shows the receipt table on screen
        private void loadReceipt()
        {
            ClientViewModel cv = new ClientViewModel(_db);
            dgvReceipt.DataSource = cv.GetTransactions(_currentClient.ClientId);
            dgvReceipt.AutoGenerateColumns = true;
        }

        //shows all the clients on screen
        private void loadClients()
        {
            ClientViewModel cv = new ClientViewModel(_db);
            dgvClient.DataSource = cv.GetClients();
            dgvClient.AutoGenerateColumns = true;
            loadUsertag();
        }

        //shows all the usertags on screen
        private void loadUsertag()
        {
            ClientViewModel cv = new ClientViewModel(_db);
            dgvUserTag.DataSource = cv.GetUsertag();
            dgvUserTag.AutoGenerateColumns = true;
        }

        //show all clients a bit after the form loaded
        private void DeBank_Shown(object sender, EventArgs e)
        {
            loadClients();
        }

        //call the api to get the client
        static async Task<UserTag> GetClientAsync(string path)
        {
            UserTag user = null;
            HttpResponseMessage response = await httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserTag>();
            }
            return user;
        }

        //=============\\
        // The buttons \\
        //=============\\

        //returns the saldo in a textbox
        private void btnGetSaldo_Click(object sender, EventArgs e)
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(_currentClient, _db);
            tbUserSaldo.Text = Convert.ToString(checkSaldo.getSaldo());//get the saldo of the current client
        }

        //withdraws the money entered in the textbox by the user
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            bool input = false;
            bool validInput = false;
            double amount = Convert.ToDouble(tbWithdrawMoney.Text);
            double oldSaldo = _currentClient.Saldo;
            bool tSuccesfull = false;//transaction succesfull

            //checks if the user entered the input fields
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

        //deposit the amount filled in by the user
        private void btnDeposit_Click(object sender, EventArgs e)
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

        //debug button
        private void btnReset_Click(object sender, EventArgs e)
        {
            myPort.WriteLine("R");
        }

        //the user logs out, another user can log in
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _validPass = false;
            _waitForPass = false;
            _loggedOut = true;

            _enteredPassword = string.Empty;
            lblWelcome.Text = "Welkom hou u pas voor de cardreader";
            rtbReceipt.Text = "";
            dgvReceipt.DataSource = null;

            _clearInput = true;
            UpdateForm(_currentClient);

            myPort.WriteLine("R");
        }

        //debug button
        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new ClientContext())
            {
                // Create and save a new Blog

                var trans = new Transaction { };
                db.Transactions.Add(trans);
                db.SaveChanges();

                // Display all Blogs from the database
                //var query = from b in db.Clients
                //            orderby b.Name
                //            select b;
            }
        }

        //prints the receipt
        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            _print = new PrintReceipt(_transaction, _currentClient);
            rtbReceipt.Text = _print.print();
        }
    }
}
