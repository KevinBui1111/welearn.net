namespace welearn.net.learn.OOP;

public class Child : Parent {
    private readonly string _className;
    private Parent _parentInstance;
    private readonly Parent _meParent;
    
    public Child(string className) : base(className) {
        _className = className;
        Console.WriteLine($"{_className} is created");
        _parentInstance = new Parent("parentInstance");
        _meParent = this;
    }

    public void MethodPublic_1() {
        Console.WriteLine($"{_className} {nameof(MethodPublic_1)}");
    }
    
    public new void MethodPublic_2() {
        // same as MethodPublic_1
        Console.WriteLine($"{_className} {nameof(MethodPublic_2)}");
    }

    public new void MethodProtected_1() {
        Console.WriteLine($"{_className} {nameof(MethodProtected_1)}");
    }

    public void Call_Parent_Protected() {
        base.MethodProtected_1();
    }

    protected override void MethodVirtualProtected() {
        Console.WriteLine($"{_className} {nameof(MethodVirtualProtected)}");
        base.MethodVirtualProtected();
    }

    public void Call_MethodVirtualProtected() {
        MethodVirtualProtected();
    }

    public void CanAccessParent() {
        /* error: can't access
         _meParent.MethodProtected();
         _meParent.MethodProtected_1();
         _meParent.MethodVirtualProtected():
         _meParent.ProtectedField;
         same with _parentInstance
         */
        var prod2 = this.ProtectedField;
        
        var aChild = new Child("aChild");
        aChild.MethodVirtualProtected();
        aChild.MethodProtected();
        var pro1 = aChild.ProtectedField;
        this.MethodProtected();

        var me = this;
    }
}

public class ChildChild : Child {
    public ChildChild(string className) : base(className) { }

    protected override void MethodVirtualProtected() {
        
    }
}