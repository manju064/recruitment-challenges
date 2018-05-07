using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Validation
{
    /// <summary>
    /// Validator base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Validation method
        /// </summary>
        /// <param name="values"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IList<FraudResult> Validate(IList<T> values, T value);
    }

    
}
