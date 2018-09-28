using System.Linq;
using DeductionCalculatorV2.Models;
using static DeductionCalculatorV2.Core.DeductionDiscountCalculatorSingleton;

namespace DeductionCalculatorV2.Core
{
    public sealed class PaycheckCalculatorSingleton
    {
        private const int NumberOfPaychecks = 26;
        private readonly double _employeeDeduction;
        private readonly double _dependentDeduction;
        private readonly double _employeeGrossPay;

        public PayrollData CalculatePayrollForEmployee(Employee employee)
        {
            // Apply employee deductions w/ discounts
            var currentDeduction = DiscountCalculator.ApplyDiscountRulesToPerson(
                employee, _employeeDeduction);

            // Apply dependent deductions w/ discounts
            currentDeduction += employee.Dependents.Sum(dependent => 
                DiscountCalculator.ApplyDiscountRulesToPerson(dependent, _dependentDeduction));

            // Get paycheck 
            return new PayrollData(
                _employeeGrossPay, 
                currentDeduction, // TODO: maybe make this a little cleaner?
                NumberOfPaychecks);
        }

        private PaycheckCalculatorSingleton(double employeeDeduction, 
            double dependentDeduction, double employeeGrossPay)
        {
            _employeeDeduction = employeeDeduction;
            _dependentDeduction = dependentDeduction;
            _employeeGrossPay = employeeGrossPay;
            
        }

        static PaycheckCalculatorSingleton()
        {
            // NEXT: Use factory pattern with some sort of data-driven mechanism to populate this
            PaycheckCalculator = 
                new PaycheckCalculatorSingleton(
                    1000d / NumberOfPaychecks,
                    500d / NumberOfPaychecks,
                    2000d);
        }

        public static PaycheckCalculatorSingleton PaycheckCalculator { get; }
    }
}