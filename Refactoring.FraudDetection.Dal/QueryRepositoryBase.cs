using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.FraudDetection.Dal
{
    /// <summary>
    /// Base query repository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryRepositoryBase<T> : IQueryRepository<T> 
    {
        protected QueryRepositoryBase()
        {
            Repository = new List<T>();
        }

        /// <summary>
        /// Repository data
        /// </summary>
        protected List<T> Repository;


        public IEnumerable<T> GetAll()
        {
            return Repository;
        }
    }
}
