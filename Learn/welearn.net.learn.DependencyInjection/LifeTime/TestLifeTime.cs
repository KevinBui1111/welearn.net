using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace welearn.net.learn.DependencyInjection.LifeTime;

public class TestLifeTime {
    public static void Test() {
        var otherSingleton = new OtherSingleton();
        var otherSingleton2 = new OtherSingleton();
        
        var serviceProvider = new ServiceCollection()
            .AddTransient<LifetimeReporter>()
            .AddScoped<IExampleScope, ExampleScope>()
            .AddTransient(typeof(IExampleTransient), typeof(ExampleTransient))
            .AddSingleton<IExampleSingleton, ExampleSingleton>()
            .AddSingleton(otherSingleton)
            .AddSingleton(otherSingleton2)
            .AddSingleton(_ => {
                Console.WriteLine("create ActionSingleton");
                return new ActionSingleton();
            })
            .AddLogging(l => l.AddConsole())
            .BuildServiceProvider();

        ReportInScope(serviceProvider, "scope 1");
        ReportInScope(serviceProvider, "scope 2");

        var other = serviceProvider.GetRequiredService<OtherSingleton>();
        Debug.Assert(!ReferenceEquals(other, otherSingleton));
        Debug.Assert(ReferenceEquals(other, otherSingleton2));

        var action = serviceProvider.GetRequiredService<ActionSingleton>();
        Console.WriteLine("get ActionSingleton again");
        var action2 = serviceProvider.GetRequiredService<ActionSingleton>();
        Debug.Assert(ReferenceEquals(action, action2));
    }

    private static void ReportInScope(IServiceProvider serviceProvider, string scopeName) {
        Console.WriteLine($"\n--- New scope: {scopeName} ---");
        using var srvScope = serviceProvider.CreateScope();
        
        var sp = srvScope.ServiceProvider;
        Debug.Assert(!ReferenceEquals(serviceProvider, sp));

        var reporter = sp.GetRequiredService<LifetimeReporter>();
        reporter.Report(scopeName);

        var reporter2 = sp.GetRequiredService<LifetimeReporter>();
        Debug.Assert(!ReferenceEquals(reporter, reporter2));
        reporter2.Report(scopeName);
    }
}