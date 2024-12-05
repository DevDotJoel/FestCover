using ErrorOr;
using FestCover.Application.Common.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace FestCover.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ApiController
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public PaymentsController(IIdentityService identityService, IUserService userService, IConfiguration configuration)
        {
            _identityService = identityService;
            _userService = userService;
            _config = configuration;

        }

        [HttpGet("success")]
        public async Task<IActionResult> WebHook([FromQuery] string customerId,string productId)
        {


            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            Event stripeEvent;
            try
            {
               stripeEvent = EventUtility.ParseEvent(json);
                
            }
            catch (Exception e)
            {
                return Problem();
            }

            if (stripeEvent.Type == "invoice.payment_succeeded")
            {
                var invoice = stripeEvent.Data.Object as Invoice;
                var result = await _identityService.UpdateUserSubscription(invoice.CustomerId, invoice.SubscriptionId);
                return result.Match( _ => Ok(), Problem);
            }

            if (stripeEvent.Type == "invoice.payment_failed")
            {
                // If the payment fails or the customer does not have a valid payment method,
                // an invoice.payment_failed event is sent, the subscription becomes past_due.
                // Use this webhook to notify your user that their payment has
                // failed and to retrieve new card details.
            }

            if (stripeEvent.Type == "customer.subscription.deleted")
            {
                // handle subscription canceled automatically based
                // upon your subscription settings. Or if the user cancels it.
            }
            return Problem();
        }

    }
}
