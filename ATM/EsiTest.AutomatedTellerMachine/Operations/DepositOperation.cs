using System;
using EsiTest.AutomatedTellerMachine.Business;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class DepositOperation : ITellerMachineOperation
    {
        private const string DepositHeader = "Deposit funds:";
        private const string DepositFailedMessage = "Unable to deposit funds.";

        private readonly IAccountTransactionProvider _provider;

        public DepositOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "Deposit";

        /// <summary>
        /// Attempts to deposit funds into the account.
        /// </summary>
        public void PerformOperation()
        {
            Console.WriteLine(DepositHeader);

            int accountId = ParserHelperMethods.GetAccountId();
            int pin = ParserHelperMethods.GetPin();
            decimal amount = ParserHelperMethods.GetAmount();

            if (!_provider.PerformTransaction(accountId, TransactionType.Deposit, amount, pin))
            {
                Console.WriteLine(DepositFailedMessage);
            }
            else
            {
                Console.WriteLine($"Successfully deposited {amount:C}!");
            }
        }
    }
}