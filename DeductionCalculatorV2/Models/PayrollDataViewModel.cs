namespace DeductionCalculatorV2.Models
{
    public class PayrollDataViewModel
    {
        public Employee Employee { get; }
        public PayrollData PayrollData { get; }

        // NEXT: Add some more calculations of payroll deductions

        public PayrollDataViewModel(Employee employee, PayrollData payrollData)
        {
            Employee = employee;
            PayrollData = payrollData;
        }
    }
}