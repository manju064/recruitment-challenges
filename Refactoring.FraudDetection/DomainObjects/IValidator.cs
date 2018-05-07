using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects
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
        /// <param name="value"></param>
        /// <returns></returns>
        IList<FraudResult> Validate(IList<T> values, T value = default(T));
    }
}
