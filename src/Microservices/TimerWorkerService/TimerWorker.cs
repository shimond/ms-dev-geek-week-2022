using Infrastructure.Messaging.Contract;
using TimerWorkerService.Messaging;

namespace TimerWorkerService;

public class TimerWorker : BackgroundService
{
    private readonly ILogger<TimerWorker> _logger;
    private readonly IEventBus _eventBus;
    private DateTime _lastTime;
    public TimerWorker(ILogger<TimerWorker> logger, IEventBus eventBus)
    {
        _logger = logger;
        _eventBus = eventBus;
        _lastTime = DateTime.Today;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(10000, stoppingToken);
            if (DateTime.Now.Subtract(_lastTime).Days == 1)
            {
                await _eventBus.Publish(new DatePassedEvent());
            }
        }
    }
}