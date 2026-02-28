using System.ComponentModel.DataAnnotations;

namespace LpuApplicationForm.Models
{
    public class EligibleAgeAttribute : ValidationAttribute
    {
        public int MinAge { get; }
        public int MaxAge { get; }

        public EligibleAgeAttribute(int minAge = 16, int maxAge = 100)
        {
            MinAge = minAge;
            MaxAge = maxAge;
            ErrorMessage = $"Applicant must be between {minAge} and {maxAge} years old.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dob)
            {
                var today = DateTime.Today;
                var age = today.Year - dob.Year;
                if (dob.Date > today.AddYears(-age)) age--;

                if (age < MinAge)
                    return new ValidationResult($"You must be at least {MinAge} years old to apply.");

                if (age > MaxAge)
                    return new ValidationResult($"Date of birth is not valid. Age cannot exceed {MaxAge} years.");
            }

            return ValidationResult.Success;
        }
    }
}