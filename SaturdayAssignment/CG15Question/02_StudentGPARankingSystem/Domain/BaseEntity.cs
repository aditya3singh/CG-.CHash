using System;
using Exceptions;

namespace Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public abstract void Validate();
    }

    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public double GPA { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new StudentNotFoundException("Student ID cannot be empty.");

            if (GPA < 0 || GPA > 10)
                throw new InvalidGPAException("GPA must be between 0.0 and 10.0.");
        }

        public override string ToString() => $"Details: {Id} {Name} {GPA:F2}";
    }
}