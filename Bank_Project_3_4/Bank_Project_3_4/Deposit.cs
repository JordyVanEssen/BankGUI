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
            this.amount = amount;
        }

        public Boolean deposit()
        {
            //var result = _db.userTags.FirstOrDefault(x => x.PassId == passId);
            if (currentClient != null)//match found
            {
                currentClient.Saldo = currentClient.Saldo += amount;
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
