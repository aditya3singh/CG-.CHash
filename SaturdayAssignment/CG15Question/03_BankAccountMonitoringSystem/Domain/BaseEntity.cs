using System;
using Exceptions;

namespace Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } 
        public abstract void Validate();
    }

    public class Account : BaseEntity
    {
        public string HolderName { get; set; }
        public decimal Balance { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new AccountNotFoundException("Account Number cannot be empty.");

            if (Balance < 0)
                throw new NegativeBalanceException("Opening balance cannot be negative.");
        }

        public override string ToString() => $"Details: {Id} | {HolderName} | Balance: {Balance:C}";
    }
}