using System;

namespace DeductionCalculatorV2.Models
{
    public class AddDependentViewModel
    {
        public Guid EmployeeId { get; set; }
        public Person Dependent { get; set; }
    }
}