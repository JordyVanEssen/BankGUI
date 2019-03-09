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
        ClientContext _db;
        Client currentClient;
        String passId = "";
        double amount;

        public Deposit(Client pCurrentClient, double amount, ClientContext pDb)
        {
            _db = pDb;
            currentClient = pCurrentClient;
            this.passId = pCurrentClient.PassId;
            this.amount = amount;
        }

        public Boolean deposit()
        {
            var result = _db.Clients.FirstOrDefault(x => x.PassId == passId);
            if (result != null)//match found
            {
                result.Saldo = result.Saldo += amount;
                _db.SaveChanges();//update new saldo
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
