using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDataLayer;

namespace Bank_Project_3_4
{
    public partial class SetClientDialogBox : Form
    {
        public String username = "";
        public String password = "";
        Client _currentClient;

        public char[] passwordChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D' };

        public SetClientDialogBox(Client pCurrentClient)
        {
            this._currentClient = pCurrentClient;
            InitializeComponent();
        }

        private void SetClientDialogBox_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool validPassword = false;
            bool fieldName = false;
            bool fieldPass = false;

            bool validChars = false;
            String checkPassword = tbUserPassword.Text;

            if (checkPassword.Length != 4)
            {
                MessageBox.Show("Uw wachtwoord moet 4 karakters zijn, nu zijn het er: " + checkPassword.Length);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbUserName.Text))
                {
                    fieldName = true;
                }

                if (!string.IsNullOrWhiteSpace(tbUserPassword.Text))
                {
                    fieldPass = true;
                }

                if (fieldPass && fieldName)
                {
                    for (int i = 0; i < checkPassword.Length - 1; i++)
                    {
                        for (int a = 0; a < passwordChars.Length; a++)
                        {
                            if (checkPassword[i] == passwordChars[a])
                            {
                                validChars = true;
                            }
                            else
                            {
                                validChars = false;
                                return;
                            }
                        }
                    }

                    if (validChars)
                    {
                        validPassword = true;
                    }
                    else
                    {
                        checkPassword = "";
                        validPassword = false;
                    }
                }

                if (fieldName && validPassword)
                {
                    username = tbUserName.Text;
                    password = checkPassword;
                    checkPassword = "";

                    using (var db = new ClientContext())
                    {
                        _currentClient.Name = username;
                        _currentClient.Password = password;

                        db.Clients.Add(_currentClient);
                        db.SaveChanges();
                    }

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (!validPassword && fieldName && fieldPass)
                    {
                        MessageBox.Show("Uw wachtwoord mag alleen bestaan uit: '0, 1, 2, 3, 4, 5, 6, 7, 8, 9, A, B, C, D' ");
                    }
                    else
                    {
                        MessageBox.Show("Gelieve AL de velden invullen");
                    }
                }
            }

           
        }
    }
}
