using System;
using Exceptions;

namespace Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } // MemberId
        public abstract void Validate();
    }

    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public int FineAmount { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new MemberNotFoundException("Member ID is required.");

            if (FineAmount < 0)
                throw new InvalidFineException("Fine amount cannot be negative.");
        }

        public override string ToString() => $"Details: {Id} | {Name} | Fine: {FineAmount}";
    }
}