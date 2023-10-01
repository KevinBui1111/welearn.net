using Microsoft.Extensions.DependencyInjection;

namespace welearn.net.learn.DependencyInjection.LifeTime;

public interface IServiceLifetime {
    Guid Id { get; }
    ServiceLifetime Lifetime { get; }
}

public interface IExampleTransient : IServiceLifetime { }

public interface IExampleScope : IServiceLifetime { }

public interface IExampleSingleton : IServiceLifetime { }

public class ExampleTransient : IExampleTransient {
    public Guid Id { get; } = Guid.NewGuid();
    public ServiceLifetime Lifetime => ServiceLifetime.Transient;
}

public class ExampleScope : IExampleScope {
    public Guid Id { get; } = Guid.NewGuid();
    public ServiceLifetime Lifetime => ServiceLifetime.Scoped;
}

public class ExampleSingleton : IExampleSingleton {
    public Guid Id { get; } = Guid.NewGuid();
    public ServiceLifetime Lifetime => ServiceLifetime.Singleton;
}