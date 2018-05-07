using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Validation;
using Refactoring.FraudDetection.Domain;

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
            var orders = TestDataHelper.GetSingleOrder();
            #endregion

            var result = validator.Validate(orders, orders.FirstOrDefault());

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(0, "The result should not contains fraudulent orders");
        }

        [TestMethod]
        public void Test_Email_TwoOrders_SecondOrderFraudulent()
        {
            #region Test data
            var orders = TestDataHelper.Get_TwoOrders_SecondOrderFraudulent();
            #endregion

            var result = validator.Validate(orders, orders?.FirstOrDefault());

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of orders");
            result.First().IsFraudulent.Should().BeTrue("The first order is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first order is not fraudulent");
        }
    }
}
