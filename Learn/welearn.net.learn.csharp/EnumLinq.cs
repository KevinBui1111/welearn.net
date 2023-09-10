using welearn.net.easy;

namespace welearn.net.learn.csharp;

public static class EnumLinq {
    internal static void SelectMany() {
        // migrate from ConsoleCore, 2020-08-31
        string[] a = { "123,456", "678,9090" };
        var result = a.SelectMany(
            (e, index) => e.Split(',')
                .Select(val => (index, val))
        );
        result.PrintConsole();

        var doubleList = Enumerable.Range(1, 3)
            .SelectMany(
                n => new int[] { 5 + 10 * (n - 1), 10 * n }
            );
        doubleList.PrintConsole();
    }
}