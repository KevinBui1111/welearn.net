namespace welearn.net.learn.DependencyInjection.HttpClientInject; 

public interface IGuidId {
    string Id { get; }
}

public abstract class TypeAndId : IGuidId {
    protected TypeAndId() {
        Id = $"{GetType().Name}-{Guid.NewGuid().ToString()[..7]}";
    }
    public string Id { get; }
}