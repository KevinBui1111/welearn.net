namespace welearn.net.learn.OOP;

public class MyClass {
    public static void Test() {
        Console.WriteLine("1 ------------");
        var c = new Child();
        c.Method_A();
        c.Method_A1();
        
        Console.WriteLine("2 ------------");
        var p = (Parent)c;
        p.Method_A();
        p.Method_A1();

        Console.WriteLine("3 ------------");
        c.Method_B();
        c.Method_B_Parent();
        
        Console.WriteLine("4 ------------");
        c.Call_Method_C();
        
        Console.WriteLine("5 ------------");
        c.Method_D();
        
        Console.WriteLine("6 ------------");
        c.Method_D_Parent();
    }
}