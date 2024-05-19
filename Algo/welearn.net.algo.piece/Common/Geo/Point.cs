namespace welearn.net.algo.piece.Common.Geo;

public struct Point {
    public int X;
    public int Y;

    public Point(string form) {
        var parts = form.Split(' ');
        X = int.Parse(parts[0]);
        Y = int.Parse(parts[1]);
    }

    public override string ToString() => $"{X} {Y}";

    public static implicit operator Point(string size) => new(size);

    public static implicit operator string(Point point) => point.ToString();
}