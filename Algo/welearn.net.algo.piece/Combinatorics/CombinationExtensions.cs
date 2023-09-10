namespace welearn.net.algo.piece.Combinatorics;

public static class CombinationExtensions {
    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k) {
        // Move from ConsoleCore project, 2020-10-29, magic treasure game
        return k == 0
            ? new[] { Array.Empty<T>() }
            : elements.SelectMany((e, i) =>
                elements
                    .Skip(i + 1)
                    .Combinations(k - 1)
                    .Select(c => new[] { e }.Concat(c)));
    }
}