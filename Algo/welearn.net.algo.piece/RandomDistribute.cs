namespace welearn.net.algo.piece;

public class RandomDistribute {
    // move from ConsoleCore project, 2022-01-18
    public static void RandomPercent() {
        (int chance, int gain)[] buckets = {
            (5, 0),
            (2, 0),
            (3, 0)
        };
        int total = buckets.Sum(b => b.chance);

        do {
            Random r = new Random();
            for (int i = 0; i < 1_00; ++i) {
                //int v = i % total + 1;
                int v = r.Next(total);
                int curChance = 0;
                for (int j = 0; j < buckets.Length; ++j) {
                    curChance += buckets[j].chance;
                    if (v < curChance) {
                        ++buckets[j].gain;
                        break;
                    }
                }
                //if (v <= bucketA.chance) ++bucketA.gain;
                //else ++bucketB.gain;
            }

            int sumGain = buckets.Sum(b => b.gain);
            for (int j = 0; j < buckets.Length; ++j) {
                Console.Write($"bucket {j}: {Math.Round(buckets[j].gain * 100.0 / sumGain)}, ");
            }

            Console.ReadLine();
        } while (true);
    }
}