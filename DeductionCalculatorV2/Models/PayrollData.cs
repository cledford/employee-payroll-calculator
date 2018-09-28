using System;

namespace DeductionCalculatorV2.Models
{
    public class PayrollData
    {
        public double PaycheckGross { get; }
        public double TotalDeductionsPerPaycheck { get; }
        public double TotalDeductionsPerYear { get; }
        public double TotalPayPerYear { get; }

        public PayrollData(double paycheckGross, double totalDeductionsPerPaycheck, 
            int paychecksPerYear)
        {
            PaycheckGross = paycheckGross;
            TotalDeductionsPerPaycheck = Math.Round(totalDeductionsPerPaycheck,2);
            TotalDeductionsPerYear = totalDeductionsPerPaycheck*paychecksPerYear;
            TotalPayPerYear = paycheckGross*paychecksPerYear;
        }
    }
}