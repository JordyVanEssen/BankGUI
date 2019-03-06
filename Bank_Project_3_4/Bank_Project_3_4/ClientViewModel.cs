using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataLayer;

namespace Bank_Project_3_4
{
    public static class ClientViewModel
    {
        public static List<Client> GetClients()
        {

            using (var db = new ClientContext())
            {
                return db.Clients.ToList();
            }
        }
    }
}
