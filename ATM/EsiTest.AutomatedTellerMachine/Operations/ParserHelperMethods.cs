using System;

namespace EsiTest.AutomatedTellerMachine.Operations
{
    /// <summary>
    /// Static helper class for common parsing functions.
    /// Note a few things: the methods are very similar, we could probably
    /// condense these into a single templated function with the appropriate amount of parameters.
    /// </summary>
    public static class ParserHelperMethods
    {
        public static int GetAccountId()
        {
            bool isValid = false;
            int accountId = 0;

            while (!isValid)
            {
                Console.Write("Enter an account ID:");
                string inputAccount = Console.ReadLine();

                if (int.TryParse(inputAccount, out accountId))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid account. Try Again");
                }
            }

            return accountId;
        }

        public static int GetPin()
        {
            bool isValid = false;
            int pin = 0;

            while (!isValid)
            {
                Console.Write("Enter a pin:");
                string inputPin = Console.ReadLine();

                if (int.TryParse(inputPin, out pin))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid pin. Try Again");
                }
            }

            return pin;
        }

        public static decimal GetAmount()
        {
            bool isValid = false;
            decimal amount = 0;

            while (!isValid)
            {
                Console.Write("Enter an amount:");
                string inputPin = Console.ReadLine();

                if (decimal.TryParse(inputPin, out amount) && amount > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Try Again");
                }
            }

            return amount;
        }
    }
}