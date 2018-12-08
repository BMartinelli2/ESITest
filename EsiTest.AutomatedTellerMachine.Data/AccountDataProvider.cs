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
        private bool _isInitialized = false;
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
                    Console.WriteLine("Account file not found -- generating new accounts database file.");
                    _userAccounts = new List<UserAccount>();
                    SaveChanges();
                }

                var fileData = File.ReadAllText(_accountFile);
                _userAccounts = JsonConvert.DeserializeObject<UserAccount[]>(fileData).ToList();
                _isInitialized = true;
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
    }
}