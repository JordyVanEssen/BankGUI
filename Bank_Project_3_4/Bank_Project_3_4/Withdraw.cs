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
        Client currentClient;
        String passId = "";
        double amount;
        double saldo;

        public Withdraw(Client pCurrentClient, double amount)
        {
            currentClient = pCurrentClient;
            this.passId = pCurrentClient.PassId;
            this.amount = amount;
        }

        public void withdrawMoney()
        {
            CheckUserSaldo checkSaldo = new CheckUserSaldo(currentClient.PassId);
            saldo = checkSaldo.getSaldo();

            if (saldo > amount && amount > 0)
            {
                using (var db = new ClientContext())
                {
                    var result = db.Clients.FirstOrDefault(x => x.PassId == passId);
                    if (result != null)//no match found
                    {
                        result.Saldo = result.Saldo -= amount;
                        db.SaveChanges();//update new saldo
                    }
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
