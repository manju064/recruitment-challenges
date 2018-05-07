// -----------------------------------------------------------------------
// <copyright file="FraudRadarTests.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using Moq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Validation;
using Refactoring.FraudDetection.Dal;
using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FraudRadarTests
    {
        private readonly Mock<IQueryRepository<Order>> _orderQueryRepository;
        private readonly Mock<IOrderValidationRuleEngine> _orderValidationRuleEngine;

        public FraudRadarTests()
        {
            _orderQueryRepository = new Mock<IQueryRepository<Order>>();
            _orderValidationRuleEngine = new Mock<IOrderValidationRuleEngine>();
        }

        private FraudRadar FraudRadar => new FraudRadar(_orderValidationRuleEngine.Object, _orderQueryRepository.Object);


        [TestMethod]
        public void CheckFraud_OneOrder_NoFraudExpected()
        {
            #region Setup mock 
            var orders = TestDataHelper.GetSingleOrder();
            _orderQueryRepository.Setup(c => c.GetAll()).Returns(orders);
            _orderValidationRuleEngine.Setup(v => v.Validate(orders)).Returns(new List<FraudResult>());
            #endregion

            var result = FraudRadar.Check().ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(0, "The result should not contains fraudulent orders");
        }

        [TestMethod]
        public void CheckFraud_TwoOrders_SecondorderFraudulent()
        {
            #region Setup mock 
            var orders = TestDataHelper.Get_TwoOrders_SecondOrderFraudulent();
            _orderQueryRepository.Setup(c => c.GetAll()).Returns(orders);
            _orderValidationRuleEngine.Setup(v => v.Validate(orders)).Returns(new[] { new FraudResult(2, true) } );
            #endregion

            var result = FraudRadar.Check().ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of orders");
            result.First().IsFraudulent.Should().BeTrue("The first order is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first order is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_ThreeOrders_SecondOrderFraudulent()
        {
            #region Setup mock 
            var orders = TestDataHelper.Get_ThreeOrders_SecondOrderFraudulent();
            _orderQueryRepository.Setup(c => c.GetAll()).Returns(orders);
            _orderValidationRuleEngine.Setup(v => v.Validate(orders)).Returns(new[] { new FraudResult(2, true) });
            #endregion

            var result = FraudRadar.Check().ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of orders");
            result.First().IsFraudulent.Should().BeTrue("The first order is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first order is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_Fourorders_MoreThanOneFraudulent()
        {
            #region Setup mock 
            var orders = TestDataHelper.Get_FourOrders_MoreThanOneFraudulent();
            _orderQueryRepository.Setup(c => c.GetAll()).Returns(orders);
            _orderValidationRuleEngine.Setup(v => v.Validate(orders)).Returns(new[] { new FraudResult(2, true), new FraudResult(4, true) });
            #endregion

            var result = FraudRadar.Check().ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(2, "The result should contains the number of orders");
        }
    }
}