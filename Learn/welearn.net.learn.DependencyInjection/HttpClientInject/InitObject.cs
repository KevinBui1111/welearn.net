using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public class InitObject {
    public static void Test() {
        var serviceProvider = new ServiceCollection()
                .AddSingleton<IServiceX, ServiceC>()
                .AddSingleton<ServiceA>()
                .AddSingleton<ServiceB>()
                .AddSingleton<IRepo, RepoA>()
                .AddSingleton<IPhase, PhaseA>()
                .AddSpecificSingleton<ControllerA, ServiceB>()
                .AddSpecificSingleton<ControllerB, ServiceA>()
                .AddSingleton<ControllerC>()
                .BuildServiceProvider()
            ;
        var controllerA = serviceProvider.GetRequiredService<ControllerA>();
        var controllerB = serviceProvider.GetRequiredService<ControllerB>();
        var controllerC = serviceProvider.GetRequiredService<ControllerC>();
        Debug.Assert(controllerA.ServiceX is ServiceB);
        Debug.Assert(controllerB.ServiceX is ServiceA);
        Debug.Assert(controllerC.ServiceX is ServiceC);

        var serviceX1 = (ServiceX)controllerA.ServiceX;
        var serviceX2 = (ServiceX)controllerB.ServiceX;
        Debug.Assert(ReferenceEquals(serviceX1.Repo, serviceX2.Repo));

        // var activator = ActivatorUtilities.CreateFactory(typeof(CccController), new Type[] { typeof(ServiceA) });
        // var c = activator(serviceProvider, new object?[] { new ServiceA() });
        // var activator = ActivatorUtilities.CreateFactory(typeof(CccController), Array.Empty<Type>());
        // var c = activator(serviceProvider, Array.Empty<object?>());

        // var a = new ServiceA();
        // var b = new ServiceB();
        // var cc = ActivatorUtilities.CreateInstance(serviceProvider, typeof(CccController), b, a);
    }
}