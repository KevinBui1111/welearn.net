namespace welearn.net.learn.DependencyInjection.Resolver; 

public interface IDelivery { }

public interface INationDelivery : IDelivery { }

public class FastDeliveryService : INationDelivery { }