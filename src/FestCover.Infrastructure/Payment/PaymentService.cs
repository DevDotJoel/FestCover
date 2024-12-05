using ErrorOr;
using FestCover.Application.Common.Contracts;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
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

        public async Task<ErrorOr<string>> AddSubscription(string customerId,string productId)
        {
            var productService = new ProductService();
            var product= await productService.GetAsync(productId);

            if(product == null)
            {
                return Error.NotFound(description: $"Product with the id {productId} not found ");
            }

            var customerService = new CustomerService();
            var customer = await customerService.GetAsync(customerId);

            if (customer == null)
            {
                return Error.NotFound(description: $"Customer with the id {customerId} not found ");
            }
            var options = new SessionCreateOptions
            {
                // See https://stripe.com/docs/api/checkout/sessions/create
                // for additional parameters to pass.
                // {CHECKOUT_SESSION_ID} is a string literal; do not change it!
                // the actual Session ID is returned in the query parameter when your customer
                // is redirected to the success page.
                SuccessUrl = "https://example.com/success.html?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://example.com/canceled.html",
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                  {
                    new SessionLineItemOptions
                    {
                      Price = product.DefaultPriceId,
                      // For metered billing, do not pass quantity
                      Quantity = 1,
                    },
                  },
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);
            return session.Url;

        }

        public async Task<string> SearchProduct(string name)
        {
            var options = new ProductSearchOptions
            {
                Query = $"active:'true' AND name:'${name}'",
            };
            var service = new ProductService();
            var product=await service.SearchAsync(options);
            return product.Data[0].Id;
        }
    }
}
