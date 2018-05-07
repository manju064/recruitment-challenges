using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Validation;
using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class OrderValidationRuleEngineTests
    {
        private readonly Mock<IValidator<Order>> _orderCreditCardEmailValidator;
        private readonly Mock<IValidator<Order>> _orderCreditCardAddressValidator;

        public OrderValidationRuleEngineTests()
        {
            _orderCreditCardEmailValidator = new Mock<IValidator<Order>>();
            _orderCreditCardAddressValidator = new Mock<IValidator<Order>>();
        }

        private IOrderValidationRuleEngine OrderValidationRuleEngine => new OrderValidationRuleEngine(new List<IValidator<Order>>
        {
            _orderCreditCardEmailValidator.Object,
            _orderCreditCardAddressValidator.Object
        });

        [TestMethod]
        public void Test_Engine_FourOrders_MoreThanOneFraudulent()
        {
            #region Setup mock 
            var orders = TestDataHelper.Get_FourOrders_MoreThanOneFraudulent();
            _orderCreditCardEmailValidator.Setup(o => o.Validate(orders, It.IsAny<Order>()))
                .Returns(new[] {new FraudResult(2, true)});
            _orderCreditCardAddressValidator.Setup(o => o.Validate(orders, It.IsAny<Order>()))
                .Returns(new[] { new FraudResult(4, true) });
            #endregion

            var result = OrderValidationRuleEngine.Validate(orders);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(2, "The result should contains the number of orders");
        }
    }
}
