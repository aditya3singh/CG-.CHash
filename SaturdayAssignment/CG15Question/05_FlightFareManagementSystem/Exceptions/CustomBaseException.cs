using System;

namespace Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message) { }
    }

    public class InvalidFareException : CustomBaseException
    { public InvalidFareException(string msg) : base(msg) { } }

    public class DuplicateTicketException : CustomBaseException
    { public DuplicateTicketException(string msg) : base(msg) { } }

    public class TicketNotFoundException : CustomBaseException
    { public TicketNotFoundException(string msg) : base(msg) { } }
}