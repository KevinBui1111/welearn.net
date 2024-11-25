using welenet.LibB;

namespace welenet.LibA;

public class ClassA {
    public void Foo() {
        Console.WriteLine("ClassA.Foo");
    }

    public void Bar() {
        Console.WriteLine("ClassA.Bar");
    }

    // 1.1.1
    public void ReferBxBar() {
        Console.WriteLine("ClassA.ReferBxBar");
        new ClassB().Bar();
    }
}