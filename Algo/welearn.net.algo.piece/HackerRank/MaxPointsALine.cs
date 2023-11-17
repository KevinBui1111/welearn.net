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

    public static void main() {
        var dicAngle = new Dictionary<float, int>();
        var y = 1 / 0.0f;
    }
}