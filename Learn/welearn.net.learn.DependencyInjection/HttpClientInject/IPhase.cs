namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public interface IPhase {
    string Handle();
}

public abstract class Phase : IPhase {
    public string Handle() {
        return $"Handle {GetType()}";
    }
}

public class PhaseA : Phase { }
public class PhaseB : Phase { }