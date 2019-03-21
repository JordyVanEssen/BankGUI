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
        UserTag _userCredentials;

        public bool filledInField = false;
        public bool validUserInput = false;
        public bool validChars = false;
        public bool input = false;
        public char[] checkInput;
        public int inputLength;

        public char[] passwordChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public CheckValidUserInput(ClientContext pDb, Client pCurrentClient, UserTag pUserCredential)
        {
            _db = pDb;
            _currentClient = pCurrentClient;
            _userCredentials = pUserCredential;
        }

        public Boolean validInput(String pInput, Boolean pFilledInField)
        {
            input = pFilledInField;
            checkInput = null;
            validUserInput = false;
            validChars = false;
            checkInput = pInput.ToCharArray();
            inputLength = checkInput.Length;

            if (inputLength == 4)
            {
                if (input)
                {
                    for (int i = 0; i < inputLength; i++)
                    {
                        validChars = passwordChars.Any(x => x == checkInput[i]);

                        if (!validChars)
                        {
                            break;
                        }
                    }

                    if (validChars)
                    {
                        validUserInput = true;
                        return true;
                    }
                    else
                    {
                        validUserInput = false;
                        checkInput = null;
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
