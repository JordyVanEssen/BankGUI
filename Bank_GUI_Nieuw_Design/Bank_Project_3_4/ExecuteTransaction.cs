using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataLayer;
using Bank_Project_3_4.ViewModels;
using System.Windows.Forms;

namespace Bank_Project_3_4
{
    public class ExecuteTransaction
    {
        private Client _currentClient;
        private Transaction _transaction;
        private CheckValidUserInput _checkInput;
        private HttpRequest _httpRequest;
        private PrintReceipt _print;

        private int _amount = 0;
        private int _userTagId;
        private String _chosenBill = "";
        private int _billValue = 0;
        private Boolean _tSuccesfull = false;
        private String _billCombination = "";

        //the bills to choose from
        private int[] _bill = { 5, 10, 20, 50, 100, 200, 500 };

        public ExecuteTransaction(Client pCurrentClient, Transaction pTransaction, UserTagViewModel pUserTagViewModel)
        {
            _currentClient = pCurrentClient;
            _transaction = pTransaction;
            _userTagId = pUserTagViewModel.UserTagId;
        }

        public void executeTransaction(String pBill, String pAmount)
        {
            _checkInput = new CheckValidUserInput(_currentClient);
            bool input = false;
            bool validInput = false;
            double oldSaldo = _currentClient.Saldo;

            
            //checks if the user entered the input fields
            if (!string.IsNullOrWhiteSpace(pAmount) || !string.IsNullOrEmpty(pBill))
            {
                double amount = 0;

                try
                {
                    if (string.IsNullOrWhiteSpace(pAmount))
                    {
                        pAmount = pBill.Replace("€","");
                    }

                    input = true;
                    validInput = _checkInput.validInput(pAmount, input);

                    if (validInput)
                    {
                        amount = Convert.ToDouble(pAmount);
                    }
                }
                catch (OverflowException)
                {
                    Helper.showMessage("Uw hebt een te groot getal ingevoerd.", MessageBoxIcon.Error);
                }


                if (validInput)
                {
                    if (!string.IsNullOrEmpty(pBill))
                    {
                        _chosenBill = pBill.Replace("€", "");
                        _billValue = Convert.ToInt16(_chosenBill);
                        //withdraw
                        if ((amount / _billValue) % 1 == 0)
                        {
                            Withdraw withDrawel = new Withdraw(_currentClient, _userTagId, amount);
                            _tSuccesfull = withDrawel.withdrawMoney();
                        }
                        else
                        {
                            alternativeBilloption(amount);
                        }
                    }

                    if (_tSuccesfull)
                    {
                        //creates and prints the receipt
                        createReceipt(oldSaldo, _currentClient.Saldo);
                        _print = new PrintReceipt(_transaction, _currentClient, pBill, Convert.ToInt16(amount / _billValue), _billCombination);

                        Helper.showMessage("Transactie geslaagd");
                    }
                    else
                    {
                        if (amount > _currentClient.Saldo)
                        {
                            Helper.showMessage("Transactie mislukt. U hebt niet genoeg saldo.", MessageBoxIcon.Error);
                        }

                        inputErrorMsg(validInput);
                    }
                }
                else
                {
                    inputErrorMsg(validInput);
                }
            }
            else
            {
                Helper.showMessage("Graag al de velden invullen.", MessageBoxIcon.Error);
            }
        }
        
        private void alternativeBilloption(double pAmount)
        {
            _billCombination = "";
            int x = 0;
            int rest = 0;
            int aantal = 0;
            int a = 7;
            int previousBill = 0;
            int withdrawAmount = Convert.ToInt16(pAmount);

            for (int i = 0; pAmount > _billValue; i++)
            {
                pAmount -= _billValue;
                x++;
            }

            aantal = x;
            rest = Convert.ToInt16(pAmount);
            x = 0;

            for (int i = 0; i < 100; i++)
            {
                a--;

                if (rest >= _bill[a])
                {
                    if (previousBill == _bill[a])
                    {
                        x++;
                    }
                    else
                    {
                        x = 1;
                    }

                    previousBill = _bill[a];
                    rest -= _bill[a];
                    if (x <= 1)
                    {
                        _billCombination += $" {x} biljet van €" + Convert.ToString(_bill[a]);
                    }
                    else
                    {
                        if (_billCombination.Contains($" 1 biljet van €" + Convert.ToString(_bill[a])))
                        {
                            String replaceMent = $" {x} biljetten van: €" + Convert.ToString(_bill[a]);
                            _billCombination = _billCombination.Replace($" 1 biljet van €" + Convert.ToString(_bill[a]), replaceMent);
                        }
                    }
                    a++;
                }

                if (a == 0)
                {
                    if (rest <= 4)
                    {
                        break;
                    }

                    i = 0;
                    a = 6;
                }
            }

            if (rest == 0)
            {
                DialogResult result;
                if (aantal >= 2)
                {
                   result = Helper.showMessage($"Het biljet wat u hebt opgegeven kan het volledige bedrag niet bevatten. Wat wel kan zijn {aantal} biljetten van: €{_billValue}, {_billCombination}", MessageBoxButtons.OKCancel);
                }
                else
                {
                   result = Helper.showMessage($"Het biljet wat u hebt opgegeven kan het volledige bedrag niet bevatten. Wat wel kan is een {aantal} biljet van: €{_billValue}, {_billCombination}", MessageBoxButtons.OKCancel);
                }

                if (result == DialogResult.OK)
                {
                    Withdraw withDrawel = new Withdraw(_currentClient, _userTagId, withdrawAmount);
                    _tSuccesfull = withDrawel.withdrawMoney();
                }
            }
            else
            {
                if (aantal >= 2)
                {
                    Helper.showMessage($"Het biljet wat u hebt opgegeven kan het volledige bedrag niet bevatten. \n" +
                                        $"Wat wel kan is dat u {aantal} biljetten van: {_billValue}, {_billCombination}. \n\n" +
                                            $"De resterende €{rest} is niet meegerekend omdat daar geen biljetopties voor zijn. \n" +
                                                $"Daarom graag op tienden afronden. Bijvoorbeeld: €150 i.p.v. €153.");
                }
                else
                {
                    Helper.showMessage($"Het biljet wat u hebt opgegeven kan het volledige bedrag niet bevatten. \n" +
                                        $"Wat wel kan is dat u {aantal} biljet van: {_billValue}, {_billCombination}. \n\n" +
                                            $"De resterende €{rest} is niet meegerekend omdat daar geen biljetopties voor zijn. \n" +
                                                $"Daarom graag op tienden afronden. Bijvoorbeeld: €150 i.p.v. €153.");
                }
            }
    }

        //create the receipt
        private async void createReceipt(double pOldSaldo, double pNewSaldo)
        {
            _transaction = new Transaction { Mode = "Withdrawel" };
            DateTime now = DateTime.Now;

            _transaction.ClientId = _currentClient.ClientId;
            _transaction.Name = _currentClient.Name;
            _transaction.OldSaldo = pOldSaldo;
            _transaction.NewSaldo = pNewSaldo;
            _transaction.Time = now;

            _httpRequest = new HttpRequest("TransactionItems");
            Object response = await HttpRequest.CreateAsync(_transaction, _httpRequest.createUrl());
        }

        //error message if the input is invalid
        private void inputErrorMsg(bool pInput)
        {
            if (!pInput)
            {
                if (!_checkInput.validUserInput)
                {
                    Helper.showMessage("U mag alleen getallen invoeren ", MessageBoxIcon.Error);
                }
                else
                {
                    Helper.showMessage("Gelieve AL de velden invullen.", MessageBoxIcon.Error);
                }
            }
        }

        //prints the receipt on screen
        public String printReceipt()
        {
            if (_tSuccesfull)
            {
                return _print.print();
            }
            return "";
        }

    }
}
