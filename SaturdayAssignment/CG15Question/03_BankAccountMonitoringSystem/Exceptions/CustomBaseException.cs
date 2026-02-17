using System;

namespace Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message) { }
    }

    public class NegativeBalanceException : CustomBaseException
    { public NegativeBalanceException(string msg) : base(msg) { } }

    public class InsufficientFundsException : CustomBaseException
    { public InsufficientFundsException(string msg) : base(msg) { } }

    public class AccountNotFoundException : CustomBaseException
    { public AccountNotFoundException(string msg) : base(msg) { } }
}