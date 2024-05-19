namespace welearn.net.algo.piece.Common.Geo;

public struct Size {
    public int Width;
    public int Height;

    public Size(int width, int height) {
        Width = width;
        Height = height;
    }

    public Size(string form) {
        var parts = form.Split(' ');
        Width = int.Parse(parts[0]);
        Height = int.Parse(parts[1]);
    }

    public override string ToString() => $"{Width} {Height}";

    public static implicit operator Size(string size) => new(size);
}