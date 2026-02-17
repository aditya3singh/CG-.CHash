using System;

namespace Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message) { }
    }

    public class InvalidPriceException : CustomBaseException
    { 
        public InvalidPriceException(string msg) : base(msg) { }
    }

    public class InvalidExpiryYearException : CustomBaseException
    { public InvalidExpiryYearException(string msg) : base(msg) { } }

    public class DuplicateMedicineException : CustomBaseException
    { public DuplicateMedicineException(string msg) : base(msg) { } }

    public class MedicineNotFoundException : CustomBaseException
    { public MedicineNotFoundException(string msg) : base(msg) { } }

    public class InvalidIdException : CustomBaseException
    { public InvalidIdException(string msg) : base(msg) { } }
}