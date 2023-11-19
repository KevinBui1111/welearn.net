namespace welearn.net.learn.csharp;

public static class YieldStatement {
    public static void Test() {
        var first5 = FirstFivePositiveNumber();
        Console.WriteLine("caller: FirstFivePositiveNumber");
        foreach (var i in first5) {
            Console.Write($"{i} ");
        }

        Console.WriteLine("caller 2: FirstFivePositiveNumber");
        foreach (var i in first5) {
            Console.Write($"{i} ");
        }

        Console.WriteLine();

        Console.WriteLine("ProduceEvenNumbers");
        foreach (var i in ProduceEvenNumbers(9)) {
            Console.Write($"{i} ");
        }

        Console.WriteLine();

        Console.WriteLine("TakeWhilePositive");
        Console.WriteLine(string.Join(" ", TakeWhilePositive(new[] { 2, 3, 4, 5, -1, 3, 4 })));
        // Output: 2 3 4 5

        var Seq = Enumerable.Range(1, 10);

        Console.WriteLine(
            string.Join(", ", Seq.TakeAllButLast())
        );
        Console.WriteLine(
            string.Join(", ", Seq.SkipLastN(3))
        );
    }

    private static IEnumerable<int> FirstFivePositiveNumber() {
        Console.WriteLine($"start FirstFivePositiveNumber");
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield return 5;
        Console.WriteLine($"end FirstFivePositiveNumber");
        yield break; // dont need
        Console.WriteLine($"end2 FirstFivePositiveNumber");
        yield return 6;
    }

    private static IEnumerable<int> ProduceEvenNumbers(int upto) {
        for (var i = 0; i <= upto; i += 2) {
            yield return i;
        }

        yield return upto * 10;
    }

    private static IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers) {
        foreach (var n in numbers) {
            if (n > 0)
                yield return n;
            else
                yield break;
        }
    }

    //https://stackoverflow.com/a/1779135/836376
    private static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> source) {
        var it = source.GetEnumerator();
        bool hasRemainingItems = false;
        bool isFirst = true;
        T item = default(T);

        do {
            hasRemainingItems = it.MoveNext();
            if (hasRemainingItems) {
                if (!isFirst) yield return item;
                item = it.Current;
                isFirst = false;
            }
        } while (hasRemainingItems);
    }
    //https://stackoverflow.com/a/1779135/836376
    private static IEnumerable<T> SkipLastN<T>(this IEnumerable<T> source, int n) {
        var it = source.GetEnumerator();
        bool hasRemainingItems = false;
        var cache = new Queue<T>(n + 1);

        do {
            if (hasRemainingItems = it.MoveNext()) {
                cache.Enqueue(it.Current);
                if (cache.Count > n)
                    yield return cache.Dequeue();
            }
        } while (hasRemainingItems);
    }
}