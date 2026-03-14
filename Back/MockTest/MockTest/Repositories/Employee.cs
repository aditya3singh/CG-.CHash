using System;
using System.Collections.Generic;
using System.Text;
using EmployeeApp.Core.Models;
using System.Linq;

namespace EmployeeApp.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public void Add(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _employees.Add(employee);
        }

        public void Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public IReadOnlyCollection<Employee> GetAll()
        {
            return _employees.AsReadOnly();
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.IsActive = employee.IsActive;
            }
        }
    }
}
