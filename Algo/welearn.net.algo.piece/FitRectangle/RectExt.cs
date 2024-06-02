namespace welearn.net.algo.piece.FitRectangle;

public class RectExt : Rectangle {
    public int IndexTop;
    public int IndexLeft;
    public int IndexBottom;

    public RectExt(int left, int top, int width, int height) : base(left, top, width, height) { }
    public RectExt(Rectangle rec) : base(rec) { }
}