namespace welearn.net.algo.piece.HackerRank;

public class SelfCrossing {
    // naive
    public bool IsSelfCrossing(int[] distance) {
        const int up = 0;
        const int left = 1;
        const int down = 2;
        const int right = 3;

        int curX = 0, curY = 0;
        /*
         * horizontal segment: xf - xt, y
         * vertical segment:   x, yf - yt
         */
        List<int[]> hSegments = new(), vSegments = new();

        for (var i = 0; i < distance.Length; i++) {
            var d = distance[i];
            var direction = i % 4;

            // if up / down, check with all horizon line segments
            // create vSegment: curX, curY, curY + d
            var seg = Array.Empty<int>();
            switch (direction) {
                case up:
                    seg = new[] { curX, curY, curY += d };
                    break;
                case down:
                    seg = new[] { curX, curY - d, curY };
                    curY -= d;
                    break;
                case left:
                    seg = new[] { curX - d, curX, curY };
                    curX -= d;
                    break;
                case right:
                    seg = new[] { curX, curX += d, curY };
                    break;
            }

            switch (direction) {
                // if up / down, check with all vertical line segments 
                case up or down: {
                    for (var j = 0; j < hSegments.Count - 1; j++) {
                        if (TwoSegmentCross(hSegments[j], seg)) return true;
                    }

                    vSegments.Add(seg);
                    break;
                }
                // if left / right, check with all vertical line segments 
                case left or right: {
                    for (var j = 0; j < vSegments.Count - 1; j++) {
                        if (TwoSegmentCross(seg, vSegments[j])) return true;
                    }

                    hSegments.Add(seg);
                    break;
                }
            }
        }

        return false;
    }

    private static bool TwoSegmentCross(IReadOnlyList<int> hSeg, IReadOnlyList<int> vSeg) =>
        hSeg[0] <= vSeg[0] && vSeg[0] <= hSeg[1] &&
        vSeg[1] <= hSeg[2] && hSeg[2] <= vSeg[2];

    public static void Test() {
        int x = 5;
        int[] a = { x += 2, x };
        Console.WriteLine($"x = {x}, a = {a}");
    }
}