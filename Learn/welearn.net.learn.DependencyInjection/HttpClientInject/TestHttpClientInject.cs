using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using welearn.net.learn.DependencyInjection.LifeTime;
using welearn.net.learn.DependencyInjection.Resolver;

namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public class TestHttpClientInject {
    public static void Test() {
        var serviceCollection = new ServiceCollection()
                // .AddSingleton<AaaController>() it will overwrite by AddHttpClient
                // .AddTransient<BbbController>()
            ;
        serviceCollection.AddHttpClient<AaaController>(client =>
            client.BaseAddress = new Uri("https://aaa.remote.com")); //AddTransient AaaController
        serviceCollection.AddHttpClient<BbbController>(client =>
            client.BaseAddress = new Uri("https://bbb.remote.com")); //AddTransient BbbController

        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        
        var controllerA = serviceProvider.GetRequiredService<AaaController>();
        var controllerA2 = serviceProvider.GetRequiredService<AaaController>();
        Debug.Assert(!ReferenceEquals(controllerA, controllerA2));
        Debug.Assert(!ReferenceEquals(controllerA.HttpClientObj, controllerA2.HttpClientObj));

        var controllerB = serviceProvider.GetRequiredService<BbbController>();
        Debug.Assert(!ReferenceEquals(controllerA.HttpClientObj, controllerB.HttpClientObj));

        controllerA.PrintBaseAddress();
        controllerB.PrintBaseAddress();
    }
}