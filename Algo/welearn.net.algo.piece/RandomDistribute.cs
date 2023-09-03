namespace welearn.net.algo.piece;

public static class RandomDistribute {
    private static readonly Random R = new();

    // move from ConsoleCore project, 2022-01-18
    public static void TestRandomDistribute() {
        (int chance, int gain)[] buckets = {
            (5, 0),
            (2, 0),
            (3, 0)
        };
        var chanceRatio = buckets.Select(b => b.chance).ToArray();
        var total = chanceRatio.Sum();

        for (var i = 0; i < 1_00; ++i) {
            var v = R.Next(total);
            var j = Distribute(chanceRatio, v);
            ++buckets[j].gain;
        }

        var sumGain = buckets.Sum(b => b.gain);
        var gainResult = String.Join('-',
            buckets.Select(b =>
                Math.Round(b.gain * 100.0 / sumGain)
            )
        );
        Console.WriteLine($"Gain result: {gainResult}");
    }

    public static int Distribute(IReadOnlyList<int> chanceRatio, int value) {
        var curChance = 0;
        for (var i = 0; i < chanceRatio.Count; ++i) {
            curChance += chanceRatio[i];
            if (value < curChance) {
                return i;
            }
        }

        return -1; // invalid value
    }
}