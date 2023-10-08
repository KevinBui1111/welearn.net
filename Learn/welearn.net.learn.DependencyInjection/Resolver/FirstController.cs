namespace welearn.net.learn.DependencyInjection.Resolver;

public class FirstController {
    private readonly INotifier _notifier;
    private readonly IEnumerable<INotifier> _notifiers;

    public FirstController(INotifier notifier, IEnumerable<INotifier> notifiers) {
        Console.WriteLine($"FirstController Init");
        _notifier = notifier;
        _notifiers = notifiers;
    }

    public void Foo() => _notifier.Notify();
}