using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSMTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sellda Tiktok Shop", "do-not-reply@SelldaTiktokShop.com"));
            message.To.Add(new MailboxAddress("User", "user@example.com"));
            message.Subject = "You have Received an Order!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Hi, Sellda!</h1>" +
                "<p>Your shop - Sellda's Tiktok Shop, has received a new order.</p>" +
                "<p><strong>This email was sent to confirm a new order in your shop.</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("ace60a7c56e7f4", "b484711f0c90f9");

                    client.Send(message);
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