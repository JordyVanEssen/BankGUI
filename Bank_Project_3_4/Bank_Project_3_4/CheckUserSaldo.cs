using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataLayer;

namespace Bank_Project_3_4
{
    public class CheckUserSaldo
    {
        ClientContext _db;
        double usersaldo = 0;
        String UserID;

        public CheckUserSaldo(String pUserID, ClientContext pDb)
        {
            _db = pDb;
            this.UserID = pUserID;
        }

        public double getSaldo()
        {
            
            var result = _db.Clients.FirstOrDefault(x => x.PassId == UserID);//checks if saldo > then the amount the user wants to withdraw
            if (result != null)
            {
                usersaldo = result.Saldo;
            }
            return usersaldo;
        }
    }
}
