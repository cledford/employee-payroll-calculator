using System;
using System.Collections.Generic;
using DeductionCalculatorV2.Models;

namespace DeductionCalculatorV2.Core
{
    public sealed class DeductionDiscountCalculatorSingleton
    {
        public double ApplyDiscountRulesToPerson(Person person, double deductionForPerson)
        {
            double result = deductionForPerson;
            foreach (var rule in DiscountRules.Rules)
            {
                result = rule(person, result);
            }

            return result;
        }

        private DeductionDiscountCalculatorSingleton() { }

        static DeductionDiscountCalculatorSingleton()
        {
            DiscountCalculator = new DeductionDiscountCalculatorSingleton();
        }

        public static DeductionDiscountCalculatorSingleton DiscountCalculator { get; }
    }

    internal static class DiscountRules
    {
        // This strategy will apply discounts sequentially
        public static List<Func<Person, double, double>> Rules => 
            new List<Func<Person, double, double>>
            {
                LetterADiscount,
            };

        private static readonly Func<Person,double,double> LetterADiscount = (person, currentDeduction) =>
        {
            if (person.FirstName.StartsWith("a", StringComparison.CurrentCultureIgnoreCase))
                return currentDeduction*0.9;
            return currentDeduction;
        };
    }
}