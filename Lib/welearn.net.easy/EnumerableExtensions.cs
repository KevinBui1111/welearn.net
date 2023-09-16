namespace welearn.net.easy;

public static class EnumerableExtensions {
    public static void PrintConsole<T>(this IEnumerable<T> enumerable) {
        Console.WriteLine($"{{{string.Join(", ", enumerable)}}}");
    }

    public static IEnumerable<int> IndexOfWhere<T>(this IEnumerable<T> enumerable, Predicate<T> predicate, bool oneBaseIndex = true) {
        var oneIndex = oneBaseIndex ? 1 : 0;
        return enumerable
            .Select((o, idx) => new { o, idx = idx + oneIndex })
            .Where(o => predicate(o.o))
            .Select(o => o.idx);
    }
}