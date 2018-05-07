using System;
using Payvision.CodeChallenge.Base.Helpers;
using Refactoring.FraudDetection.Domain;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    /// <summary>
    /// Normalize fields of order
    /// </summary>
    public static class OrderNormalizer 
    {
        /// <summary>
        /// Normalize fields of order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static Order Normalize(Order order)
        {
            Guard.IsNotNull(order, () => order);

            //Normalize email
            var aux = order.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            order.Email = string.Join("@", new string[] { aux[0], aux[1] });

            //Normalize street
            order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");

            //Normalize state
            order.State = order.State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");

            return order;
        }
    }

}
