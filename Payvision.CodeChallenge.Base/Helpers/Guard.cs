using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Payvision.CodeChallenge.Base.Extensions;
using Payvision.CodeChallenge.Resource;

namespace Payvision.CodeChallenge.Base.Helpers
{
    public static class Guard
    {
        /// <summary>
        /// Check is argument is not empty
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="expr"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerStepThrough]
        public static void IsNotEmpty<T>(string argument, Expression<Func<T>> expr)
        {
            if (string.IsNullOrEmpty((argument ?? string.Empty).Trim()))
            {
                throw new ArgumentException(Global.ArgumentCannotBeBlank.FormatWith(expr.GetParameterName()), expr.GetParameterName());
            }
        }

        /// <summary>
        /// Check is argument is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="expr"></param>
        [DebuggerStepThrough]
        public static void IsNotNull<T>(object argument, Expression<Func<T>> expr)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(expr.GetParameterName());
            }
        }

        /// <summary>
        /// Check if argument is positive non zero number
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="expr"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerStepThrough]
        public static void IsNonZeroPositive<T>(int parameter, Expression<Func<T>> expr)
        {
            if (parameter <= 0)
            {
                throw new ArgumentException(Global.ArgumentCannotNonZero.FormatWith(expr.GetParameterName()), expr.GetParameterName());
            }
        }

        /// <summary>
        /// Check if argument is positive number
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="expr"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerStepThrough]
        public static void IsPositive<T>(int parameter, Expression<Func<T>> expr)
        {
            if (parameter < 0)
            {
                throw new ArgumentException(Global.ArgumentCannotNonZero.FormatWith(expr.GetParameterName()), expr.GetParameterName());
            }
        }
    }
}
