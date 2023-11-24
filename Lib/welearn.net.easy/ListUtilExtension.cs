namespace welearn.net.easy;

public static class ListUtilExtension {
    public static T[] Shuffle<T>(this T[] array) {
        ListUtil.Shuffle(array);
        return array;
    }

    public static IList<T> Shuffle<T>(this IList<T> array) {
        ListUtil.Shuffle(array);
        return array;
    }
}