using System;
using System.Collections.Generic;
using EsiTest.AutomatedTellerMachine.Business;
using EsiTest.AutomatedTellerMachine.Data;
using EsiTest.AutomatedTellerMachine.Operations;
using SimpleInjector;

namespace EsiTest.AutomatedTellerMachine
{
    public class ModuleBindings
    {
        public Container DependencyContainer { get; private set; } = new Container();

        /// <summary>
        /// Register modules with the IOC container.
        /// </summary>
        public void RegisterModules()
        {
            //We only ever want one account data provider active since it's a file share, normally we could use a SQL database which could be a transient object type.
            //Typically singletons should be avoided at all costs, as they are a code smell to a larger problem.
            //i.e. not scalable.
            DependencyContainer.Register<IAccountDataProvider, AccountDataProvider>(Lifestyle.Singleton);
            DependencyContainer.Register<IAccountTransactionProvider, AccountTransactionProvider>();
            DependencyContainer.Register<IAccountsDao, AccountsDao>();
            DependencyContainer.Collection.Register<ITellerMachineOperation>(new List<Type>()
            {
                typeof(CreateAccountOperation),
                typeof(DepositOperation),
                typeof(HistoryOperation),
                typeof(WithdrawOperation)
            });
            DependencyContainer.Register<IOperationHandler, OperationsHandler>();
        }

    }
}