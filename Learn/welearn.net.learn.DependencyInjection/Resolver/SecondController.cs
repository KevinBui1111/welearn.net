namespace welearn.net.learn.DependencyInjection.Resolver;

public class SecondController {
    private readonly INotifier _notifier;

    public SecondController(INotifier notifier, NotifierResolver notifierResolver) {
        Console.WriteLine($"SecondController Init");
        _notifier = notifierResolver("Sms");
    }

    public void Foo() => _notifier.Notify();
}