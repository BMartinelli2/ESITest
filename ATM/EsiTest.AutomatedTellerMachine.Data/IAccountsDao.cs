using System;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Data
{
    public interface IAccountsDao
    {
        decimal GetCurrentBalance(int accountId);
        void AddTransaction(int accountId, Transaction transaction, decimal newBalance);
        void CreateAccount(int accountId, int pin);
        UserAccount GetAccount(int accountId);
        bool AccountExists(int accountId);
        int GetPin(int accountId);
    }
}