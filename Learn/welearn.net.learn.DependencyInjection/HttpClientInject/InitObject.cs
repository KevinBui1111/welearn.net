using Microsoft.Extensions.DependencyInjection;

namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public class InitObject {
    public static void Test() {
        var serviceProvider = new ServiceCollection()
                .AddSingleton<ServiceA>()
                .AddSingleton<IRepo, RepoA>()
                .AddSingleton<IPhase, PhaseA>()
                .AddSpecificSingleton<ControllerA, IServiceX, ServiceA>()
                .AddSingleton<IPhase, PhaseA>()
                .AddSingleton<ControllerB>()
                .BuildServiceProvider()
            ;
        var controllerA = serviceProvider.GetRequiredService<ControllerA>();
        var controllerB = serviceProvider.GetRequiredService<ControllerB>();

        // var activator = ActivatorUtilities.CreateFactory(typeof(CccController), new Type[] { typeof(ServiceA) });
        // var c = activator(serviceProvider, new object?[] { new ServiceA() });
        // var activator = ActivatorUtilities.CreateFactory(typeof(CccController), Array.Empty<Type>());
        // var c = activator(serviceProvider, Array.Empty<object?>());

        // var a = new ServiceA();
        // var b = new ServiceB();
        // var cc = ActivatorUtilities.CreateInstance(serviceProvider, typeof(CccController), b, a);
    }
}