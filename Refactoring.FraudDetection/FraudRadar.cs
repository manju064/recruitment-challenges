// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------


using System.Linq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Validation;
using Refactoring.FraudDetection.Dal;
using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using DomainObjects;
    using Base.Helpers;

    #region Interface
    /// <summary>
    /// Fraud Radar to perform fraud detection
    /// </summary>
    public interface IFraudRadar
    {
        /// <summary>
        /// Fraud check method
        /// </summary>
        /// <param name="from">from date time of order</param>
        /// <param name="to">up to date time of order</param>
        /// <returns></returns>
        IEnumerable<FraudResult> Check(DateTime? from = null, DateTime? to = null);
    }
    #endregion

    #region Implementation

    /// <inheritdoc />
    public class FraudRadar : IFraudRadar
    {
        private readonly IQueryRepository<Order> _orderQueryRepository;

        private readonly IOrderValidationRuleEngine _orderValidationRuleEngine;

        public FraudRadar(IOrderValidationRuleEngine orderValidationRuleEngine, IQueryRepository<Order> orderQueryRepository)
        {
            Guard.IsNotNull(orderValidationRuleEngine, () => orderValidationRuleEngine);
            Guard.IsNotNull(orderQueryRepository, () => orderQueryRepository);

            _orderValidationRuleEngine = orderValidationRuleEngine;
            _orderQueryRepository = orderQueryRepository;
        }

        /// <inheritdoc />
        public IEnumerable<FraudResult> Check(DateTime? from = null, DateTime? to = null)
        {
            var fraudResults = new List<FraudResult>();

            //TODO, apply filtering of transaction based on from and to date time

            IList<Order> orders = _orderQueryRepository.GetAll().ToList();

            // NORMALIZE
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i] = OrderNormalizer.Normalize(orders[i]);
            }

            // CHECK FRAUD
            var results = _orderValidationRuleEngine.Validate(orders);

            if (results?.Count > 0)
                fraudResults.AddRange(results);

            return fraudResults;
        }
    }
    #endregion
}