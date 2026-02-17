using System;
using Exceptions;

namespace Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } 
        public abstract void Validate();
    }

    public class SupportTicket : BaseEntity
    {
        public string IssueDescription { get; set; }
        public int SeverityLevel { get; set; } 

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new TicketNotFoundException("Ticket ID cannot be empty.");

            if (SeverityLevel < 1 || SeverityLevel > 5)
                throw new InvalidSeverityException("Severity Level must be between 1 and 5.");
        }

        public override string ToString() => $"[Priority {SeverityLevel}] ID: {Id} | Issue: {IssueDescription}";
    }
}