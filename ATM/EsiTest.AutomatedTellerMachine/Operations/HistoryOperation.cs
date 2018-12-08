using System;
using EsiTest.AutomatedTellerMachine.Business;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class HistoryOperation : ITellerMachineOperation
    {
        private const string HistoryDisplayHeader = "Display account history:";

        private readonly IAccountTransactionProvider _provider;

        public HistoryOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "History";

        /// <summary>
        /// Attempts to display history for the account.
        /// </summary>
        public void PerformOperation()
        {
            Console.WriteLine(HistoryDisplayHeader);

            int accountId = ParserHelperMethods.GetAccountId();
            int pin = ParserHelperMethods.GetPin();
            _provider.PrintAccountInformation(accountId, pin);
            
        }
    }
}