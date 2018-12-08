using System;
using EsiTest.Methodology.Operations;

namespace EsiTest.Methodology
{
    class Program
    {
        private const string ApplicationHeader = "-- ESI Coding Test #3 - OOP / Solid -- ";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(ApplicationHeader);
                ModuleBindings bindings = new ModuleBindings();
                bindings.RegisterModules();

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
