using System;
using System.Collections.Generic;
using EsiTest.Methodology.Operations;
using SimpleInjector;

namespace EsiTest.Methodology
{
    public class ModuleBindings
    {
        public Container DependencyContainer { get; private set; } = new Container();

        /// <summary>
        /// Register modules with the IOC container.
        /// </summary>
        public void RegisterModules()
        {
            DependencyContainer.Collection.Register<IOperation>(new List<Type>()
            {
                typeof(EncapsulationOperation),
                typeof(InheritanceOperation),
                typeof(PolymorphismOperation),
                typeof(SingleResponsibilityOperation),
                typeof(OpenClosedOperation),
                typeof(ListkovOperation),
                typeof(InterfaceSegregationOperation),
                typeof(DependencyInversionOperation)
            });
            DependencyContainer.Register<IOperationHandler, OperationsHandler>();
        }

    }
}