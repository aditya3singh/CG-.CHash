using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class MedicineUtility
    {
        private readonly SortedDictionary<int, List<Medicine>> _inventory = new SortedDictionary<int, List<Medicine>>();

        public void AddMedicine(Medicine medicine)
        {
            medicine.Validate();

            bool exists = _inventory.Values.Any(list => list.Any(m => m.Id == medicine.Id));
            if (exists) throw new DuplicateMedicineException($"Medicine with ID {medicine.Id} already exists.");

            if (!_inventory.ContainsKey(medicine.ExpiryYear))
            {
                _inventory[medicine.ExpiryYear] = new List<Medicine>();
            }

            _inventory[medicine.ExpiryYear].Add(medicine);
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            if (newPrice <= 0) throw new InvalidPriceException("Price must be positive.");

            var medicine = _inventory.Values
                .SelectMany(list => list)
                .FirstOrDefault(m => m.Id == id);

            if (medicine == null) throw new MedicineNotFoundException($"No medicine found with ID {id}.");

            medicine.Price = newPrice;
        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return _inventory.Values.SelectMany(list => list);
        }
    }
}