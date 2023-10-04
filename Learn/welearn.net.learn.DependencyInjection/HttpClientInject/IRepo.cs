namespace welearn.net.learn.DependencyInjection.HttpClientInject; 

public interface IRepo {
    string Save();
}

public abstract class Repo : IRepo {
    public string Save() {
        return $"Save {GetType()}";
    }
}

public class RepoA : Repo { }
public class RepoB : Repo { }