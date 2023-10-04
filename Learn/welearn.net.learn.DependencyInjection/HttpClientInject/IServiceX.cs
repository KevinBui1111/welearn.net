namespace welearn.net.learn.DependencyInjection.HttpClientInject; 

public interface IServiceX : IGuidId {
    
}

public abstract class ServiceX : IServiceX {
    public Guid Id { get; } = Guid.NewGuid();
}

public class ServiceA : ServiceX {
    private readonly IRepo _repo;

    public ServiceA(IRepo repo) {
        _repo = repo;
    }
}

public class ServiceB : ServiceX { }