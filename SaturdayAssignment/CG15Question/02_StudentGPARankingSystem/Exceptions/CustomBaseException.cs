using System;

namespace Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message) { }
    }

    public class InvalidGPAException : CustomBaseException
    { public InvalidGPAException(string msg) : base(msg) { } }

    public class DuplicateStudentException : CustomBaseException
    { public DuplicateStudentException(string msg) : base(msg) { } }

    public class StudentNotFoundException : CustomBaseException
    { public StudentNotFoundException(string msg) : base(msg) { } }
}