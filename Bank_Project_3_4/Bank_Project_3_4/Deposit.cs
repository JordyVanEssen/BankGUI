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
        Client currentClient;
        String passId = "";
        double amount;

        public Deposit(Client pCurrentClient, double amount)
        {
            currentClient = pCurrentClient;
            this.passId = pCurrentClient.PassId;
            this.amount = amount;
        }

        public void deposit()
        {
            using (var db = new ClientContext())
            {
                var result = db.Clients.FirstOrDefault(x => x.PassId == passId);
                if (result != null)//match found
                {
                    result.Saldo = result.Saldo += amount;
                    db.SaveChanges();//update new saldo
                    MessageBox.Show("Transactie succesvol");
                }
                else
                {
                    MessageBox.Show("Transactie mislukt");
                }
            }
        }
    }
}
