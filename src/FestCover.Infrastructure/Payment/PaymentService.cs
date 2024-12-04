using FestCover.Application.Common.Contracts;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestCover.Infrastructure.Payment
{
    public class PaymentService: IPaymentService
    {
        private readonly IConfiguration _config;
        private string apiKey;
        public PaymentService(IConfiguration config)
        {
            _config = config;
            StripeConfiguration.ApiKey = _config["Stripe:ApiKey"];
        }

        public async Task<string> CreateCustomer(string name,string email)
        {

            var options = new CustomerCreateOptions
            {
                Name = name,
                Email = email,
            };
            var service = new CustomerService();
            var customer=await service.CreateAsync(options);
            return customer.Id;
        }

        public async Task UpdateCustomer(string id,string name,string email)
        {
            var options = new CustomerUpdateOptions
            {
                Name=name,
                Email=email,

            };
            var service = new CustomerService();
            await service.UpdateAsync(id, options);
        }
    }
}
