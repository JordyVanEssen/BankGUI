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
        ClientContext _db;
        Client currentClient;
        String passId = "";
        double amount;
        double saldo;

        public Withdraw(Client pCurrentClient, double amount, ClientContext pDb)
        {
            _db = pDb;
            currentClient = pCurrentClient;
            this.passId = pCurrentClient.PassId;
            this.amount = amount;
        }

        public void withdrawMoney()
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(currentClient.PassId, _db);
            saldo = checkSaldo.getSaldo();

            if (saldo > amount && amount > 0)
            {
                var result = _db.Clients.FirstOrDefault(x => x.PassId == passId);
                if (result != null)//no match found
                {
                    result.Saldo = result.Saldo -= amount;
                    _db.SaveChanges();//update new saldo
                    MessageBox.Show("Transactie succesvol");
                }
                else
                {
                    MessageBox.Show("Transactie mislukt");
                }
            }
            else
            {
                if (amount < 0)
                {
                    MessageBox.Show("Gelieve alleen positieve getallen invoeren");

                }
                else
                {
                    MessageBox.Show($"Er staat niet genoeg saldo op uw account");
                }
            }

        }
    }
}
