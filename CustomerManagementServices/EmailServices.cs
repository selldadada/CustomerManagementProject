using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;

namespace CustomerManagementServices
{
    public class EmailServices
    {
        public void AddOrderEmail()
        {
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Sellda Tiktok Shop", "do-not-reply@SelldaTiktokShop.com"));
            message1.To.Add(new MailboxAddress("User", "user@example.com"));
            message1.Subject = "You have Received an Order!";

            message1.Body = new TextPart("html")
            {
                Text = "<img src='https://www.socialchamp.io/wp-content/uploads/2024/02/Content-Blog-Banner_Q1-2024_1125x600_023_Tiktok-Stats.png' style='width:300px; height:auto;' />" +
                "<h1>Hi, Sellda!</h1>" +
                "<p>Your shop - Sellda's Tiktok Shop, has received a new order.</p>" +
                "<p><strong>This email was sent to confirm a new order in your shop.</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("ace60a7c56e7f4", "b484711f0c90f9");

                    client.Send(message1);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        public void UpdateOrderEmail()
        {
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Sellda Tiktok Shop", "do-not-reply@SelldaTiktokShop.com"));
            message1.To.Add(new MailboxAddress("User", "user@example.com"));
            message1.Subject = "You have Updated an Order!";

            message1.Body = new TextPart("html")
            {
                Text = "<img src='https://www.socialchamp.io/wp-content/uploads/2024/02/Content-Blog-Banner_Q1-2024_1125x600_023_Tiktok-Stats.png' style='width:300px; height:auto;' />" +
                "<h1>Hi, Sellda!</h1>" +
                "<p>You have updated an order in your shop - Sellda's Tiktok Shop.</p>" +
                "<p><strong>This email was sent to confirm an order update in your shop.</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("ace60a7c56e7f4", "b484711f0c90f9");

                    client.Send(message1);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        public void DeleteOrderEmail()
        {
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Sellda Tiktok Shop", "do-not-reply@SelldaTiktokShop.com"));
            message1.To.Add(new MailboxAddress("User", "user@example.com"));
            message1.Subject = "You have Deleted an Order!";

            message1.Body = new TextPart("html")
            {
                Text = "<img src='https://www.socialchamp.io/wp-content/uploads/2024/02/Content-Blog-Banner_Q1-2024_1125x600_023_Tiktok-Stats.png' style='width:300px; height:auto;' />" +
                "<h1>Hi, Sellda!</h1>" +
                "<p>You have deleted an order in your shop - Sellda's Tiktok Shop.</p>" +
                "<p><strong>This email was sent to confirm an order deletion in your shop.</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("ace60a7c56e7f4", "b484711f0c90f9");

                    client.Send(message1);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}