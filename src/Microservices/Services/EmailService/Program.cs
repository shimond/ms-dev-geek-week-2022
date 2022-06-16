using EmailService;
using EmailService.Contracts;
using EmailService.Handlers;
using EmailService.Messaging;
using EmailService.Services;
using Infra.RabbitMQ;
using Infrastructure.Messaging.Contract;
using Infrastructure.Messaging.Model.Configuration;
using Infrastructure.Messaging.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services)=>
    {
        services.Configure<EventBusConfiguration>(hostContext.Configuration.GetSection("EventBus"));
        services.AddTransient<IMessageSerializer, JsonMessageSerializer>();
        services.AddSingleton<IEventBus, RabbitEventBus>();
        services.AddTransient<IEmailSenderService, EmailSenderService>();
        services.AddTransient<EventBusHandler<DatePassedEvent>, DatePassedHandler>();
        services.AddHostedService<EmailWorker>();
    })
    .Build();

var eventBus = host.Services.GetRequiredService<IEventBus>();
await eventBus.Subscribe<DatePassedEvent, EventBusHandler<DatePassedEvent>>();
await host.RunAsync();
