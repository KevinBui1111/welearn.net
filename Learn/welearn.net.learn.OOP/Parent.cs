namespace welearn.net.learn.OOP;

public class Parent {
    private readonly string _className;
    protected string ProtectedField = "parent";
    
    public Parent(string className) {
        _className = $"Parent {className}";
        Console.WriteLine($"{_className} is created");
    }

    public void MethodPublic_1() {
        Console.WriteLine($"{_className} {nameof(MethodPublic_1)}");
    }
    
    public void MethodPublic_2() {
        Console.WriteLine($"{_className} {nameof(MethodPublic_2)}");
    }

    protected void MethodProtected_1() {
        Console.WriteLine($"{_className} {nameof(MethodProtected_1)}");
    }

    protected virtual void MethodVirtualProtected() {
        Console.WriteLine($"{_className} Method_C");
    }

    protected void MethodProtected() {
        Console.WriteLine($"{_className} {nameof(MethodProtected)}");
    }
}