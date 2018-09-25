using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeductionCalculatorV2.Models;

namespace DeductionCalculatorV2.Data
{
    public class EmployeeStorageSingleton
    {
        private readonly Dictionary<Guid, Employee> _items;

        public Task<Employee> Get(Guid id)
        {
            return Task.FromResult(!_items.ContainsKey(id) 
                ? null 
                : _items[id]);
        }

        public Task Upsert(Employee employee)
        {
            if (_items.ContainsKey(employee.EmployeeId))
                _items[employee.EmployeeId] = employee;
            else
                _items.Add(employee.EmployeeId, employee);

            return Task.CompletedTask;
        }

        static EmployeeStorageSingleton()
        {
            EmployeeStorage = new EmployeeStorageSingleton();
        }

        public EmployeeStorageSingleton()
        {
            _items = new Dictionary<Guid, Employee>();
        }

        public static EmployeeStorageSingleton EmployeeStorage { get; }
    }
}