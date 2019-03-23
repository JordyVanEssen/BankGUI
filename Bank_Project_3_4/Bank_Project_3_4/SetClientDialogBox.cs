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
        UserTag _newUserId;
        Client _currentClient;
        CheckValidUserInput checkInput;

        public char[] passwordChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public SetClientDialogBox(Client pCurrentClient, ClientContext pDb, UserTag pNewClient)
        {
            _db = pDb;
            _currentClient = pCurrentClient;
            _newUserId = pNewClient;
            InitializeComponent();
        }

        private void SetClientDialogBox_Load(object sender, EventArgs e)
        {

        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            Boolean validInput = false;
            checkInput = new CheckValidUserInput(_db, _currentClient, _newUserId);

            if (!string.IsNullOrWhiteSpace(tbUserName.Text) && !string.IsNullOrWhiteSpace(tbUserPassword.Text))
            {
                validInput = true;
            }
            else
            {
                validInput = false;
            }

            validInput = checkInput.validInput(tbUserPassword.Text, validInput);

            if (validInput && checkInput.validUserInput)
            {
                HttpRequest httpRequest;
                username = tbUserName.Text;
                password = new string(checkInput.checkInput);
                password = password.Replace("\n", "");
                password = password.Replace("\r", "");

                //create a new usertag
                _newUserId.Password = password;
                httpRequest = new HttpRequest("UserTagItems");
                Object response = await HttpRequest.CreateAsync(_newUserId, httpRequest.createUrl());

                //get the new usertag
                httpRequest = new HttpRequest("UserTagItems", _newUserId.PassId);
                UserTag createdUser = await HttpRequest.GetClientAsync(httpRequest.createUrl());

                //create a new user, and link the user and the usertag with the usertagId
                _currentClient.Name = username;
                _currentClient.UserTagId = createdUser.UsertagId;
                httpRequest = new HttpRequest("ClientItems");
                response = await HttpRequest.CreateAsync(_currentClient, httpRequest.createUrl());

                Helper.showMessage("U bent succesvol toegevoegd.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (!validInput)
                {
                    if (!checkInput.validUserInput && checkInput.inputLength == 4)
                    {
                        Helper.showMessage("Uw wachtwoord mag alleen bestaan uit: '0, 1, 2, 3, 4, 5, 6, 7, 8, 9' ", MessageBoxIcon.Error);
                    }
                    else if (checkInput.inputLength < 4 || checkInput.inputLength > 4)
                    {
                        Helper.showMessage("Uw wachtwoord moet bestaan uit 4 karakters. U hebt er nu: " + checkInput.inputLength, MessageBoxIcon.Error);
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
