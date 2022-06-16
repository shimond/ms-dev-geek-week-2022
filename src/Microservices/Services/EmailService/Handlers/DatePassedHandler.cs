using EmailService.Contracts;
using EmailService.Messaging;
using Infrastructure.Messaging.Contract;

namespace EmailService.Handlers;

public class DatePassedHandler : EventBusHandler<DatePassedEvent>
{
    private readonly IEmailSenderService emailSenderService;

    public DatePassedHandler(IEmailSenderService emailSenderService)
    {
        this.emailSenderService = emailSenderService;
    }
    public async override Task Handle(DatePassedEvent @event)
    {
        await emailSenderService.SendEmail("Day passed!", "Body", new string[] { "Shimond@any-techs.co.il" }, new string[] { });
    }
}
