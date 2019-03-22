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
        Client _currentClient;
        double usersaldo = 0;

        public CheckUserSaldo(Client pCurrenClient, ClientContext pDb)
        {
            _db = pDb;
            _currentClient = pCurrenClient;
        }

        //returns the saldo of the current user
        public double getSaldo()
        {
            usersaldo = _currentClient.Saldo;
            return usersaldo;
        }
    }
}
