using Payvision.CodeChallenge.Base.Helpers;
using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Validation
{
    using System.Collections.Generic;
    using DomainObjects;

    /// <summary>
    /// interface for validation rule engine for orders
    /// </summary>
    public interface IOrderValidationRuleEngine
    {
        /// <summary>
        /// Validation method
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        IList<FraudResult> Validate(IList<Order> orders);
    }

    /// <summary>
    /// Order validation rule composite object
    /// </summary>
    public class OrderValidationRuleEngine : List<IValidator<Order>>, IOrderValidationRuleEngine
    {
        /// <summary>
        /// Pass list of validator to constructor
        /// </summary>
        /// <param name="validatorList"></param>
        public OrderValidationRuleEngine(IList<IValidator<Order>> validatorList)
            : base(validatorList)
        {
            Guard.IsNotNull(validatorList, () => validatorList);
        }


        /// <inheritdoc />
        public IList<FraudResult> Validate(IList<Order> orders)
        {
            var fraudResults = new List<FraudResult>();

            for (int i = 0; i < orders.Count; i++)
            {
                var current = orders[i];

                this.ForEach(validator =>
                {
                    var result = validator.Validate(orders, current);

                    foreach (var fraudResult in result)
                    {
                        if (!fraudResults.Contains(fraudResult))
                            fraudResults.Add(fraudResult);
                    }
                });
            }

            return fraudResults;
        }
    }
}
