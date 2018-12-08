using System;
using System.Collections.Generic;
using System.Linq;
using EsiTest.AutomatedTellerMachine.Data;
using EsiTest.AutomatedTellerMachine.Operations;

namespace EsiTest.AutomatedTellerMachine
{
    //General Notes:
    //Things that could also be done:
    //-Only allow withdraws within increments of $20
    //-Don't allow the account to go negative
    //-Add a service fee to the transaction
    //-Add support for account transfers

    class Program
    {
        private const string AccountFile = "AccountsFile.json";
        private const string ApplicationHeader = "-- ESI Coding Test #2 - ATM -- ";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(ApplicationHeader);
                ModuleBindings bindings = new ModuleBindings();
                bindings.RegisterModules();

                //Load our accounts data
                var accountDataProvider = bindings.DependencyContainer.GetInstance<IAccountDataProvider>();
                accountDataProvider.LoadAccountsData(AccountFile);

                var operationHandler = bindings.DependencyContainer.GetInstance<IOperationHandler>();
                operationHandler.ExecuteCommandLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("FATAL ERROR OCCURRED:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
