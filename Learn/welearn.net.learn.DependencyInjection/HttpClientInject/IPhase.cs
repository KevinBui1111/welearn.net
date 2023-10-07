namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public interface IPhase : IGuidId { }

public class PhaseA : TypeAndId, IPhase { }
public class PhaseB : TypeAndId, IPhase { }