namespace welearn.net.easy; 

public static class EnumerableExtensions {
    public static void PrintConsole<T>(this IEnumerable<T> enumerable) {
        Console.WriteLine($"{{{string.Join(", ", enumerable)}}}");
    }
}