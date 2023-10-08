namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public abstract class ControllerX {
    public IServiceX ServiceX { get; }
    public IPhase ThePhase { get; }

    public ControllerX(IServiceX serviceX, IPhase phase) {
        (ServiceX, ThePhase) = (serviceX, phase);
    }
}

public class ControllerA : ControllerX {
    public ControllerA(IServiceX serviceX, IPhase phase) : base(serviceX, phase) { }
}

public class ControllerB : ControllerX {
    public ControllerB(IServiceX serviceX, IPhase phase) : base(serviceX, phase) { }
}

public class ControllerC : ControllerX {
    public ControllerC(IServiceX serviceX, IPhase phase) : base(serviceX, phase) { }
}