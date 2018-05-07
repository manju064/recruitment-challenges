using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.FraudDetection.Dal
{
    /// <summary>
    /// Query repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryRepository<T> 
    {
        /// <summary>
        /// Get all rows
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
    }
}
