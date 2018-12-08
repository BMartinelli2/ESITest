using System;
using System.Collections.Generic;

namespace EsiTest.AutomatedTellerMachine.Data.Models
{
    [Serializable]
    public class UserAccount
    {
        public int AccountId { get; set; }

        public List<Transaction> TransactionHistory { get; set; }

        public decimal AccountBalance { get; set; }

        public int PersonalIdentificationNumber { get; set; }
    }

}