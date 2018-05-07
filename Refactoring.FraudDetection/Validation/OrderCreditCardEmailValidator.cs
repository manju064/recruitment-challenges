
namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Validation
{
    using System.Collections.Generic;
    using DomainObjects;
    using Base.Helpers;

    /// <summary>
    /// Order credit card email validation 
    /// </summary>
    public class OrderCreditCardEmailValidator : IValidator<Order>
    {
        /// <summary>
        /// validate credit card based on dealid and email id
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public IList<FraudResult> Validate(IList<Order> orders, Order current)
        {
            Guard.IsNotNull(orders, () => orders);
            Guard.IsNotNull(current, () => current);

            var fraudResults = new List<FraudResult>();
            var i = orders.IndexOf(current);

            if (i >= 0)
            {
                for (int j = i + 1; j < orders.Count; j++)
                {
                    if (current?.DealId == orders[j]?.DealId
                        && current?.Email == orders[j]?.Email
                        && current?.CreditCard != orders[j]?.CreditCard)
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }

            return fraudResults;
        }
    }
}
