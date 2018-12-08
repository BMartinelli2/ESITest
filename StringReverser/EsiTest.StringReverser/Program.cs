using System;

namespace EsiTest.StringReverser
{
    class Program
    {
        private const string ApplicationHeader = "-- ESI Coding Test #1 - String Reverser -- ";

        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationHeader);
            ModuleBindings bindings = new ModuleBindings();
            bindings.RegisterModules();

            var inputHandler = bindings.DependencyContainer.GetInstance<IInputHandler>();
            inputHandler.ParseInput();
        }

    }
}
