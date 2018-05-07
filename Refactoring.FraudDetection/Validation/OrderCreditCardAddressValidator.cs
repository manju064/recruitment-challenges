using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Validation
{
    using System.Collections.Generic;
    using DomainObjects;

    /// <summary>
    /// Order credit card address validation 
    /// </summary>
    public class OrderCreditCardAddressValidator : IValidator<Order>
    {
        /// <summary>
        /// validate credit card based on dealid and address
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public IList<FraudResult> Validate(IList<Order> orders, Order current)
        {
            var fraudResults = new List<FraudResult>();
            var i = orders?.IndexOf(current)??-1;

            if (i >= 0)
            {
                for (int j = i + 1; j < orders.Count; j++)
                {
                    if (current?.DealId == orders[j]?.DealId
                        && current?.State == orders[j]?.State
                        && current?.ZipCode == orders[j]?.ZipCode
                        && current?.Street == orders[j]?.Street
                        && current?.City == orders[j]?.City
                        && current?.CreditCard != orders[j]?.CreditCard)
                    {
                        fraudResults.Add(new FraudResult(orders[j]?.OrderId??-1, true));
                    }
                }
            }

            return fraudResults;
        }
    }
}
