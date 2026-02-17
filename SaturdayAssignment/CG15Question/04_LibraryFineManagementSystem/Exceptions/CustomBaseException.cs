using System;

namespace Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message) { }
    }

    public class InvalidFineException : CustomBaseException
    { public InvalidFineException(string msg) : base(msg) { } }

    public class MemberNotFoundException : CustomBaseException
    { public MemberNotFoundException(string msg) : base(msg) { } }
}