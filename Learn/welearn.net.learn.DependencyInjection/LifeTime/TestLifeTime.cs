using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace welearn.net.learn.DependencyInjection.LifeTime;

public class TestLifeTime {
    public static void Test() {
        var serviceProvider = new ServiceCollection()
            .AddTransient<LifetimeReporter>()
            .AddScoped<IExampleScope, ExampleScope>()
            .AddTransient(typeof(IExampleTransient), typeof(ExampleTransient))
            .AddSingleton<IExampleSingleton, ExampleSingleton>()
            .BuildServiceProvider();

        ReportInScope(serviceProvider, "scope 1");
        ReportInScope(serviceProvider, "scope 2");
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