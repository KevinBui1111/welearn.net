namespace welearn.net.algo.piece.HackerRank;

public class SelfCrossing2 {
    public bool IsSelfCrossing2(int[] distance) {
        var curPoint = new Point(0, 0);
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
                orientedSrv.UpdateLocation(curPoint, d);
                orientedSrv.AddSegment(newSeg);
                continue;
            }

            // check shrunken
            if (!shrunken) {
                // test with 2nd last segment.
                shrunken = orientedSrv.IsShrunken(curPoint);
                
                if (!shrunken) {
                    orientedSrv.UpdateLocation(curPoint, d);
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

            orientedSrv.UpdateLocation(curPoint, d);
            if (orientedSrv.IsSegmentsCross(newSeg, checkSegment)) return true;
            orientedSrv.AddSegment(newSeg);
        }

        return false;
    }

    private class Point {
        public Point(int x, int y) {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    private interface IOrientedService {
        bool IsShrunken(Point p);
        int[] CreateSegment(Point p, int d);
        void UpdateLocation(Point p, int d);
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
        public abstract void UpdateLocation(Point p, int d);
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

        public override void UpdateLocation(Point p, int d) => p.Y += d;

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

        public override void UpdateLocation(Point p, int d) => p.Y -= d;

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

        public override void UpdateLocation(Point p, int d) => p.X -= d;

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

        public override void UpdateLocation(Point p, int d) => p.X += d;

        public override bool IsSegmentsCross(IReadOnlyList<int> seg, IReadOnlyList<int> checkSegment) =>
            seg[0] <= checkSegment[0] && checkSegment[0] <= seg[1] &&
            checkSegment[1] <= seg[2] && seg[2] <= checkSegment[2];

        public override int[] GetSegment(int index) => VSegments[index];

        public override void AddSegment(int[] segment) {
            BaseAddSegment(HSegments, segment);
        }
    }
}