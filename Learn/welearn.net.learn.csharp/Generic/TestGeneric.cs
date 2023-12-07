using System.Diagnostics;

namespace welearn.net.learn.csharp.Generic; 

public class TestGeneric {
    public static void Test() {
        var val = GenericClass.Foo(nullValue: true, defaultValue: 19);
        Debug.Assert(val == 19);
    }
}