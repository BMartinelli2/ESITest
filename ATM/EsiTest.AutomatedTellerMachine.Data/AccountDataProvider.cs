using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EsiTest.AutomatedTellerMachine.Data.Models;
using Newtonsoft.Json;

namespace EsiTest.AutomatedTellerMachine.Data
{
    public class AccountDataProvider : IAccountDataProvider
    {
        private string _accountFile;
        private List<UserAccount> _userAccounts;

        public List<UserAccount> UserAccounts
        {
            get => _userAccounts;
        }

        public void LoadAccountsData(string accountFile)
        {
            _accountFile = accountFile;

            try
            {

                if (!File.Exists(accountFile))
                {
                    PrintFirstRunInformation();
                    _userAccounts = new List<UserAccount>();
                    SaveChanges();
                }

                var fileData = File.ReadAllText(_accountFile);
                _userAccounts = JsonConvert.DeserializeObject<UserAccount[]>(fileData).ToList();
            }
            catch (Exception ex) 
            {
                //Normally I would follow best practices and only catch a specific exception,
                //but due to the limited time, I am omitting this and doing a generic catch.
                Console.WriteLine("Unable to load the account data from the JSON file.");
                Console.WriteLine(ex.Message);
                throw new FileLoadException(ex.Message, ex);
            }
        }


        public void SaveChanges()
        {
            string serializedUserAccounts = JsonConvert.SerializeObject(UserAccounts);
            //Overwrite the old file.
            File.WriteAllText(_accountFile, serializedUserAccounts, Encoding.UTF8);
        }

        private void PrintFirstRunInformation()
        {
            //Normally something like this would not exist in the data provider section of the application
            //and it would be using an external configuration.
            //In the case we have a database down or database not found issue, we would
            //use a logger to log the issue, and attempt to reconnect or retry to connect for a number
            //of times or for a period of time.
            Console.WriteLine(@"Account file not found -- generating new accounts database file.");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("This is probably the first time you're running this, please create");
            Console.WriteLine("a new account with the 'create' command and deposit funds with the");
            Console.WriteLine(" 'deposit' command.");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}