// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------


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
        IEnumerable<FraudResult> Check(IList<Order> orders);
    }
    #endregion

    #region Implementation
    /// <summary>
    /// Fraud Radar to perform fraud detection
    /// </summary>
    public class FraudRadar : IFraudRadar
    {
        private readonly IValidator<Order> _validator;

        public FraudRadar(IValidator<Order> validator)
        {
            Guard.IsNotNull(validator, () => validator);

            _validator = validator;
        }

        public IEnumerable<FraudResult> Check(IList<Order> orders)
        {
            Guard.IsNotNull(orders, () => orders);

            var fraudResults = new List<FraudResult>();

            // NORMALIZE
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i] = OrderNormalizer.Normalize(orders[i]);
            }

            // CHECK FRAUD
            var results = _validator.Validate(orders);

            if (results?.Count > 0)
                fraudResults.AddRange(results);

            return fraudResults;
        }
    }
    #endregion
}