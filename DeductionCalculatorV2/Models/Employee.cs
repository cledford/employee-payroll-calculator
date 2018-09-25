using System;
using System.Collections.Generic;

namespace DeductionCalculatorV2.Models
{
    public class Employee : Person
    {
        public Guid EmployeeId { get; }
        public List<Person> Dependents { get; }

        public Employee(string firstName, string lastName, List<Person> dependents) 
            : this(Guid.NewGuid(),firstName, lastName, dependents)
        { }

        public Employee(string firstName, string lastName)
            : this(Guid.NewGuid(),firstName, lastName, new List<Person>())
        { }

        public Employee(Guid employeeId, string firstName, string lastName, List<Person> dependents)
            : base(firstName, lastName)
        {
            EmployeeId = employeeId;
            Dependents = dependents;
        }
    }
}