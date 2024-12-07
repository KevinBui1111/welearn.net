using welenet.LibC;

namespace welenet.LibB;

public class ClassB {
    // 0.1
    public void Foo() {
        Console.WriteLine("ClassB.Foo");
    }
    // 0.2, remove Bar - 0.3
    // public void Bar() {
    //     Console.WriteLine("ClassB.Bar");
    // }

    // 0.4
    public void ReferCxFoo() {
        Console.WriteLine("ClassA.ReferBxBar");
        new ServiceC().Foo();
    }
    // 0.5
    public void ReferCxBar() {
        Console.WriteLine("ClassC.ReferBxBar");
        new ServiceC().Bar();
    }
}