namespace welearn.net.learn.OOP;

public class Parent {
    private readonly string _className;
    
    public Parent() {
        _className = "Parent";
        Console.WriteLine($"{_className} is created");
    }

    public void Method_A() {
        Console.WriteLine($"{_className} Method_A");
    }
    
    public void Method_A1() {
        Console.WriteLine($"{_className} Method_A1");
    }

    protected void Method_B() {
        Console.WriteLine($"{_className} Method_B");
    }

    protected virtual void Method_C() {
        Console.WriteLine($"{_className} Method_C");
    }

    public virtual void Method_D() {
        Console.WriteLine($"{_className} Method_D");
    }
}