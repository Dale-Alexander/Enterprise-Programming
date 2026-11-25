using Common.Interfaces;
using System.Net;

namespace WebApplication1.Factory
{
    public class AvailableNotificationStrategy : INotificationStrategy
    {
        public void Notify(string applicantEmail, string adminEmail, string message)
        {
            System.IO.File.AppendAllLines("successbookings.log", new List<string>() { message });

            System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage("noreply@ourlibrary.com", applicantEmail);
            mm.Subject = "Failed Booking";
            mm.Body = "Dear member, Your reservation was successfully saved. Please respect the return date. <br/>"
                       + message;
            mm.IsBodyHtml = true;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 586);
            client.Credentials = new NetworkCredential("username", "password");
            client.Send(mm);
        }
    }
}
