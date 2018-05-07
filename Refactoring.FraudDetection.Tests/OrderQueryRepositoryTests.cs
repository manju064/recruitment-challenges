using System.Linq;
using FluentAssertions;
using Refactoring.FraudDetection.Dal;
using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OrderQueryRepositoryTests
    {
        private readonly IQueryRepository<Order> _orderQueryRepository;

        public OrderQueryRepositoryTests()
        {
            _orderQueryRepository = new OrderQueryRepository();
        }

        [TestMethod]
        public void GetAllOrder()
        {
            var result = _orderQueryRepository.GetAll();

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(4, "The result should contains the number of orders");
        }
    }
}
