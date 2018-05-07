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
    public class OrderCreditCardAddressValidatorTests
    {
        private readonly IValidator<Order> validator = new OrderCreditCardAddressValidator();

        [TestMethod]
        public void Test_Address_ThreeOrders_FraudulentSecond()
        {
            #region Setup mock 
            var orders = TestDataHelper.Get_ThreeOrders_SecondOrderFraudulent();
            #endregion

            var result = validator.Validate(orders, orders.FirstOrDefault());

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of orders");
            result.First().IsFraudulent.Should().BeTrue("The first order is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first order is not fraudulent");
        }
    }
}
