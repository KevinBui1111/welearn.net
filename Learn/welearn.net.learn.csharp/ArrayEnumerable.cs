using System.Diagnostics;
using welearn.net.easy;
using welearn.net.learn.csharp.Entities;

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
        Array.Fill(unused, 9);
    }

    public static void Sorting() {
        #region sort Array

        var enumInts = Enumerable.Range(1, 10);
        // create random array.
        var arrayInts = enumInts.ToArray();
        
        Console.WriteLine("==== A random array:");
        ListUtil.Shuffle(arrayInts);
        arrayInts.PrintConsole();
        
        // sort array.
        Console.WriteLine("- Sort array:");
        Array.Sort(arrayInts);
        arrayInts.PrintConsole();

        Console.WriteLine("\n==== Sort array and get indexes:");
        var indexes = Enumerable.Range(0, arrayInts.Length).ToArray();
        Console.WriteLine("- A random array:");
        ListUtil.Shuffle(arrayInts);
        arrayInts.PrintConsole();
        
        Console.WriteLine("- Sort array:");
        Array.Sort(arrayInts, indexes);
        arrayInts.PrintConsole();
        Console.WriteLine("- indexes after sorting:");
        indexes.PrintConsole();
        
        // sort descending order
        Array.Sort(arrayInts, (a, b) => b.CompareTo(a));
        
        Console.WriteLine("\n==== Sort array of objects:");
        // array of object
        Student[] students = {
            new(10, "Eni" ),
            new(5, "Khanh" ),
            new(15, "Steve" ),
        };
        
        Array.Sort(students, (student1, student2) => student1.Age - student2.Age);
        students.PrintConsole();
        
        #endregion

        #region Sort List
        
        Console.WriteLine("\n==== Sort List of objects:");
        var listStudent = (List<Student>)students.ToList().Shuffle();
        listStudent.Sort((s1, s2) => string.CompareOrdinal(s1.Name, s2.Name));
        listStudent.PrintConsole();
        
        #endregion s
    }

    public static void BinarySearch() {
        var enumInt = Enumerable.Range(0, 10)
            .Select(_ => Random.Shared.Next(70));

        var arrayInt = enumInt.ToList();
        arrayInt.Sort();
        arrayInt.PrintConsole();

        var findElement = Random.Shared.Next(100);
        Find(arrayInt, findElement);

        var reverseComparer = new ReverseComparer();
        arrayInt.Sort(reverseComparer);
        arrayInt.PrintConsole();
        Find(arrayInt, findElement, reverseComparer);
        
        return;

        void Find(List<int> arr, int i, IComparer<int>? comparer = default) {
            var index = arr.BinarySearch(i, comparer);

            var resultStr = index switch {
                >= 0  => $"Found element {i} at index {index}",
                _ when ~index == arr.Count => $"Element {i} is greater than maximum value",
                _ => $"Closest element to {i}: value {arr[~index]} (at index {~index})"
            };

            Console.WriteLine(resultStr);
        }
    }

    private class ReverseComparer : IComparer<int> {
        public int Compare(int x, int y) => y - x;
    }
}