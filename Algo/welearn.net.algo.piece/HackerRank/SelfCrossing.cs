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

    public bool IsSelfCrossing2(int[] distance) {
        var curPoint = new Point();
        /*
         * horizontal segment: xf - xt, y
         * vertical segment:   x, yf - yt
         */
        // save last 3 segments
        var hSegments = new int[3][];
        hSegments[0] = new[] { 0, 0, 0 };
        var vSegments = new int[3][];

        IOrientedService[] orientedServices = {
            new UpService(vSegments, hSegments),
            new LeftService(vSegments, hSegments),
            new DownService(vSegments, hSegments),
            new RightService(vSegments, hSegments)
        };

        var shrunken = false;

        for (var i = 0; i < distance.Length; i++) {
            var d = distance[i];
            var direction = i % 4;
            var orientedSrv = orientedServices[direction];
            int[]? checkSegment;

            var newSeg = orientedSrv.CreateSegment(curPoint, d);

            if (i < 3) {
                curPoint = orientedSrv.UpdateLocation(curPoint, d);
                orientedSrv.AddSegment(newSeg);
                continue;
            }

            // check shrunken
            if (!shrunken) {
                // test with 2nd last segment.
                shrunken = orientedSrv.IsShrunken(curPoint);

                if (!shrunken) {
                    curPoint = orientedSrv.UpdateLocation(curPoint, d);
                    orientedSrv.AddSegment(newSeg);
                    continue;
                }

                checkSegment = i == 3
                    ? orientedSrv.GetSegment(1)
                    : orientedSrv.GetSegment(2);
            }
            else {
                checkSegment = orientedSrv.GetSegment(1);
            }

            curPoint = orientedSrv.UpdateLocation(curPoint, d);
            if (orientedSrv.IsSegmentsCross(newSeg, checkSegment)) return true;
            orientedSrv.AddSegment(newSeg);
        }

        return false;
    }

    private static bool TwoSegmentCross(IReadOnlyList<int> hSeg, IReadOnlyList<int> vSeg) =>
        hSeg[0] <= vSeg[0] && vSeg[0] <= hSeg[1] &&
        vSeg[1] <= hSeg[2] && hSeg[2] <= vSeg[2];

    private struct Point {
        public int X;
        public int Y;
    }

    private interface IOrientedService {
        bool IsShrunken(Point p);
        int[] CreateSegment(Point p, int d);
        Point UpdateLocation(Point p, int d);
        bool IsSegmentsCross(IReadOnlyList<int> seg, IReadOnlyList<int> checkSegment);
        int[] GetSegment(int index);
        public void AddSegment(int[] segment);
    }

    private abstract class BaseOrientedService : IOrientedService {
        protected readonly int[][] VSegments;
        protected readonly int[][] HSegments;

        protected BaseOrientedService(int[][] vSegments, int[][] hSegments) {
            VSegments = vSegments;
            HSegments = hSegments;
        }

        public abstract bool IsShrunken(Point p);
        public abstract int[] CreateSegment(Point p, int d);
        public abstract Point UpdateLocation(Point p, int d);
        public abstract bool IsSegmentsCross(IReadOnlyList<int> hSeg, IReadOnlyList<int> vSeg);
        public abstract int[] GetSegment(int index);
        public abstract void AddSegment(int[] segment);

        protected void BaseAddSegment(IList<int[]> segments, int[] segment) {
            segments[2] = segments[1];
            segments[1] = segments[0];
            segments[0] = segment;
        }
    }

    private class UpService : BaseOrientedService {
        public UpService(int[][] vSegments, int[][] hSegments) : base(vSegments, hSegments) { }

        public override bool IsShrunken(Point p) => p.X <= VSegments[1][0];

        public override int[] CreateSegment(Point p, int d) => new[] { p.X, p.Y, p.Y + d };

        public override Point UpdateLocation(Point p, int d) {
            p.Y += d;
            return p;
        }

        public override bool IsSegmentsCross(IReadOnlyList<int> seg, IReadOnlyList<int> checkSegment) =>
            checkSegment[0] <= seg[0] && seg[0] <= checkSegment[1] &&
            seg[1] <= checkSegment[2] && checkSegment[2] <= seg[2];

        public override int[] GetSegment(int index) => HSegments[index];

        public override void AddSegment(int[] segment) {
            BaseAddSegment(VSegments, segment);
        }
    }

    private class DownService : BaseOrientedService {
        public DownService(int[][] vSegments, int[][] hSegments) : base(vSegments, hSegments) { }

        public override bool IsShrunken(Point p) => p.X >= VSegments[1][0];

        public override int[] CreateSegment(Point p, int d) => new[] { p.X, p.Y - d, p.Y };

        public override Point UpdateLocation(Point p, int d) {
            p.Y -= d;
            return p;
        }

        public override bool IsSegmentsCross(IReadOnlyList<int> seg, IReadOnlyList<int> checkSegment) =>
            checkSegment[0] <= seg[0] && seg[0] <= checkSegment[1] &&
            seg[1] <= checkSegment[2] && checkSegment[2] <= seg[2];

        public override int[] GetSegment(int index) => HSegments[index];

        public override void AddSegment(int[] segment) {
            BaseAddSegment(VSegments, segment);
        }
    }

    private class LeftService : BaseOrientedService {
        public LeftService(int[][] vSegments, int[][] hSegments) : base(vSegments, hSegments) { }

        public override bool IsShrunken(Point p) => p.Y <= HSegments[1][2];

        public override int[] CreateSegment(Point p, int d) => new[] { p.X - d, p.X, p.Y };

        public override Point UpdateLocation(Point p, int d) {
            p.X -= d;
            return p;
        }

        public override bool IsSegmentsCross(IReadOnlyList<int> seg, IReadOnlyList<int> checkSegment) =>
            seg[0] <= checkSegment[0] && checkSegment[0] <= seg[1] &&
            checkSegment[1] <= seg[2] && seg[2] <= checkSegment[2];

        public override int[] GetSegment(int index) => VSegments[index];

        public override void AddSegment(int[] segment) {
            BaseAddSegment(HSegments, segment);
        }
    }

    private class RightService : BaseOrientedService {
        public RightService(int[][] vSegments, int[][] hSegments) : base(vSegments, hSegments) { }

        public override bool IsShrunken(Point p) => p.Y >= HSegments[1][2];

        public override int[] CreateSegment(Point p, int d) => new[] { p.X, p.X + d, p.Y };

        public override Point UpdateLocation(Point p, int d) {
            p.X += d;
            return p;
        }

        public override bool IsSegmentsCross(IReadOnlyList<int> seg, IReadOnlyList<int> checkSegment) =>
            seg[0] <= checkSegment[0] && checkSegment[0] <= seg[1] &&
            checkSegment[1] <= seg[2] && seg[2] <= checkSegment[2];

        public override int[] GetSegment(int index) => VSegments[index];

        public override void AddSegment(int[] segment) {
            BaseAddSegment(HSegments, segment);
        }
    }

    public bool IsSelfCrossingOther(int[] distance) {
        bool inside = false;
        bool danger = false;

        if (distance.Length < 4) {
            return false;
        }

        int x = 0;
        int y = 0;
        y += distance[0];
        x -= distance[1];

        for (int i = 2; i < distance.Length; i++) {
            if (i % 4 == 0) {
                y += distance[i];
            }
            else {
                if (i % 4 == 1) {
                    x -= distance[i];
                }
                else {
                    if (i % 4 == 2) {
                        y -= distance[i];
                    }
                    else {
                        x += distance[i];
                    }
                }
            }

            if (x == 0 && y == 0) {
                return true;
            }

            if (inside && distance[i] >= distance[i - 2]) {
                return true;
            }

            if (danger) {
                if (distance[i] >= distance[i - 2] - distance[i - 4]) {
                    return true;
                }

                danger = false;
            }

            if (!inside && distance[i] <= distance[i - 2]) {
                inside = true;

                if (i >= 4) {
                    if (distance[i] >= distance[i - 2] - distance[i - 4]) {
                        danger = true;
                    }
                }
            }
        }

        return false;
    }

    // improve, after refer solution in LeetCode,
    public bool IsSelfCrossing4(int[] distance) {
        if (distance.Length <= 3) return false;

        var i = 2;
        while (distance[i - 2] < distance[i])
            if (++i == distance.Length)
                return false;

        if (i == distance.Length - 1) return false;

        // shrink
        int checkDis;
        if (i == 2
            || (i == 3 && distance[i] < distance[i - 2])
            || (i > 3 && distance[i - 2] - distance[i - 4] > distance[i])
           )
            checkDis = distance[i - 1];
        else
            checkDis = distance[i - 1] - distance[i - 3];

        ++i;
        while (distance[i] < checkDis) {
            checkDis = distance[i - 1];
            if (++i == distance.Length) return false;
        }

        return true;
    }

    // improve, after refer solution in LeetCode,
    public bool IsSelfCrossing5(IEnumerable<int> d) {
        int d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0;

        foreach (var d0 in d) {
            if (d0 >= d2 && d1 <= d3 && d1 > 0) return true;

            if (d5 > 0 &&
                d1 >= d3 - d5 &&
                d1 <= d3 &&
                d0 >= d2 - d4
               )
                return true;

            if (d4 > 0 &&
                d1 == d3 &&
                d0 >= d2 - d4
               )
                return true;

            (d1, d2, d3, d4, d5) = (d0, d1, d2, d3, d4);
        }

        return false;
    }

    // improve, after refer python solution in LeetCode,
    public bool IsSelfCrossingPython(IEnumerable<int> distance) {
        int d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0;

        foreach (var d0 in distance) {
            if (0 < d1 && d1 <= d3 &&
                (
                    d0 >= d2 ||
                    d0 >= d2 - d4 && d1 >= d3 - d5
                )
               )
                return true;

            (d1, d2, d3, d4, d5) = (d0, d1, d2, d3, d4);
        }

        return false;
    }

    public bool IsSelfCrossingOther2(int[] ds) {
        for (var i = 3; i < ds.Length; ++i)
        {
            if (ds[i] >= ds[i - 2] && ds[i - 1] <= ds[i - 3]) return true;
            if (i >= 4 
                && ds[i] >= ds[i - 2] - ds[i - 4]
                && ds[i - 1] == ds[i - 3])
                return true;
            
            if (i >= 5 
                && ds[i] >= ds[i - 2] - ds[i - 4]
                && ds[i - 1] >= ds[i - 3] - ds[i - 5]
                && ds[i - 3] >= ds[i - 1])
                return true;
        }
        return false;
    }

    public static void Test() {
        int x = 5;
        int[] a = { x += 2, x };
        Console.WriteLine($"x = {x}, a = {a}");
    }
}