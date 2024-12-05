using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Application.Common.Contracts
{
    public interface IPaymentService
    {
        Task<string> CreateCustomer(string name, string email);
        Task UpdateCustomer(string id, string name, string email);
        Task<string> SearchProduct(string name);
        Task<ErrorOr<string>> AddSubscription(string customerId, string productId);
        Task<ErrorOr<string>> GetProductById(string productId);
        Task<ErrorOr<Success>> UpdateSubscription(string customerId, string productId);
        Task<ErrorOr<string>> GetProductIdBySubscriptionId(string subscriptionId);
    }
}
