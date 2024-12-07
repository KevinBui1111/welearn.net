namespace welenet.LibC;

public interface IServiceC {
    //0.1
    void Foo();
    //0.2
    void Bar();
}

public class ServiceC : IServiceC {
    //0.1
    public void Foo() {
        Console.WriteLine("ServiceC.Foo");
    }
    //0.2
    public void Bar() {
        Console.WriteLine("ServiceC.Bar");
    }
}
