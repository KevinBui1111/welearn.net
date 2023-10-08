using Microsoft.Extensions.Logging;

namespace welearn.net.learn.DependencyInjection.LifeTime;

internal sealed class LifetimeReporter {
    private readonly IExampleTransient _transientService;
    private readonly IExampleScope _scopedService;
    private readonly IExampleSingleton _singletonService;
    private readonly ILogger<LifetimeReporter> _logger;

    private static int _id = 0;
    public int Id { get; } = ++_id;

    public LifetimeReporter(
        IExampleTransient transientService,
        IExampleScope scopedService,
        IExampleSingleton singletonService,
        ILogger<LifetimeReporter> logger
    ) =>
        (_transientService, _scopedService, _singletonService, _logger) =
        (transientService, scopedService, singletonService, logger);

    public void Report(string scopeName) {
        Console.WriteLine($"Id: {Id}, {scopeName}");

        LogService(_transientService, "Always different");
        LogService(_scopedService, "Changes only with lifetime");
        LogService(_singletonService, "Always the same");
    }

    private void LogService<T>(T service, string message)
        where T : IServiceLifetime {
        // Console.WriteLine($"  {typeof(T).Name}: {service.Id} ({message})");
        _logger.LogInformation(11, $"  {typeof(T).Name}: {service.Id} ({message})");
    }
}