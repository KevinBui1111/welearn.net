using Microsoft.Extensions.Logging;

namespace welearn.net.learn.DependencyInjection.Service;

internal class FooService : IFooService
{
    private readonly ILogger<FooService> _logger;

    public FooService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FooService>();
    }

    public void DoThing(string number)
    {
        //Console.WriteLine("DoThing");
        _logger.LogInformation(4, $"Doing the thing {number}");
        //Console.WriteLine("DoThing 2");
    }
}