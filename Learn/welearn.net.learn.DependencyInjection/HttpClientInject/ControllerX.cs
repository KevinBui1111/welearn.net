namespace welearn.net.learn.DependencyInjection.HttpClientInject; 

public class ControllerA {
    private readonly IServiceX _serviceX;
    private readonly IPhase _phase;

    public ControllerA(IServiceX serviceX, IPhase phase) {
        (_serviceX, _phase) = (serviceX, phase);
    }

    public string ServiceId => _serviceX.Id.ToString()[..5];
    public string PhaseHandle => _phase.Handle();
}

public class ControllerB {
    private readonly IServiceX _serviceX;
    private readonly IPhase _phase;

    public ControllerB(IServiceX serviceX, IPhase phase) {
        (_serviceX, _phase) = (serviceX, phase);
    }

    public string ServiceId => _serviceX.Id.ToString()[..5];
    public string PhaseHandle => _phase.Handle();
}