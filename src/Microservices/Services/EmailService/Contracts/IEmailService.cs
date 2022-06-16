using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Contracts
{
    public interface IEmailSenderService
    {
        Task SendEmail(string Subject, string Body, string[] to, string[] filesPath);

    }
}
