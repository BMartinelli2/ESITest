using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EsiTest.AutomatedTellerMachine.Data.Models;
using Newtonsoft.Json;

namespace EsiTest.AutomatedTellerMachine.Data
{
    public interface IAccountDataProvider
    {
        List<UserAccount> UserAccounts { get; }

        void LoadAccountsData(string accountFile);

        void SaveChanges();
    }
}