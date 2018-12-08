using System;
using EsiTest.AutomatedTellerMachine.Business;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    public class CreateAccountOperation : ITellerMachineOperation
    {
        private const string AccountCreateHeader = "Create a new account!";
        private const string CreateAccountFailedMessage = "Unable to create account.";
        private const string CreateAccountSucceededMessage = "Successfully created your account!";

        private readonly IAccountTransactionProvider _provider;

        public CreateAccountOperation(IAccountTransactionProvider provider)
        {
            _provider = provider;
        }

        public string OperationName => "Create";

        /// <summary>
        /// Attempts to create an account.
        /// </summary>
        public void PerformOperation()
        {
            Console.WriteLine(AccountCreateHeader);

            int accountId = ParserHelperMethods.GetAccountId();
            int pin = ParserHelperMethods.GetPin();

            if (!_provider.CreateAccount(accountId, pin))
            {
                Console.WriteLine(CreateAccountFailedMessage);
            }
            else
            {
                Console.WriteLine(CreateAccountSucceededMessage);
            }
        }

        
    }
}