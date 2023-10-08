namespace welearn.net.learn.DependencyInjection.Resolver; 

public interface INotifier {
    void Notify();
}

public abstract class Counter {
    public static int NumInstance = 0;

    protected Counter() {
        ++NumInstance;
        Console.WriteLine($"Init {GetType().Name}");
    }
}

public class SmsNotifier : Counter, INotifier {
    public void Notify() => Console.WriteLine($"{GetType().Name} emit notification!");
}

public class EmailNotifier : Counter, INotifier {
    public void Notify() => Console.WriteLine($"{GetType().Name} emit notification!");
}