using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Business
{
    public interface IAccountTransactionProvider
    {
        bool CreateAccount(int accountId, int pin);
        void PrintAccountInformation(int accountId, int pin);
        bool PerformTransaction(int accountId, TransactionType type, decimal amount, int pin);
    }
}