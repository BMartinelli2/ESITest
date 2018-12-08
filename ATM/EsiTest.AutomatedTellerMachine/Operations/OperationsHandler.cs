using System;
using System.Collections.Generic;
using System.Linq;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    /// <summary>
    /// Typic
    /// </summary>
    public class OperationsHandler : IOperationHandler
    {
        private const string HelpOperation = "help";
        private const string QuitOperation = "quit";
        private const string ConsoleHeaderMessage = "Jacque's ATM, don't rob me! Type 'help' for a list of available commands or 'quit' to exit the application.";
        private const string InvalidOperationMessage = "Invalid operation, please type 'help' for a list of commands or 'quit' to exit the application.";
        private const string BarHeader = "---------------------";
        private const string HelpHeader = "Available Operations:";

        private bool _running = true;

        private readonly Dictionary<string, ITellerMachineOperation> _operations;

        public OperationsHandler(List<ITellerMachineOperation> operations)
        {
            _operations = new Dictionary<string, ITellerMachineOperation>();
            LoadOperations(operations);
        }

        private void LoadOperations(List<ITellerMachineOperation> operations)
        {
            foreach (var operation in operations)
            {
                _operations.Add(operation.OperationName.ToLowerInvariant(), operation);
            }
        }

        private void PrintAvailableOperations()
        {
            //Normally iterating through a dictionary is bad due to inefficiency
            Console.WriteLine(BarHeader);
            Console.WriteLine(HelpHeader);
            Console.WriteLine(BarHeader);
            foreach (var operation in _operations)
            {
                Console.WriteLine(operation.Key);
            }
            Console.WriteLine(BarHeader);
        }

        private void PerformOperation(string operationName)
        {
            string operationToPerform = operationName.ToLowerInvariant();
            if (operationToPerform == HelpOperation)
            {
                PrintAvailableOperations();
            }
            else if (operationToPerform == QuitOperation)
            {
                _running = false;
            }
            else if (_operations.ContainsKey(operationToPerform))
            {
                _operations[operationToPerform].PerformOperation();
            }
            else
            {
                Console.WriteLine(InvalidOperationMessage);
            }

            
        }

        public void ExecuteCommandLoop()
        {
            Console.WriteLine(ConsoleHeaderMessage);
            while (_running)
            {
                Console.Write(">");
                string operationToPerform = Console.ReadLine();
                PerformOperation(operationToPerform);
            }
        }
    }
}