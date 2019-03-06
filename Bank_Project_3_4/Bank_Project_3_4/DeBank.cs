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

        private string rxString;//incoming data is stored in String rxString

        String enteredPassword = string.Empty;
        String readPass = string.Empty;

        bool waitForPass = false;
        bool validPass = false;

        int invalidPassCount = 0;


        public DeBank()
        {
            InitializeComponent();
        }

        private void DeBank_Load(object sender, EventArgs e)
        {
            myPort.BaudRate = 9600;
            myPort.PortName = "COM6";
            myPort.DataReceived += MyPort_DataReceived;
            myPort.Open();
            myPort.WriteLine("R");
        }

        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            validPass = false;

            rxString = myPort.ReadLine();

            if (!rxString.Contains("VM") && waitForPass == false)
            {
                using (var db = new ClientContext())
                {
                    var result = db.Clients.FirstOrDefault(x => x.PassId == rxString);
                    if (result == null)//if pass does not exist
                    {
                        result = new Client { PassId = rxString };

                        using (SetClientDialogBox clientForm = new SetClientDialogBox(result))
                        {
                            if (clientForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                myPort.WriteLine("R");
                            }
                        }
                        _currentClient = result;
                    }
                    else
                    {
                        _currentClient = result;
                        if (_currentClient.PassBlocked == false)
                        {
                            myPort.WriteLine("P");
                            MessageBox.Show($"Graag uw wachtwoord invullen voor u op 'OK' klikt {0}", _currentClient.Name);
                            //readPass = myPort.ReadLine();
                            enteredPassword = myPort.ReadExisting();
                            readPass = enteredPassword.Substring(enteredPassword.IndexOf('p'));

                            waitForPass = true;
                        }
                        else
                        {
                            MessageBox.Show("Uw pas is geblokkeerd");
                        }


                    }

                    UpdateForm(result);

                    //result is a Client
                }
            }

            if (readPass.Contains("pass") && waitForPass)
            {
                ClientPasswordCheck checkPass = new ClientPasswordCheck(_currentClient);
                readPass.Replace("pass", null);
                readPass = readPass.Substring(readPass.IndexOf('s') + 2);
                readPass = readPass.Trim();

                validPass = checkPass.validatePassord(readPass);
            }
                

            if (validPass)
            {
                //ask to enter password
                UpdateForm(_currentClient);

                //myPort.WriteLine("R");//reset the 'sentPassword' value on the arduino
                validPass = false;
                invalidPassCount = 0;

                using (var db = new ClientContext())
                {
                    _currentClient.PassBlocked = false;
                    db.SaveChanges();//update new saldo
                }
            }
            else
            {
                invalidPassCount += 1;
                if (invalidPassCount > 3)
                {
                    MessageBox.Show("Uw pas is geblokkeerd");

                    using (var db = new ClientContext())
                    {
                        _currentClient.PassBlocked = true;
                        db.SaveChanges();//update new saldo
                    }
                }
                else
                {
                    MessageBox.Show("Uw wachtwoord is incorrect, probeer het alstublieft opnieuw. \n 1) lees uw pas in \n 2) voer uw wachtwoord in");
                    myPort.WriteLine("R");
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
                grpbUserInterface.Visible = true;
            }
            else
            {
                grpbUserInterface.Visible = false;
            }

            tbLoggedInUser.Text = pClient.Name;
            dataGridView1.DataSource = ClientViewModel.GetClients();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void loadClients()//show the client database on screen
        {
            dataGridView1.DataSource = ClientViewModel.GetClients();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void DeBank_Shown(object sender, EventArgs e)//show all clients a bit after the form loaded
        {
            loadClients();
        }

        private void btnGetSaldo_Click(object sender, EventArgs e)//if button is pressed
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(_currentClient.PassId);
            tbUserSaldo.Text = Convert.ToString(checkSaldo.getSaldo());//get the saldo of the current client
        }

        private void btnWithdraw_Click(object sender, EventArgs e)//if button is pressed
        {
            if (!string.IsNullOrEmpty(tbWithdrawMoney.Text))
            {
                Withdraw withDrawel = new Withdraw(_currentClient, Convert.ToDouble(tbWithdrawMoney.Text));
                withDrawel.withdrawMoney();//withdraw money
                MessageBox.Show("Transactie succesvol");

            }
            else
            {
                MessageBox.Show("Graag het veld invullen");
            }
            
            
        }

        private void btnDeposit_Click(object sender, EventArgs e)//if button is pressend
        {
            if (!string.IsNullOrEmpty(tbDepositMoney.Text))
            {
                Deposit depositMoney = new Deposit(_currentClient, Convert.ToDouble(tbDepositMoney.Text));
                depositMoney.deposit();//deposit money
                MessageBox.Show("Transactie succesvol");

            }
            else
            {
                MessageBox.Show("Graag het veld invullen");
            }
            
        }

        public String scanPort()
        {
            String enteredPass = myPort.ReadExisting();

            return enteredPass;
        }

        private void button1_Click(object sender, EventArgs e)
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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    using (var db = new ClientContext())
        //    {
        //        // Create and save a new Blog

        //        var client = new Client { Name = textBox1.Text };
        //        db.Clients.Add(client);
        //        db.SaveChanges();

        //        // Display all Blogs from the database
        //        var query = from b in db.Clients
        //                    orderby b.Name
        //                    select b;
        //    }
        //}
    }
}
