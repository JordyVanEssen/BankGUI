using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataLayer;

namespace Bank_Project_3_4
{
    class ClientPasswordCheck
    {
        Client currentClient;

        public ClientPasswordCheck(Client pCurrentClient)
        {
            this.currentClient = pCurrentClient;
        }

        public Boolean validatePassord(String pPassword)
        {
            if (currentClient.Password == pPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
