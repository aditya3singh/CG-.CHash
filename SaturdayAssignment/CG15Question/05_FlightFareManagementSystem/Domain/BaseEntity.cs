using System;
using Exceptions;

namespace Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } 
        public abstract void Validate();
    }

    public class Ticket : BaseEntity
    {
        public string PassengerName { get; set; }
        public int Fare { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new TicketNotFoundException("Ticket ID is mandatory.");

            if (Fare <= 0)
                throw new InvalidFareException("Fare must be a positive integer.");
        }

        public override string ToString() => $"Details: {Id} | {PassengerName} | Fare: {Fare}";
    }
}