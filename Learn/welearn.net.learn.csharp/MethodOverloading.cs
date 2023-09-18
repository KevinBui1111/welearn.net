namespace welearn.net.learn.csharp;

public class MethodOverloading {
    public void DoFoo(int a = 31, long b = 12, string c = "Hi") {
        Console.WriteLine($"DoFoo 3 param, a: {a}, b: {b}, c: {c}");
    }

    /// Foo with 2 params only
    public void DoFoo(int a, long b) {
        Console.WriteLine($"DoFoo 2 param, a: {a}, b: {b}");
    }

    public void DoFoo(int a) {
        Console.WriteLine($"DoFoo 1 param, a: {a},");
    }

    public void DoBar(int a = 10, long b = 10, string c = "Hi") {
        Console.WriteLine($"DoBar, a: {a}, b: {b}, c: {c}");
    }

    public static void Test() {
        var mo = new MethodOverloading();
        mo.DoFoo(1);
        mo.DoFoo(a: 2);
        mo.DoFoo(b: 2, a: 1);
        mo.DoFoo();
        mo.DoFoo(b: 2);
        mo.DoFoo(c: "Hello", b: 2, a: 1);
        mo.DoBar(c: "Hello");
        mo.DoBar(b: 5);
        mo.DoBar();
    }
}