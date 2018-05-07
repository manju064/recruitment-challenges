using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.DomainObjects
{
    public class FraudResult : IEquatable<FraudResult>
    {
        public int OrderId { get; set; }

        public bool IsFraudulent { get; set; }

        public bool Equals(FraudResult other)
        {
            return this.OrderId == other.OrderId &&
                   this.IsFraudulent == other.IsFraudulent;
        }
    }
}
