using welenet.LibC;

namespace welenet.LibD;

public class ClassD
{
    //0.1
    public void ReferBxBar() {
        Console.WriteLine("ClassD.ReferBxBar");
        new ServiceC().Foo();
    }
}
