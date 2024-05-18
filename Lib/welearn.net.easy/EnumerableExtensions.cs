namespace welearn.net.easy;

public static class EnumerableExtensions {
    public static void PrintConsole<T>(this IEnumerable<T> enumerable) {
        Console.WriteLine($"{{{string.Join(", ", enumerable)}}}");
    }

    public static IEnumerable<int> IndexOfWhere<T>(
        this IEnumerable<T> enumerable, Predicate<T> predicate, bool oneBaseIndex = true
    ) {
        var oneIndex = oneBaseIndex ? 1 : 0;
        return enumerable
            .Select((o, idx) => new { o, idx = idx + oneIndex })
            .Where(o => predicate(o.o))
            .Select(o => o.idx);
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) {
        foreach (var item in source) {
            action(item);
            yield return item;
        }
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action) {
        var index = -1;
        foreach (var item in source) {
            checked {
                ++index;
            }

            action(item, index);
            yield return item;
        }
    }
}