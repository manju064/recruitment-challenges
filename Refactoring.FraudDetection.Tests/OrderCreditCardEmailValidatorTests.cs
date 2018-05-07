using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Validation;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class OrderCreditCardEmailValidatorTests
    {
        private readonly IValidator<Order> validator = new OrderCreditCardEmailValidator();

        [TestMethod]
        public void Test_OneOrder()
        {
            #region Test data
            var order = new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010");
            var orders = new[] {order};
            #endregion

            var result = validator.Validate(orders, order);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(0, "The result should not contains fraudulent lines");
        }

        [TestMethod]
        public void Test_Email_TwoOrders_SecondOrderFraudulent()
        {
            #region Test data
            var order1 = new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010");
            var order2 = new Order(2, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10012", "12345689011");

            var orders = new[] { order1, order2 };
            #endregion

            var result = validator.Validate(orders, order1);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }
    }
}
