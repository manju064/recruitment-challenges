using Refactoring.FraudDetection.Domain;

namespace Refactoring.FraudDetection.Dal
{
    /// <summary>
    /// Order query repository
    /// </summary>
    public class OrderQueryRepository : QueryRepositoryBase<Order>
    {
        /// <summary>
        /// Temporary place to populate the data
        /// </summary>
        public OrderQueryRepository()
        {
            Repository.AddRange(new[]
            {
                new Order(1, 1, "bugs@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689010"),
                new Order(2, 1, "bugs2@bunny.com", "123 Sesame St.", "New York", "NY", "10011", "12345689011"),
                new Order(3, 2, "roger@rabbit.com", "1234 Not Sesame St.", "Colorado", "CL", "10012", "12345689012"),
                new Order(4, 2, "roger@rabbit.com", "1234 Not Sesame St.", "Colorado", "CL", "10012", "12345689014")
            });
        }
    }
}
