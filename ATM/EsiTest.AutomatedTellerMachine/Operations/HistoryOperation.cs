using System;
using EsiTest.AutomatedTellerMachine.Business;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class HistoryOperation : ITellerMachineOperation
    {
        private readonly IAccountTransactionProvider _provider;

        public HistoryOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "History";

        public void PerformOperation()
        {
            Console.WriteLine("Display account history:");

            int accountId = ParserHelperMethods.GetAccountId();
            int pin = ParserHelperMethods.GetPin();
            _provider.PrintAccountInformation(accountId, pin);
            
        }
    }
}