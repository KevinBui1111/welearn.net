namespace welearn.net.algo.piece;

// simple and beautiful solution from a Dung (Head)
internal class ResourceLoading {
    public static void Main() {
        void Problem2(List<Segment> segments)
        {
            List<PPoint> pPoints = new List<PPoint>();

            foreach (var sg in segments)
            {
                pPoints.Add(new PPoint(sg.start));
                pPoints.Add(new PPoint(sg.end));
            }

            var sortedPPoints = pPoints.OrderBy(pp => pp.x).ToList();
            var sortedSegments = segments.OrderBy(sg => sg.start).ToList();

            foreach (var p in sortedPPoints) {
                int i = 0;
                while (i < sortedSegments.Count && p.x >= sortedSegments[i].start ) {
                    if (sortedSegments[i].hasStart(p.x)) p.S++;
                    if (sortedSegments[i].hasMiddle(p.x)) p.M++;
                    i++;
                }
            }

            for (int i=0;i<sortedPPoints.Count-1;i++) {
                if (sortedPPoints[i].x == sortedPPoints[i + 1].x) continue;
                Console.WriteLine("{0} -> {1}: {2}", sortedPPoints[i].x, sortedPPoints[i+1].x, sortedPPoints[i].getWeight());
            }
        }

        void Problem(List<Segment> segments) {
            var points = segments.SelectMany(s => new PPoint[] {
                    new(s.start), new(s.end)
                })
                .OrderBy(p => p.x)
                .ToArray();

            for (var i = 0; i < points.Length - 1; ++i) {
                if (points[i].x == points[i + 1].x) continue;
                var weight = segments.Count(s => s.HasPass(points[i].x));
                Console.WriteLine($"{points[i].x} -> {points[i + 1].x}: {weight}");
            }
        }

        Problem(new List<Segment> {
            new Segment(1.0, 3.0),
            new Segment(2.0, 3.0),
            new Segment(4.0, 7.0),
        });

        Console.WriteLine();

        Problem(new List<Segment> {
            new Segment(1.0, 3.0),
            new Segment(4.0, 5.0),
            new Segment(4.0, 6.0),
            new Segment(4.0, 7.0),
        });

        Console.WriteLine();

        Problem(new List<Segment> {
            new Segment(1.0, 3.0),
            new Segment(2.0, 3.5),
            new Segment(4.0, 7.0),
        });

        Console.WriteLine();

        Problem(new List<Segment> {
            new Segment(1.0, 3.0),
            new Segment(4.0, 7.0),
            new Segment(5.0, 9.5),
            new Segment(8.0, 11.0),
        });
    }
}

class PPoint
{
    public double x;
    public int S;
    public int M;

    public PPoint(double xx)
    {
        x = xx;
        S = M = 0;
    }

    public int getWeight()
    {
        return S + M;
    }
    public override string ToString()
    {
        return $"({x}, {S}, {M})";
    }
} 

class Segment
{
    public double start; 
    public double end;
    public Segment(double s, double e)
    {
        start = s;
        end = e;
    }

    public Boolean hasStart(double x)
    {
        return x == start;
    }
    public Boolean hasEnd(double x)
    {
        return x == end;
    }

    public Boolean hasMiddle(double x)
    {
        return (x > start) && (x < end);
    }

    public bool HasPass(double x) => start <= x & x < end;
}