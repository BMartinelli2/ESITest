using System;

namespace EsiTest.AutomatedTellerMachine.Data.Models
{
    /// <summary>
    /// Represents a single account transaction within the audit trail of the ATM.
    /// Other notes: we can put a DateTimeOffset on the transaction too.
    /// </summary>
    [Serializable]
    public class Transaction
    {

        /// <summary>
        /// Type of transaction that occured with the specified amount.
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// The amount of money that the transaction has moved.
        /// The decimal type is used for transactions based on the following: <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.decimal?view=netframework-4.7.2#remarks"/>
        /// </summary>
        public decimal Amount { get; set; }
    }
}