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
        HttpRequest _httpRequest;
        Client _currentClient;
        double _amount;

        public Deposit(Client pCurrentClient, double amount)
        {
            _currentClient = pCurrentClient;
            this._amount = amount;
        }

        public Boolean deposit()
        {
            //var result = _db.userTags.FirstOrDefault(x => x.PassId == passId);
            if (_currentClient != null)//match found
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
            _currentClient.Saldo = _currentClient.Saldo += _amount;
            _httpRequest = new HttpRequest("ClientItems");
            Object response = await HttpRequest.UpdateClientAsync(_currentClient, _httpRequest.createUrl());
        }
    }
}
