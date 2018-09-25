using System.Collections.Generic;
using DeductionCalculatorV2.Core;
using DeductionCalculatorV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeductionCalculatorV2.Tests.Core
{
    [TestClass]
    public class PaycheckCalculatorSingletonTest
    {
        [TestMethod]
        public void EmployeePayrollDataNoDiscounts()
        {
            // Arrange
            double employeePaycheck = 2000;
            double employeeWithOneDependentDeductions = 1500;
            int paychecksPerYear = 26;
            PayrollData expectedData = new PayrollData(
                employeePaycheck, employeeWithOneDependentDeductions, paychecksPerYear);

            Employee testEmployee = new Employee("notAdrian", "LastName", new List<Person>
            {
                new Person("notAnotherAName", "LastName")
            });

            // Act
            var result = PaycheckCalculatorSingleton.PaycheckCalculator
                .CalculatePayrollForEmployee(testEmployee);

            // Assert
            Assert.AreEqual(expectedData.PaycheckGross, result.PaycheckGross);
            Assert.AreEqual(expectedData.TotalDeductionsPerPaycheck, result.TotalDeductionsPerPaycheck);
            Assert.AreEqual(expectedData.TotalDeductionsPerYear, result.TotalDeductionsPerYear);
            Assert.AreEqual(expectedData.TotalPayPerYear, result.TotalPayPerYear);
        }
    }
}
