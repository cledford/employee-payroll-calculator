using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeductionCalculatorV2.Core;
using DeductionCalculatorV2.Models;

namespace DeductionCalculatorV2.Tests.Core
{
    [TestClass]
    public class DeductionDiscountCalculatorSingletonTest
    {

        [TestMethod]
        public void ANameRuleApplies10PercentDiscount()
        {
            // Arrange
            Person personWithAName = new Person("Adrian", "LastName");
            double personDeduction = 100;
            double expectedDeduction = 90;

            // Act
            var result = DeductionDiscountCalculatorSingleton.DiscountCalculator
                .ApplyDiscountRulesToPerson(personWithAName, personDeduction);

            // Assert
            Assert.AreEqual(result, expectedDeduction);
        }

        [TestMethod]
        public void NoDiscountsAppliedTest()
        {
            // Arrange
            Person person = new Person("NotAdrian", "LastName");
            double personDeduction = 100;
            double expectedDeduction = 100;

            // Act
            var result = DeductionDiscountCalculatorSingleton.DiscountCalculator
                .ApplyDiscountRulesToPerson(person, personDeduction);

            // Assert
            Assert.AreEqual(result, expectedDeduction);
        }

    }
}
