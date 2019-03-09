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
        ClientContext _db;
        public String username = "";
        public String password = "";
        Client _currentClient;
        CheckValidUserInput checkInput;

        public char[] passwordChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public SetClientDialogBox(Client pCurrentClient, ClientContext pDb)
        {
            _db = pDb;
            _currentClient = pCurrentClient;
            InitializeComponent();
        }

        private void SetClientDialogBox_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Boolean validInput = false;
            checkInput = new CheckValidUserInput(_db, _currentClient);

            if (!string.IsNullOrWhiteSpace(tbUserName.Text) && !string.IsNullOrWhiteSpace(tbUserPassword.Text))
            {
                validInput = true;
            }
            else
            {
                validInput = false;
            }

            validInput = checkInput.validInput(tbUserPassword.Text, validInput);

            if (validInput && checkInput.validPassword)
            {
                username = tbUserName.Text;
                password = new string(checkInput.checkPassword);

                _currentClient.Name = username;
                _currentClient.Password = password;

                _db.Clients.Add(_currentClient);
                _db.SaveChanges();

                Helper.showMessage("U bent succesvol toegevoegd.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (!checkInput.validPassword && validInput)
                {
                    Helper.showMessage("Uw wachtwoord mag alleen bestaan uit: '0, 1, 2, 3, 4, 5, 6, 7, 8, 9' ", MessageBoxIcon.Error);
                }
                else
                {
                    if (checkInput.passLength < 4)
                    {
                        Helper.showMessage("Uw wachtwoord moet bestaan uit 4 karakters. U hebt er nu: " + checkInput.passLength, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Helper.showMessage("Gelieve AL de velden invullen.", MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
