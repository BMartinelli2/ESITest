using System;
using EsiTest.AutomatedTellerMachine.Business;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class CreateAccountOperation : ITellerMachineOperation
    {
        private readonly IAccountTransactionProvider _provider;

        public CreateAccountOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "Create";

        /// <summary>
        /// This method performs a basic account creation.
        /// This probably could be broken into a series of additional commands
        /// and with better added navigation.
        /// </summary>
        public void PerformOperation()
        {
            Console.WriteLine("Create a new account!");

            bool isValid = false;

            while (!isValid)
            {
                int accountId = ParserHelperMethods.GetAccountId();
                int pin = ParserHelperMethods.GetPin();

                if (!_provider.CreateAccount(accountId, pin))
                {
                    Console.WriteLine("Unable to create account.");
                }
                else
                {
                    Console.WriteLine("Successfully created your account!");
                    isValid = true;
                }
            }
        }

        
    }
}