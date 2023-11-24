namespace welearn.net.easy;

public static class ListUtil {
    private static readonly Random Rng = Random.Shared;

    public static List<(long from, long to)> Distribute(long from, long to, int groupCount) {
        long size = to - from,
            groupSize = size / groupCount,
            remain = size % groupCount,
            sizeAllRemain = from + remain * (groupSize + 1);

        var listGroup = new List<(long from, long to)>();
        while (from < sizeAllRemain) {
            listGroup.Add((from, from += groupSize + 1));
        }

        while (from < to) {
            listGroup.Add((from, from += groupSize));
        }

        return listGroup;
    }

    public static void Shuffle<T>(T[] array) {
        var n = array.Length;
        while (n > 1) {
            var k = Rng.Next(n--);
            (array[n], array[k]) = (array[k], array[n]);
        }
    }

    public static void Shuffle<T>(IList<T> array) {
        var n = array.Count;
        while (n > 1) {
            var k = Rng.Next(n--);
            (array[n], array[k]) = (array[k], array[n]);
        }
    }
}