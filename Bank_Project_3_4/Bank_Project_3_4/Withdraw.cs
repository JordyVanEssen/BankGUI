using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDataLayer;

namespace Bank_Project_3_4
{
    public class Withdraw
    {
        HttpRequest httpRequest;
        ClientContext _db;
        Client _currentClient;
        UserTag _userCredentials;
        String passId = "";
        double amount;
        double saldo;

        public Withdraw(Client pCurrentClient, UserTag pUserCredential, double amount, ClientContext pDb)
        {
            _db = pDb;
            _currentClient = pCurrentClient;
            _userCredentials = pUserCredential;
            this.passId = _userCredentials.PassId;
            this.amount = amount;
        }

        public Boolean withdrawMoney()
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(_currentClient, _db);
            saldo = checkSaldo.getSaldo();

            //if the user has enough saldo
            if (saldo > amount && amount > 0)
            {
                updateSaldo();
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void updateSaldo()
        {
            _currentClient.Saldo = _currentClient.Saldo -= amount;
            httpRequest = new HttpRequest("ClientItems");
            Object response = await HttpRequest.UpdateClientAsync(_currentClient, httpRequest.createUrl());
        }
    }
}
