namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public interface IRepo : IGuidId {
}

public class RepoA : TypeAndId, IRepo { }
public class RepoB : TypeAndId, IRepo { }