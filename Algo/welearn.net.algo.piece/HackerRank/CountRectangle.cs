using System.Drawing;

namespace welearn.net.algo.piece.HackerRank;

//https://www.geeksforgeeks.org/find-number-of-rectangles-that-can-be-formed-from-a-given-set-of-coordinates/
public class CountRectangle {
    public static int NumberOfRectangle(List<Point> points) {
        var setPoints = new HashSet<string>(); 
        foreach (var p in points) {
            setPoints.Add($"{p.X}-{p.Y}");
        }

        var count = 0;
        for (var i = 0; i < points.Count; ++i)  {
            for (var k = i + 1; k < points.Count; ++k) {
                if (points[i].X != points[k].X && points[i].Y != points[k].Y &&
                    // check have point (iX, kY) & (kX, iY) 
                    setPoints.Contains($"{points[i].X}-{points[k].Y}") &&
                    setPoints.Contains($"{points[k].X}-{points[i].Y}"))
                    ++count;
            }
        }
        
        return count / 2;
    }
}