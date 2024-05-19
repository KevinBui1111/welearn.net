namespace welearn.net.algo.piece.FitRectangle;

public class Rectangle {
    public int Left;
    public int Top;
    public int Width;
    public int Height;

    public Rectangle(int left, int top, int width, int height) {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    protected Rectangle(Rectangle rec) {
        Left = rec.Left;
        Top = rec.Top;
        Width = rec.Width;
        Height = rec.Height;
    }
    

    public int Right => Left + Width;
    public int Bottom => Top - Height;

    public override string ToString() => $"{Left} {Top} {Width} {Height}";
}