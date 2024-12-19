using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using welearn.net.learn.DependencyInjection.LifeTime;

namespace welearn.net.learn.DependencyInjection.Config;

public class TestConfig {
    public static void Test() {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var section = config.GetSection("CalcPhaseOption");
        // section.Get return null in case CalcPhaseOption is not defined in appsetting.json
        var c1 = section.Get<CalcPhase>();
        var c2 = section.Get<CalcPhase>();
        Debug.Assert(!ReferenceEquals(c1, c2));

        var serviceProvider = new ServiceCollection()
            .AddSingleton<KevinController>()
            .AddSingleton<GluttonController>()
            .Configure<CalcPhase>(config.GetSection("CalcPhaseOption"))
            .BuildServiceProvider();

        var controllerKevin = serviceProvider.GetRequiredService<KevinController>();
        var controllerGlutton = serviceProvider.GetRequiredService<GluttonController>();
        Debug.Assert(controllerKevin.Phase != null);
        Debug.Assert(ReferenceEquals(controllerGlutton.Phase, controllerKevin.Phase));
        Debug.Assert(!ReferenceEquals(c1, controllerKevin.Phase));
    }
}