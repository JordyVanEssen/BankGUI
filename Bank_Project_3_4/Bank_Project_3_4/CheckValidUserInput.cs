using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDataLayer;

namespace Bank_Project_3_4
{
    class CheckValidUserInput
    {
        ClientContext _db;
        public String username = "";
        public String password = "";
        Client _currentClient;

        public bool filledInField = false;
        public bool validPassword = false;
        public bool validChars = false;
        public char[] checkPassword;
        public int passLength;

        public char[] passwordChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public CheckValidUserInput(ClientContext pDb, Client pCurrentClient)
        {
            _db = pDb;
            _currentClient = pCurrentClient;
        }

        public Boolean validInput(String pInput, Boolean pFilledInField)
        {
            checkPassword = null;
            validPassword = false;
            validChars = false;
            checkPassword = pInput.ToCharArray();
            passLength = checkPassword.Length;

            if (passLength == 4)
            {
                if (pFilledInField)
                {
                    for (int i = 0; i < passLength; i++)
                    {
                        validChars = passwordChars.Any(x => x == checkPassword[i]);

                        if (!validChars)
                        {
                            break;
                        }
                    }

                    if (validChars)
                    {
                        validPassword = true;
                        return true;
                    }
                    else
                    {
                        validPassword = false;
                        checkPassword = null;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
       
    }
}
