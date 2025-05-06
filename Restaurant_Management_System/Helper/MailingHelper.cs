using SendGrid.Helpers.Mail;
using SendGrid;

namespace Restaurant_Management_System.Helper
{
    public static class MailingHelper
    {
        public static async Task SendEmail(string email, int code, string title, string message)
        {
            var apiKey = " ";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ahmadmadaljeh@gmail.com", "Restaurant_Management_System_Team7");
            var subject = title;
            var to = new EmailAddress(email, "RMS User");
            var plainTextContent = $"Dear User {message}  Please Use The Following OTP Code {code} ";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, "");
            var response = await client.SendEmailAsync(msg);
        }
    }
}
