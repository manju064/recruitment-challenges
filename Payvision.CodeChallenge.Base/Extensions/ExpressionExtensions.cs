using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payvision.CodeChallenge.Base.Extensions
{
    /// <summary>
    /// Expression Extensions
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Get parameter name
        /// </summary>
        /// <param name="parameterExpr"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetParameterName<T>(this Expression<Func<T>> parameterExpr)
        {
            var body = ((MemberExpression)parameterExpr.Body);
            return body.Member.Name;
        }
    }
}
