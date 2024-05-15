namespace welearn.net.algo.piece;

// from a Dũng (Head), sharing post afternoon interview, 2024-05-14
public class LineOverload {
    public static int[][] AnalyseOverload(int[][] lines) {
        /* [
              (x1, thick1),
              (x2, thick2),
              (x3, thick3),
              (x4, 0) // end
            ]
          */
        int[][] result = Array.Empty<int[]>();
        var firstLine = lines[0];
        var seg = new Segment(firstLine[0], 1, firstLine[1]);
        foreach (int[] line in lines) {
            // result = AppendLine(line, result);
        }
        return null;
    }

    public static Segment[] AppendLine(int[] appendLine, Segment[] thickLine) {
        if (thickLine.Length == 0)
            // return single line with thick 1
            return new[] {
                new Segment { From = appendLine[0], Thick = appendLine[1] }
            };

        var result = new List<Segment>();
        int[] prevSeg = { 0, 0 };
        int i = 0;
        // first part
        while (i < thickLine.Length &&
               thickLine[i].From < appendLine[0]
               ) {
            result.Add(thickLine[i]);
            ++i;
        }

        if (i < thickLine.Length && appendLine[0] < thickLine[i].From)
            result.Add(
                new Segment {
                    From = appendLine[0],
                    Thick = i == 0 ? 1 : thickLine[i - 1].Thick
                });
        
        // second part
        while (i < thickLine.Length &&
              thickLine[i].From < appendLine[1]
             ) {
            result.Add(new Segment { From = thickLine[i].From, Thick = thickLine[i].Thick + 1 });
            ++i;
        }

        if (i < thickLine.Length && appendLine[1] < thickLine[i].From)
            result.Add(new Segment { From = appendLine[1], Thick = thickLine[i - 1].Thick });
        
        // third part
        while (i < thickLine.Length) {
            result.Add(thickLine[i]);
            ++i;
        }

        if (thickLine[i - 1].From < appendLine[1])
            result.Add(new Segment { From = appendLine[1], Thick = 0 });

        return result.ToArray();
    }

    public static Segment[] AppendLine2(string appendSeg, Segment[] thickLine) {
        var appendSegment = new Segment(appendSeg);
        // add infinitive head segment.
        if (thickLine[0].From > int.MinValue) {
            var listSegment = new List<Segment> { new Segment(int.MinValue, 0) };
            listSegment.AddRange(thickLine);
            thickLine = listSegment.ToArray();
        }

        var result = new List<Segment>();

        foreach (var seg in thickLine) {
            var newSegs = MergeTwoSegment(seg, appendSegment);
            result.AddRange(newSegs);
        }

        return result.ToArray();
    }

    public static Segment[] MergeTwoSegment(Segment segMain, Segment seg2) {
        // case: seg2 outside seg 1
        if (seg2.To <= segMain.From || segMain.To <= seg2.From) return new[] { segMain };

        if (seg2.From <= segMain.From) {
            if (seg2.To < segMain.To) {
                return Segment.ConstructSegmentThick(
                    $"{segMain.From} {segMain.Thick + seg2.Thick} {seg2.To} {segMain.Thick} {segMain.To}"
                );
            }
            // end1 <= end2: segment1 inside segment2
            return Segment.ConstructSegmentThick(
                $"{segMain.From} {segMain.Thick + seg2.Thick} {segMain.To}"
            );
        }
        
        // seg1.X < seg2.X < end 1
        if (seg2.To < segMain.To) { // seg2 inside seg1
            return Segment.ConstructSegmentThick(
                $"{segMain.From} {segMain.Thick} {seg2.From} {segMain.Thick + seg2.Thick} {seg2.To} {segMain.Thick} {segMain.To}"
            );
        }
        
        return Segment.ConstructSegmentThick(
            $"{segMain.From} {segMain.Thick} {seg2.From} {segMain.Thick + seg2.Thick} {segMain.To}"
        );
    }
    
    public class Segment {
        public Segment() {}

        public Segment(string seg) {
            var p = seg.Split(' ');
            From = int.Parse(p[0]);
            Thick = int.Parse(p[1]);
            To = int.Parse(p[2]);
        }
        
        public Segment(int from, int thick) {
            From = from;
            Thick = thick;
        }
        
        public Segment(int from, int thick, int to) {
            From = from;
            Thick = thick;
            To = to;
        }
        
        public int From { get; set; }
        public int To { get; set; }
        public int Thick { get; set; }

        protected bool Equals(Segment other) {
            return From == other.From && To == other.To && Thick == other.Thick;
        }

        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Segment)obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(From, To, Thick);
        }

        public override string ToString() => $"({From} {Thick} {To})";
        
        public static Segment[] ConstructSegmentThick(string segThickString) {
            var parts = segThickString.Split(' ')
                .Select(int.Parse).ToList();

            if (parts.Count % 2 == 0)
                throw new InvalidDataException();

            var segCnt = parts.Count / 2;
            var segmentThick = Enumerable.Range(0, segCnt)
                .Select(i => new LineOverload.Segment(
                    parts[i * 2],
                    parts[i * 2 + 1],
                    parts[i * 2 + 2]
                ))
                .ToArray();

            return segmentThick;
        }
    }
}