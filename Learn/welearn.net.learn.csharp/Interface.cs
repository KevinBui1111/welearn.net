namespace welearn.net.learn.csharp;

interface IParentInterface {
    string Name { get; set; }
    void MethodA();
    void MethodB();
}

interface IChildInterface : IParentInterface {
    new string Name { get; }
    new void MethodA();
    void PropertyC();
}

internal class ChildImplement : IChildInterface {
    string IChildInterface.Name => "ChildImplement Name";

    string IParentInterface.Name {
        get => "ChildImplement";
        set { }
    }

    public void MethodA() => Console.WriteLine("MethodA");
    public void PropertyC() => Console.WriteLine("MethodC");
    public void MethodB() => Console.WriteLine("MethodB");
}

public class PracticeInterface {
    public static void Test() {
        var child = new ChildImplement();
        IParentInterface parent = child;
        IChildInterface iChild = child;
        // child.Name = "aaa"; Compiler error
        parent.Name = "aaa";
        // var a = child.Name; // cannot access
        Console.WriteLine(iChild.Name);
        Console.WriteLine(parent.Name);
        child.MethodA();
        parent.MethodA();
        iChild.MethodA();
    }
}