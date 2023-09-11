namespace welearn.net.learn.OOP;

public static class ParentChildTester {
    public static void Test() {
        Console.WriteLine("1 --- Call from child ---");
        var c = new Child("child");
        c.MethodPublic_1();
        c.MethodPublic_2();
        
        Console.WriteLine("2 ---Call as Parent---");
        var p = (Parent)c;
        p.MethodPublic_1();
        p.MethodPublic_2();

        Console.WriteLine("3 ---Protected---");
        c.MethodProtected_1();
        c.Call_Parent_Protected();
        
        Console.WriteLine("4 ---Virtual---");
        c.Call_MethodVirtualProtected();
    }
}