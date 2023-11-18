namespace welearn.net.algo.piece.HackerRank;

public static class MaxPointsALine {
    public static int MaxPoints(int[][] points) {
        var pairs = new bool[points.Length * (points.Length - 1) / 2];
        var max = 0;
        for (var i = 0; i < points.Length; ++i) {
            var dicAngle = new Dictionary<float, List<int>>();

            for (var j = i + 1; j < points.Length; ++j) {
                var indexCurrent = GetIndex(i, j, points.Length);
                if (pairs[indexCurrent]) continue; // already count

                var angle = CalcAngle(points[i], points[j]);

                if (dicAngle.TryGetValue(angle, out var list)) {
                    // remove pair from array pairs
                    foreach (var k in list) {
                        var index = GetIndex(k, j, points.Length);
                        pairs[index] = true; // already count
                    }

                    list.Add(j);
                }
                else {
                    list = new List<int> { j };
                    dicAngle[angle] = list;
                }

                if (max < list.Count) max = list.Count;
            }
        }


        return max + 1;

        float CalcAngle(IReadOnlyList<int> point1, IReadOnlyList<int> point2) {
            float disY = point1[1] - point2[1];
            if (disY == 0) return float.PositiveInfinity;
            return (point1[0] - point2[0]) / disY;
        }

        int GetIndex(int n, int m, int len) =>
            len * n - n * (n + 1) / 2 + 1 + m - n - 1 - 1;
    }

    public static int MaxPoints2(int[][] points) {
        var max = 0;
        for (var i = 0; i < points.Length; ++i) {
            var dicAngle = new Dictionary<float, int>();

            for (var j = i + 1; j < points.Length; ++j) {
                var angle = CalcAngle(points[i], points[j]);

                if (dicAngle.TryGetValue(angle, out var c))
                    dicAngle[angle] = c + 1;
                else
                    dicAngle[angle] = 1;

                if (max < dicAngle[angle]) max = dicAngle[angle];
            }
        }

        return max + 1;

        float CalcAngle(IReadOnlyList<int> point1, IReadOnlyList<int> point2) {
            float disY = point1[1] - point2[1];
            if (disY == 0) return float.PositiveInfinity;
            return (point1[0] - point2[0]) / disY;
        }
    }

    // refer from others
    public static int MaxPoints3(int[][] points) {
        if (points.Length == 1) return 1;
        if (points.Length == 2) return 2;

        int max = 0;
        int counter = 2;
        for (int i = 0; i < points.Length; i++) {
            for (int j = i + 2; j < points.Length; j++) {
                for (int k = i + 1; k < j; k++) {
                    if ((points[i][0] - points[k][0]) * (points[k][1] - points[j][1])
                        ==
                        (points[i][1] - points[k][1]) * (points[k][0] - points[j][0])) {
                        counter++;
                    }
                }

                if (counter > max) max = counter;
                counter = 2;
            }
        }

        return max;
    }

    public static int MaxPoints4(int[][] points) {
        int answer = 0;
        for (var i = 0; i < points.Length; i++) {
            var dict = new Dictionary<float, int>();
            for (var j = 0; j < points.Length && j != i; j++) {
                var m = (points[i][0] - points[j][0]) / (float)(points[i][1] - points[j][1]);
                if (float.IsNegativeInfinity(m)) m = float.PositiveInfinity;
                dict.TryAdd(m, 0);
                dict[m]++;
                if (dict[m] > answer) answer = dict[m];
            }
        }

        return answer + 1;
    }

    public static void main() {
        // var rnd = Random.Shared;
        var listPoints = new HashSet<(int, int)>();
        for (int seed = 0; seed < 10; ++seed) {
            Console.WriteLine($"seed: {seed}");

            var rnd = new Random(seed); //6, -80 300; 2; 80; 300; 2, 50, 100
            const int bound = 20;

            listPoints.Clear();
            for (var i = 0; i < 500; ++i) {
                listPoints.Add(
                    (rnd.Next(-bound, bound), rnd.Next(-bound, bound))
                );
            }

            var arrayPoints = listPoints
                .Select(p => new[] { p.Item1, p.Item2 })
                .ToArray();
            Console.Write($"{MaxPoints(arrayPoints)} - ");
            Console.Write($"{MaxPoints2(arrayPoints)} - ");
            Console.Write($"{MaxPoints3(arrayPoints)} - ");
            Console.WriteLine($"{MaxPoints4(arrayPoints)} - ");
            Console.WriteLine();
        }
    }
}