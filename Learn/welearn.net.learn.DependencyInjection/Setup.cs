using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using welearn.net.learn.DependencyInjection.Service;

namespace welearn.net.learn.DependencyInjection; 

internal class Setup
{
    public static void setup_di()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(l => l.AddConsole())
            .AddSingleton<IFooService, FooService>()
            .AddSingleton<IBarService, BarService>()
            .AddSingleton<IBoxRepo, BoxRepo>()
            .BuildServiceProvider();
        ;
        //configure console logging

        var bar = serviceProvider.GetService<IBoxRepo>();
        bar.find_box();
        bar.save();

        var bar2 = serviceProvider.GetService<IBoxRepo>();
        Console.WriteLine(bar == bar2);
        var abs = (AbsBaseRepo)bar;
        abs.save();

        var logger = serviceProvider.GetService<ILogger<IBoxRepo>>();
        try
        {
            throw new ApplicationException("intend exception");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "");
        }
    }
}