using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public char[] passwordChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

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
            bool returnFromLoop = false;
            char[] checkPassword = tbUserPassword.Text.ToCharArray();
            int passLength = checkPassword.Length;
           
            if (!string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                fieldName = true;
            }
            else
            {
                fieldName = false;
            }

            if (!string.IsNullOrWhiteSpace(tbUserPassword.Text))
            {
                fieldPass = true;
            }
            else
            {
                fieldPass = false;
            }

            if (fieldPass && fieldName)
            {
                for (int i = 0; i < passLength; i++)
                {
                    validChars = passwordChars.Any(x => x == checkPassword[i]);

                    if (!validChars)
                    {
                        break;
                    }
                    

                    //for (int a = 0; a < passwordChars.Length; a++)
                    //{
                    //    if (checkPassword[i] == passwordChars[a])
                    //    {
                    //        validChars = true;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if (a == 9)
                    //        {
                    //            validChars = false;
                    //            returnFromLoop = true;
                    //            break;
                    //        }
                    //    }
                    //}
                }

                if (validChars)
                {
                    validPassword = true;
                }
                else
                {
                    checkPassword = null;
                    validPassword = false;
                }

                //validPassword = Regex.IsMatch(checkPassword, @"(?=^[^\s]$)(^\d+$){4,4}");

            }

            if (fieldName && validPassword)
            {
                username = tbUserName.Text;
                password = new string(checkPassword);
                checkPassword = null;

                using (var db = new ClientContext())
                {
                    _currentClient.Name = username;
                    _currentClient.Password = password;

                    db.Clients.Add(_currentClient);
                    db.SaveChanges();
                }
                MessageBox.Show("U bent succesvol toegevoegd!", "Toegevoegd", MessageBoxButtons.OK ,MessageBoxIcon.Information);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                if (!validPassword && fieldName && fieldPass)
                {
                    MessageBox.Show("Uw wachtwoord mag alleen bestaan uit: '0, 1, 2, 3, 4, 5, 6, 7, 8, 9' ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Gelieve AL de velden invullen", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //if (!passLength.Equals(4))
            //{
            //    MessageBox.Show("Uw wachtwoord moet 4 karakters zijn, nu zijn het er: " + checkPassword.Length);
            //}
            //else
            //{
                
            //}
        }
    }
}
