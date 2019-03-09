using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataLayer;

namespace Bank_Project_3_4
{
    public class ClientViewModel
    {
        private ClientContext _db;

        public ClientViewModel(ClientContext pDb)
        {
            _db = pDb;
        }

        public List<Client> GetClients()
        {
               return _db.Clients.ToList();
        }

        public List<Transaction> GetTransactions(int pClientId)
        {
            return _db.Transactions.Where(x => x.ClientId == pClientId).ToList();
        }
    }
}
