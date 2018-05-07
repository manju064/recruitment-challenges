using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    public static class TestDataHelper
    {
        public static IList<Order> GetSingleOrder()
        {
            var order = new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010");
            return new[] { order };
        }

        public static IList<Order> Get_TwoOrders_SecondOrderFraudulent()
        {
            var order1 = new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010");
            var order2 = new Order(2, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10012", "12345689011");

            return new[] { order1, order2 };
        }

        public static IList<Order> Get_ThreeOrders_SecondOrderFraudulent()
        {
            var order1 = new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010");
            var order2 = new Order(2, 1, "bugs2@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689011");
            var order3 = new Order(3, 2, "roger@rabbit.com", "1234 Not Sesame St.", "Colorado", "CL", "10012", "12345689012");

            return new[] { order1, order2, order3 };
        }

        public static IList<Order> Get_FourOrders_MoreThanOneFraudulent()
        {
            var order1 = new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010");
            var order2 = new Order(2, 1, "bugs2@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689011");
            var order3 = new Order(3, 2, "roger@rabbit.com", "1234 Not Sesame St.", "Colorado", "CL", "10012", "12345689012");
            var order4 = new Order(4, 2, "roger@rabbit.com", "1234 Not Sesame St.", "Colorado", "CL", "10012", "12345689014");

            return new[] { order1, order2, order3, order4 };
        }
    }
}
