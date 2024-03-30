using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace stripeGetwayDemo
{
    public partial class stripeDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "'PublihableKey-From-Stripe-Dashbord'"; // Replace with your actual publishable key
        }

        protected void btnPay_Click1(object sender, EventArgs e)
        {
            try
            {
                // Create a Checkout Session
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "inr", // Replace with your currency code if different
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Your Product Name",
                        },
                        UnitAmount = 1000, // Replace with the actual amount in cents
                    },
                    Quantity = 1,
                },
            },
                    Mode = "payment",
                    SuccessUrl = "https://localhost:44350/barChartExample.aspx", // Replace with your success URL
                    CancelUrl = "https://localhost:44350/stripDemo.aspx", // Replace with your cancel URL
                };

                var service = new SessionService();
                Session session = service.Create(options);

                // Redirect to the Checkout page
                Response.Redirect(session.Url, true);
            }
            catch (StripeException ex)
            {
                // Handle Stripe exceptions
                Response.Write("Payment Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Response.Write("Payment Error: " + ex.Message);
            }
        }

    }
}