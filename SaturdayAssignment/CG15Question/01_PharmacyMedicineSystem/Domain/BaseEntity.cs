using System;
using System.Text.RegularExpressions;

namespace Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public abstract void Validate();
    }

    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ExpiryYear { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Id) || !Regex.IsMatch(Id, @"^DR\d{4}$"))
                throw new Exceptions.InvalidIdException("Medicine ID must follow format 'DR1234'.");

            if (Price <= 0)
                throw new Exceptions.InvalidPriceException("Price must be a positive integer.");

            if (ExpiryYear < DateTime.Now.Year)
                throw new Exceptions.InvalidExpiryYearException("Expiry year cannot be in the past.");
        }

        public override string ToString() => $"Details: {Id} {Name} {Price} {ExpiryYear}";
    }
}