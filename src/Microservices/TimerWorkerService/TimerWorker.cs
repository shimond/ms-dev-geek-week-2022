using Infrastructure.Messaging.Contract;
using TimerWorkerService.Messaging;

namespace TimerWorkerService;

public class TimerWorker : BackgroundService
{
    private readonly ILogger<TimerWorker> _logger;
    private readonly IEventBus _eventBus;

    public TimerWorker(ILogger<TimerWorker> logger, IEventBus eventBus)
    {
        _logger = logger;
        _eventBus = eventBus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
            await _eventBus.Publish(new DatePassedEvent());
        }
    }
}