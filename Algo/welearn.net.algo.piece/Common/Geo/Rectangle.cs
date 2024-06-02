namespace welearn.net.algo.piece.FitRectangle;

public class Rectangle {
    public readonly int Left;
    public readonly int Top;
    public readonly int Width;
    public readonly int Height;

    public Rectangle(string form) {
        var parts = form.Split(' ');
        Left = int.Parse(parts[0]);
        Top = int.Parse(parts[1]);
        Width = int.Parse(parts[2]);
        Height = int.Parse(parts[3]);
    }

    public Rectangle(int left, int top, int width, int height) {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    protected Rectangle(Rectangle rec) : this(rec.Left, rec.Top, rec.Width, rec.Height) { }


    public int Right => Left + Width;
    public int Bottom => Top - Height;

    public override string ToString() => $"{Left} {Top} {Width} {Height}";

    public static implicit operator Rectangle(string form) => new(form);
}