namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public interface IServiceX : IGuidId { }

public abstract class ServiceX : TypeAndId, IServiceX {
    public IRepo Repo { get; }

    public ServiceX(IRepo repo) {
        Repo = repo;
    }
}

public class ServiceA : ServiceX {
    public ServiceA(IRepo repo) : base(repo) { }
}
public class ServiceB : ServiceX {
    public ServiceB(IRepo repo) : base(repo) { }
}
public class ServiceC : ServiceX {
    public ServiceC(IRepo repo) : base(repo) { }
}