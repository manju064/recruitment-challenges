using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payvision.CodeChallenge.Base.Helpers;
using Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    
    public static class OrderNormalizer 
    {
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
