using Infra.RabbitMQ;
using Infrastructure.Messaging.Contract;
using Infrastructure.Messaging.Model.Configuration;
using Infrastructure.Messaging.Services;
using TimerWorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services)=>
    {
        services.Configure<EventBusConfiguration>(hostContext.Configuration.GetSection("EventBus"));
        services.AddTransient<IMessageSerializer, JsonMessageSerializer>();
        services.AddSingleton<IEventBus, RabbitEventBus>();
        services.AddHostedService<TimerWorker>();

    })
    .Build();

await host.RunAsync();
