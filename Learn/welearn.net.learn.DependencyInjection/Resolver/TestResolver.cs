using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using welearn.net.learn.DependencyInjection.LifeTime;

namespace welearn.net.learn.DependencyInjection.Resolver;

public delegate INotifier NotifierResolver(string key);

public class TestResolver {
    public static void Test() {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<INotifier, EmailNotifier>()
            .AddSingleton<INotifier, SmsNotifier>()
            .AddSingleton<SmsNotifier>()
            .AddSingleton<EmailNotifier>()
            .AddTransient<FirstController>()
            .AddTransient<SecondController>()
            .AddSingleton<NotifierResolver>(sp =>
                key => key switch {
                    "Email" => sp.GetRequiredService<EmailNotifier>(),
                    "Sms" => sp.GetRequiredService<SmsNotifier>(),
                    _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
                }
            )
            .BuildServiceProvider();

        var controller = serviceProvider.GetRequiredService<FirstController>();
        controller.Foo();
        Console.WriteLine(Counter.NumInstance); //2

        var controller2 = serviceProvider.GetRequiredService<SecondController>();
        controller2.Foo();
        Console.WriteLine(Counter.NumInstance); //2
    }
}