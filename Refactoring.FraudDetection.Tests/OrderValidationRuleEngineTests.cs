using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Validation;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class OrderValidationRuleEngineTests
    {

        private readonly IValidator<Order> validator = new OrderValidationRuleEngine(new List<IValidator<Order>>
        {
            new OrderCreditCardEmailValidator(),
            new OrderCreditCardAddressValidator()
        });

        [TestMethod]
        public void Test_Engine_FourOrders_MoreThanOneFraudulent()
        {
            #region Test data
            var order1 = new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010");
            var order2 = new Order(2, 1, "bugs2@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689011");
            var order3 = new Order(3, 2, "roger@rabbit.com", "1234 Not Sesame St.", "Colorado", "CL", "10012", "12345689012");
            var order4 = new Order(4, 2, "roger@rabbit.com", "1234 Not Sesame St.", "Colorado", "CL", "10012", "12345689014");

            var orders = new[] { order1, order2, order3, order4 };
            #endregion

            var result = validator.Validate(orders);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(2, "The result should contains the number of lines of the file");
        }
    }
}
