using EmailService.Configuration;
using EmailService.Contracts;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace EmailService.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly SmtpOptions _smtpOptions;
    public EmailSenderService(IOptions<SmtpOptions> smtpOptions)
    {
        _smtpOptions = smtpOptions.Value;
    }
    public async Task SendEmail(string Subject, string Body, string[] to, string[] filesPath)
    {
        MailMessage msg = new MailMessage();
        foreach (var item in to)
        {
            msg.To.Add(new MailAddress(item));
        }

        msg.From = new MailAddress(_smtpOptions.From, _smtpOptions.FromDisplay);
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
        client.Credentials = new System.Net.NetworkCredential(_smtpOptions.UserName, _smtpOptions.Password);
        client.Port = _smtpOptions.Port;
        client.Host = _smtpOptions.Host;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        await client.SendMailAsync(msg);
    }

}


