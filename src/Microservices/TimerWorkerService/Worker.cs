using Infrastructure.Messaging.Contract;
using TimerWorkerService.Messaging;

namespace TimerWorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IEventBus _eventBus;

    public Worker(ILogger<Worker> logger, IEventBus eventBus)
    {
        _logger = logger;
        _eventBus = eventBus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(10000, stoppingToken);
            await _eventBus.Publish(new DatePassedEvent());
        }
    }
}