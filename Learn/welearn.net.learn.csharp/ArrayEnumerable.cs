using System.Diagnostics;

namespace welearn.net.learn.csharp;

public class ArrayEnumerable {
    public static void DeclarationArray() {
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays
        var unused3 = new string[3] { "1b", "2e", "a" };
        var unused = new[] { 1, 2, 3 };
        int[] unused1 = { 1, 2, 3 };

        var x = DateTime.Now.Millisecond;
        int[] unused2 = { unused[2], unused1[1], x };

        var jaggedArrays = new[] {
            new[] { 7, 4, 1 },
            new[] { 8, 5, 2 }
        };
        
        int[][] jaggedArrays2 = {
            new[] { 7, 4, 1 },
            new[] { 8, 5, 2 }
        };
        
        int[][] jaggedArray = new int[6][];
        Debug.Assert(jaggedArray[1] == null);
        jaggedArray[0] = new[] { 1, 2, 3, 4 };
        
        // empty array
        var unused4 = new int[] { };
        string[] unused5 = { };
        string[] unusedB = { };
        Debug.Assert(!object.ReferenceEquals(unused5, unusedB));
        DateTime[] unused6 = new DateTime[0];
        DateTime[] unused9 = new DateTime[0];
        Debug.Assert(!object.ReferenceEquals(unused6, unused9));
        
        Guid[] unused7 = Array.Empty<Guid>();
        Guid[] unused8 = Array.Empty<Guid>();
        Debug.Assert(object.ReferenceEquals(unused7, unused8));
        
        //instantiate a C# array with a single value
        Enumerable.Repeat(9, 1000).ToArray();
    }
}