namespace welearn.net.algo.piece;

public static class HundredDoor {
    // Move from ConsoleCore project, build: 2022-01-18 13:13
    // https://www.youtube.com/watch?v=xwWdBj5WfCo
    public static void Travel(int n) {
        bool[] doors = new bool[n];
        for (int i = 1; i <= n; ++i) {
            for (int j = i - 1; j < n; j += i) {
                doors[j] = !doors[j];
            }

            Console.Write($"{i:0##} -- ");
            for (int k = 1; k <= n; ++k) {
                Console.Write(doors[k - 1] ? 1 : 0);
                if ((k & (k - 1)) == 0) Console.Write(' ');
            }

            Console.WriteLine();
        }

        Console.WriteLine($"open: {doors.Count(d => d)}");
    }
}