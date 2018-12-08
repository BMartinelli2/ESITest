using System;
using EsiTest.AutomatedTellerMachine.Business;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class DepositOperation : ITellerMachineOperation
    {
        private readonly IAccountTransactionProvider _provider;

        public DepositOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "Deposit";

        public void PerformOperation()
        {
            Console.WriteLine("Deposit funds:");

            bool isValid = false;

            while (!isValid)
            {
                int accountId = ParserHelperMethods.GetAccountId();
                int pin = ParserHelperMethods.GetPin();
                decimal amount = ParserHelperMethods.GetAmount();

                if (!_provider.PerformTransaction(accountId, TransactionType.Deposit, amount, pin))
                {
                    Console.WriteLine("Unable to deposit funds.");
                }
                else
                {
                    Console.WriteLine($"Successfully deposited {amount:C}!");
                    isValid = true;
                }
            }
        }
    }
}