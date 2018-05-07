using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payvision.CodeChallenge.Base.Helpers;

namespace Payvision.CodeChallenge.Base.Extensions
{
    /// <summary>
    /// Extension methods for string
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string FormatWith(this string target, params object[] args)
        {
            Guard.IsNotEmpty(target, () => target);

            return string.Format(provider: Constants.CurrentCulture, format: target, args: args);
        }
    }
}
