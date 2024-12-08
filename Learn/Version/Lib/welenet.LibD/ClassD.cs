using welenet.LibB;
using welenet.LibC;
using welenet.LibE;

namespace welenet.LibD;

public class ClassD
{
    //0.1
    public void ReferBxBar() {
        Console.WriteLine("ClassD.ReferBxBar");
        // new ServiceC().Foo();
    }
    //0.2
    public void ReferBxReferExFoo() {
        Console.WriteLine("ClassD.ReferBxBar");
        new ClassE().Foo();
    }
}
