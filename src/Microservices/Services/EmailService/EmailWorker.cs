using Infrastructure.Messaging.Contract;

namespace EmailService
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly IEventBus _eventBus;

        public EmailWorker(ILogger<EmailWorker> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        protected override  async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TaskCompletionSource source = new TaskCompletionSource();
            stoppingToken.Register(() => source.SetCanceled());
            await source.Task;
        }

    }
}