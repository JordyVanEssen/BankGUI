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
        public String _username = "";
        public String _password = "";

        //check if the input is valid
        public bool filledInField = false;
        public bool validUserInput = false;
        public bool validChars = false;
        public bool input = false;
        public char[] checkInput;
        public int inputLength;

        //the password chars
        public char[] passwordChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public CheckValidUserInput()
        {

        }

        //check if the input is correct, retuns true or false
        public Boolean validInput(String pInput, Boolean pFilledInField)
        {
            input = pFilledInField;
            checkInput = null;
            validUserInput = false;
            validChars = false;
            checkInput = pInput.ToCharArray();
            inputLength = checkInput.Length;

            // just checks if the input only contains numbers
            if (input)
            {
                for (int i = 0; i < inputLength; i++)
                {
                    validChars = passwordChars.Any(x => x == checkInput[i]);

                    if (!validChars)
                    {
                        // if not -> break and return false
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
    }
}
