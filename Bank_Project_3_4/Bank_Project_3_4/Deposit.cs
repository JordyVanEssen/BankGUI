using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDataLayer;

namespace Bank_Project_3_4
{
    class Deposit
    {
        HttpRequest httpRequest;
        ClientContext _db;
        Client currentClient;
        String passId = "";
        double amount;

        public Deposit(Client pCurrentClient, double amount, ClientContext pDb)
        {
            _db = pDb;
            currentClient = pCurrentClient;
            this.amount = amount;
        }

        public Boolean deposit()
        {
            //var result = _db.userTags.FirstOrDefault(x => x.PassId == passId);
            if (currentClient != null)//match found
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
            currentClient.Saldo = currentClient.Saldo += amount;
            httpRequest = new HttpRequest("ClientItems");
            Object response = await HttpRequest.UpdateClientAsync(currentClient, httpRequest.createUrl());
        }
    }
}
