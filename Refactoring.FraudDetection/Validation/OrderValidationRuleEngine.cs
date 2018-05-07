using Payvision.CodeChallenge.Base.Helpers;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Validation
{
    using System.Collections.Generic;
    using DomainObjects;

    /// <summary>
    /// Order validation rule composite object
    /// </summary>
    public class OrderValidationRuleEngine : List<IValidator<Order>>, IValidator<Order>
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

        /// <summary>
        /// Perform validation on set of defined validation rules
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public IList<FraudResult> Validate(IList<Order> orders, Order current = null)
        {
            Guard.IsNotNull(orders, () => orders);

            var fraudResults = new List<FraudResult>();

            for (int i = 0; i < orders.Count; i++)
            {
                current = orders[i];

                this.ForEach(validator =>
                {
                    var result = validator.Validate(orders, current);

                    if (result?.Count > 0)
                    {
                        foreach (var fraudResult in result)
                        {
                            if(!fraudResults.Contains(fraudResult))
                                fraudResults.Add(fraudResult);
                        }
                    }
                });
            }

            return fraudResults;
        }
    }
}
