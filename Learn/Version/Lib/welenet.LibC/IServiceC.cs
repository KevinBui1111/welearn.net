namespace welenet.LibC;

public interface IServiceC {
    //0.1 Foo
    //0.3 Foo2
    void Foo2();
    //0.2
    void Bar();
}

public class ServiceC : IServiceC {
    //0.1 Foo
    //0.3 Foo2
    public void Foo2() {
        Console.WriteLine("ServiceC.Foo2");
    }
    //0.2
    public void Bar() {
        Console.WriteLine("ServiceC.Bar");
    }
}
