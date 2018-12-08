using System;
using EsiTest.AutomatedTellerMachine.Business;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class WithdrawOperation : ITellerMachineOperation
    {
        private const string WithdrawHeader = "Withdraw funds:";
        private const string WithdrawFailedMessage = "Unable to withdraw funds.";

        private readonly IAccountTransactionProvider _provider;

        public WithdrawOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "Withdraw";

        /// <summary>
        /// Attempts to withdraw funds from the account.
        /// </summary>
        public void PerformOperation()
        {
            Console.WriteLine(WithdrawHeader);
            
            int accountId = ParserHelperMethods.GetAccountId();
            int pin = ParserHelperMethods.GetPin();
            decimal amount = ParserHelperMethods.GetAmount();

            if (!_provider.PerformTransaction(accountId, TransactionType.Withdraw, amount, pin))
            {
                Console.WriteLine(WithdrawFailedMessage);
            }
            else
            {
                Console.WriteLine($"Successfully withdrew {amount:C}!");
            }
        }

    }
}