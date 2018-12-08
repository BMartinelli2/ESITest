﻿using System;
using EsiTest.AutomatedTellerMachine.Business;
using EsiTest.AutomatedTellerMachine.Data.Models;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class WithdrawOperation : ITellerMachineOperation
    {
        private readonly IAccountTransactionProvider _provider;

        public WithdrawOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "Withdraw";

        public void PerformOperation()
        {
            Console.WriteLine("Withdraw funds:");

            bool isValid = false;

            while (!isValid)
            {
                int accountId = ParserHelperMethods.GetAccountId();
                int pin = ParserHelperMethods.GetPin();
                decimal amount = ParserHelperMethods.GetAmount();

                if (!_provider.PerformTransaction(accountId, TransactionType.Withdraw, amount, pin))
                {
                    Console.WriteLine("Unable to withdraw funds.");
                }
                else
                {
                    Console.WriteLine($"Successfully withdrew {amount:C}!");
                    isValid = true;
                }
            }
        }

    }
}