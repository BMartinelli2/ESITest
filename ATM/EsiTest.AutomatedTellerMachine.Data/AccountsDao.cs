using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Data
{
    public class AccountsDao : IAccountsDao
    {
        private const string InvalidAccountMessage = "Account ID is invalid.";
        private const string AccountAlreadyExistsMessage = "Account already exists.";
        private readonly IAccountDataProvider _accountDataProvider;
        

        public AccountsDao(IAccountDataProvider accountDataProvider)
        {
            _accountDataProvider = accountDataProvider;
        }

        /// <summary>
        /// Gets the current account balance.
        /// </summary>
        /// <param name="accountId">Account ID to get the balance for.</param>
        /// <returns>Returns an account balance.</returns>
        public decimal GetCurrentBalance(int accountId)
        {
            var account = GetAccount(accountId);
            if (account == null)
            {
                throw new InvalidDataException(InvalidAccountMessage);
            }

            return account.AccountBalance;
        }

        /// <summary>
        /// Gets the pin for validation.
        /// </summary>
        /// <param name="accountId">Account ID for use with data.</param>
        /// <returns></returns>
        public int GetPin(int accountId)
        {
            var account = GetAccount(accountId);
            if (account == null)
            {
                throw new InvalidDataException(InvalidAccountMessage);
            }

            return account.PersonalIdentificationNumber;

            //Additional Note: we could have a method to set a new pin.
        }

        /// <summary>
        /// Adds a transaction to the user's account.
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="transaction">Transaction to add</param>
        /// <param name="newBalance">New Balance</param>
        public void AddTransaction(int accountId, Transaction transaction, decimal newBalance)
        {
            var account = GetAccount(accountId);
            if (account == null)
            {
                throw new InvalidDataException(InvalidAccountMessage);
            }

            //No history is available, add the data object type for it.
            if (account.TransactionHistory == null)
            {
                account.TransactionHistory = new List<Transaction>();
            }

            account.TransactionHistory.Add(transaction);
            account.AccountBalance = newBalance;

            _accountDataProvider.SaveChanges();
        }

        /// <summary>
        /// Creates a new account with the specified ID.
        /// </summary>
        /// <param name="accountId"></param>
        public void CreateAccount(int accountId, int pin)
        {
            if (_accountDataProvider.UserAccounts.Any(t => t.AccountId == accountId))
            {
                throw new InvalidOperationException(AccountAlreadyExistsMessage);
            }

            _accountDataProvider.UserAccounts.Add(new UserAccount(){AccountId = accountId, AccountBalance = 0m, TransactionHistory = new List<Transaction>(), PersonalIdentificationNumber = pin});
            _accountDataProvider.SaveChanges();
        }
        
        /// <summary>
        /// Gets the user account for account ID.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public UserAccount GetAccount(int accountId)
        {
            return _accountDataProvider.UserAccounts.FirstOrDefault(t => t.AccountId == accountId);
        }

        public bool AccountExists(int accountId)
        {
            return _accountDataProvider.UserAccounts.Any(t => t.AccountId == accountId);
        }

        

    }

}
