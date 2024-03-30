<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stripeDemo.aspx.cs" Inherits="stripeGetwayDemo.stripeDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Amount
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            <button type="button" id="btnCheckout" onclick="initiateCheckout()">Checkout</button>
            <asp:Button ID="btnPay" runat="server" Text="Pay" OnClick="btnPay_Click1" />
        </div>

        <script>
            function initiateCheckout() {
                var amountInCents = parseInt(document.getElementById('<%=txtAmount.ClientID%>').value) * 100;

                var stripe = Stripe('PublihableKey-From-Stripe-Dashbord'); // Replace with your actual publishable key

                var checkoutHandler = StripeCheckout.configure({
                    key: 'PublihKey-From-Stripe-Dashbord', // Replace with your actual publishable key
                    locale: 'auto',
                    token: function (token) {
                        // Append the token to the form data
                        var form = document.forms[0];
                        var hiddenField = document.createElement('input');
                        hiddenField.type = 'hidden';
                        hiddenField.name = 'token';
                        hiddenField.value = token.id;
                        form.appendChild(hiddenField);

                        // Continue with the payment process (e.g., form submission)
                        form.submit();
                    }
                });

                checkoutHandler.open({
                    name: 'Your Company Name',
                    description: 'Payment for services',
                    currency: 'usd', // Replace with your currency code if different
                    amount: amountInCents,
                });
            }
        </script>
    </form>
</body>
</html>
