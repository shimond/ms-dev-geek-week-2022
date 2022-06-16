using EmailService.Contracts;
using System.Net.Mail;

namespace EmailService.Services;

public class EmailSenderService : IEmailSenderService
{
    public async Task SendEmail(string Subject, string Body, string[] to, string[] filesPath)
    {
        MailMessage msg = new MailMessage();
        foreach (var item in to)
        {
            msg.To.Add(new MailAddress(item));
        }

        msg.From = new MailAddress("shimon@cguard.co.il", "Shimon Dahan (cguard)");
        msg.Subject = Subject;
        msg.Body = Body;
        msg.IsBodyHtml = true;
        foreach (var item in filesPath)
        {
            msg.Attachments.Add(new Attachment(item));

        }
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("shimon@cguard.co.il", "How21558");
        client.Port = 587;
        client.Host = "smtp.office365.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        await client.SendMailAsync(msg);
    }

}


