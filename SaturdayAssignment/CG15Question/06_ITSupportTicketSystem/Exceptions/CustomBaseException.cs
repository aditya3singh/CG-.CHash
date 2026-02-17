using System;

namespace Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message) { }
    }

    public class InvalidSeverityException : CustomBaseException
    { public InvalidSeverityException(string msg) : base(msg) { } }

    public class TicketNotFoundException : CustomBaseException
    { public TicketNotFoundException(string msg) : base(msg) { } }
}