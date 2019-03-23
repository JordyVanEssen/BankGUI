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
        UserTag currentClient;

        public ClientPasswordCheck(UserTag pCurrentClient)
        {
            this.currentClient = pCurrentClient;
        }

        public Boolean validatePassword(String pPassword)
        {
            //returns true or false, depends if the password is valid
            return currentClient.Password.Equals(pPassword);
        }
    }
}
