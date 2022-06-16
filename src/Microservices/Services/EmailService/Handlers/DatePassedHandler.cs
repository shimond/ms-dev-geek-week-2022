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
    public override Task Handle(DatePassedEvent @event)
    {
        Console.WriteLine("PASSED" );
        return Task.CompletedTask;
    }
}
