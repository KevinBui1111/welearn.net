using System;

#nullable enable

namespace LangVersion31 {
    class Program {
        private int _a = 0;
        
        static void Main(string[] args) {
            int? i = null;
            var abc = i.ToString();
            
            Console.WriteLine($"abc {abc}");
            Console.WriteLine("Hello World!");
            
            //nullable-reference-types
            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types
            
            Program p;
            // nullable context is disable by default
            p = new Program();
            p._a = 5;
            
            // to enable nullable context, two way:
            // - add `<Nullable>enable</Nullable>` in project setting, default from .NET 6
            // - use `#nullable enable` pragma
            
            Program p2 = null;
            // nullable context is disable by default
            // Dereferencing a variable means to access one of its members using the . (dot) operator
            // p2 = new Program();
            p2._a = 5;

            string a = Foo();
            int len = a.Length;
            
            string? b = default;
            Bar(b);
        }

        static string? Foo() { return default; }
        static void Bar(string input) { }
    }
}