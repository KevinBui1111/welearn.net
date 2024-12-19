using Microsoft.Extensions.Options;
using welearn.net.learn.DependencyInjection.Resolver;

namespace welearn.net.learn.DependencyInjection.Config;

public class KevinController {
    public KevinController(IOptions<CalcPhase> calOptions) {
        Console.WriteLine($"{GetType()} Init");
        Phase = calOptions.Value;
    }

    public CalcPhase Phase { get; }
}

public class GluttonController {
    public GluttonController(IOptions<CalcPhase> calOptions) {
        Console.WriteLine($"{GetType()} Init");
        Phase = calOptions.Value;
    }

    public CalcPhase Phase { get; }
}