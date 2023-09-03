namespace welearn.net.learn.OOP;

public class Child : Parent {
    private readonly string _className;
    private Parent p;
    private Parent meParent;
    
    public Child() {
        _className = "Child";
        Console.WriteLine($"{_className} is created");
        p = new Parent();
        meParent = this;
    }

    public void Method_A() {
        Console.WriteLine($"{_className} Method_A");
    }
    
    public new void Method_A1() {
        Console.WriteLine($"{_className} Method_A1");
    }

    public new void Method_B() {
        Console.WriteLine($"{_className} Method_B");
    }

    public void Method_B_Parent() {
        // meParent.Method_B(); // error: can't access
        // p.Method_B(); // error: can't access
        base.Method_B();
    }

    protected override void Method_C() {
        Console.WriteLine($"{_className} Method_C");
        base.Method_C();
    }

    public void Call_Method_C() {
        Method_C();
        // meParent.Method_C(); // error: can't access
    }

    public override void Method_D() {
        Console.WriteLine($"{_className} Method_D");
        base.Method_D();
        // meParent.Method_D(); // error: can't access
    }

    public void Method_D_Parent() {
        meParent.Method_D();
    }
}
