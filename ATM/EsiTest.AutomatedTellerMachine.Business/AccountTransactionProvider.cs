using System;
using System.IO;
using EsiTest.AutomatedTellerMachine.Data;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Business
{
    public class AccountTransactionProvider : IAccountTransactionProvider
    {
        private const string NoHistoryAvailableMessage = "No history available for this account";
        private const string NoAccountAvailableMessage = "Account not found";
        private const string InvalidPinMessage = "Invalid PIN";
        private const string OverdraftWarningMessage = "WARNING YOUR ACCOUNT IS BELOW $0.00, YOU WILL BE CHARGED AN OVERDRAFT FEE."
        private readonly IAccountsDao _accountDao;


        public AccountTransactionProvider(IAccountsDao accountDao)
        {
            _accountDao = accountDao;
        }

        public bool PerformTransaction(int accountId, TransactionType type, decimal amount, int pin)
        {
            bool result = false;

            try
            {
                if (!_accountDao.AccountExists(accountId))
                {
                    Console.WriteLine(NoAccountAvailableMessage);
                }
                else if (ValidatePin(accountId, pin))
                {
                    //Normally I would implement an abstract factory here to create the transactions / provide the appropriate business logic instead of a switch statement.
                    //Factory.GetTransactionProvider(TransactionType type)
                    //This can be used with the IOC container with conditional module registrations.
                    Transaction transaction = new Transaction()
                    {
                        TransactionType = type,
                        Amount = amount
                    };

                    decimal newBalance = _accountDao.GetCurrentBalance(accountId);

                    //Also we could put business logic in here to not even need the transaction type, and just have a +/- system for storing data.
                    //However the type is good for knowing the context around the transaction. Other types could be added such as transfer or some sort of interest gain.
                    if (VerifyTransactionAmount(amount))
                    {
                        switch (type)
                        {
                            case TransactionType.Deposit:
                                newBalance += amount;
                                break;
                            case TransactionType.Withdraw:
                                newBalance -= amount;
                                break;
                        }
                    }

                    Console.WriteLine($"Your new balance is {newBalance:C}.");

                    if (newBalance < 0m)
                    {
                        Console.WriteLine(OverdraftWarningMessage);
                    }

                    _accountDao.AddTransaction(accountId, transaction, newBalance);
                    result = true;
                }
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"Invalid account found. {accountId}");
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool CreateAccount(int accountId, int pin)
        {
            bool result = false;
            try
            {
                _accountDao.CreateAccount(accountId, pin);

                result = true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;

        }

        public void PrintAccountInformation(int accountId, int pin)
        {
            try
            {
                if (!_accountDao.AccountExists(accountId))
                {
                    Console.WriteLine(NoAccountAvailableMessage);
                }
                else if(ValidatePin(accountId, pin))
                {
                    var account = _accountDao.GetAccount(accountId);

                    Console.WriteLine($"Account {accountId} summary.");
                    Console.WriteLine("------------------------------");

                    if (account.TransactionHistory == null || account.TransactionHistory.Count == 0)
                    {
                        Console.WriteLine(NoHistoryAvailableMessage);

                    }

                    foreach (var transaction in account.TransactionHistory)
                    {
                        Console.WriteLine($"Transaction: {transaction.TransactionType.ToString()} -- {transaction.Amount:C}");
                    }
                }
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private bool VerifyTransactionAmount(decimal amount)
        {
            return amount > 0m;
        }

        private bool ValidatePin(int accountId, int pin)
        {
            bool isValid = _accountDao.GetPin(accountId) == pin;

            if (!isValid)
            {
                Console.WriteLine(InvalidPinMessage);
            }

            return isValid;
        }
    }
}
