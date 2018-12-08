using System;

namespace EsiTest.StringReverser
{
    /// <summary>
    /// Handles input from the console window.
    /// </summary>
    public class InputHandler : IInputHandler
    {
        private const string InputHeader = "Type anything!";
        private const string ReverseComplete = "Press the any key to exit.";

        private readonly IStringReverser _stringReverser;
        private readonly IConsoleReader _consoleReader;

        public InputHandler(IStringReverser stringReverser, IConsoleReader consoleReader)
        {
            _stringReverser = stringReverser;
            _consoleReader = consoleReader;
        }

        public void ParseInput()
        {
            try
            {
                Console.WriteLine(InputHeader);
                string inputValue = _consoleReader.ReadLine();
                _stringReverser.ParseInputValue(inputValue);
                _stringReverser.DisplayResults();

                Console.WriteLine(ReverseComplete);
                _consoleReader.ReadKey();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }
    }
}