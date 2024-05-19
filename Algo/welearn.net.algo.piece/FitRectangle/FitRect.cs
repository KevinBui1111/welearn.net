using welearn.net.algo.piece.Common.Geo;
using welearn.net.easy;

namespace welearn.net.algo.piece.FitRectangle;

public class FitRect {
    private List<RectExt> _leftSortList = null!;
    private List<RectExt> _rightSortList = null!;
    private List<RectExt> _topSortList = null!;
    private List<RectExt> _bottomSortList = null!;

    private readonly int _topBoundary;
    private readonly int _rightBoundary;
    private readonly int _total;
    private Rectangle _searchRect = null!;

    public FitRect(List<Rectangle> rectangles, int topBoundary, int rightBoundary) {
        _topBoundary = topBoundary;
        _rightBoundary = rightBoundary;
        _total = rectangles.Count;
        Preparation(rectangles);
    }

    public Point? Find(Rectangle searchRect) {
        _searchRect = searchRect;

        foreach (var iRect in _rightSortList) {
            // determine high/low boundary to form a virtual rectangle with height = topBlock - bottomBlock
            var (topBlock, bottomBlock) = (GetTopBlock(iRect), GetBottomBlock(iRect));
            // search in boundary
            var point = FindInBoundary(iRect, topBlock, bottomBlock, iRect.IndexLeft);
            if (point != null) return point;
        }

        return null;
    }

    private Point? FindInBoundary(Rectangle iRect, int top, int bottom, int iFrom) {
        // check if searchRect 's height is fit to virtual rect 's height
        if (top - bottom < _searchRect.Height) return null;
        // find next block to the right
        var rightBlock = GetRightBlock(iRect.Right, top, bottom, iFrom);

        Point? result = null;
        // check if searchRect 's width is fit to  virtual rect 's width (= rightBlock.Left - iRect.Right)
        if (_searchRect.Width <= rightBlock.Left - iRect.Right)
            // found
            result = new Point { X = iRect.Right, Y = top };

        // right block split virtual rectangle into two part
        // check if partAbove is totally above iRect, then not process
        if (result == null && rightBlock.Top < iRect.Top)
            result = FindInBoundary(iRect, top, rightBlock.Top, iFrom + 1);

        // check if partBelow is totally below iRect, then not process
        if (result == null && iRect.Bottom < rightBlock.Bottom)
            result = FindInBoundary(iRect, rightBlock.Bottom, bottom, iFrom + 1);

        return result;
    }

    private void Preparation(List<Rectangle> rectangles) {
        _leftSortList = rectangles
            .OrderBy(r => r.Left)
            .Select((r, i) => new RectExt(r) { IndexLeft = i })
            .ToList();

        _topSortList = _leftSortList
            .OrderByDescending(r => r.Top)
            .ForEach((r, i) => r.IndexTop = i)
            .ToList();

        _bottomSortList = _leftSortList
            .OrderBy(r => r.Bottom)
            .ForEach((r, i) => r.IndexBottom = i)
            .ToList();

        var dummyFirstRect = new RectExt(0, _topBoundary, 0, _topBoundary) {
            IndexBottom = _total,
            IndexTop = _total
        };
        _rightSortList = new List<RectExt> { dummyFirstRect };
        _rightSortList.AddRange(
            _leftSortList
                .OrderBy(r => r.Right)
        );
    }

    private int GetTopBlock(RectExt rect) {
        for (var i = rect.IndexBottom; i < _total; ++i) {
            var checkRect = _bottomSortList[i];
            if (rect.Top <= checkRect.Bottom &&
                checkRect.Left <= rect.Right && rect.Right < checkRect.Right)
                return checkRect.Bottom;
        }

        return _topBoundary;
    }

    private int GetBottomBlock(RectExt rect) {
        for (var i = rect.IndexTop; i < _total; ++i) {
            var checkRect = _topSortList[i];
            if (checkRect.Top <= rect.Bottom &&
                checkRect.Left <= rect.Right && rect.Right < checkRect.Right)
                return checkRect.Top;
        }

        return 0; // bottom boundary
    }

    private Rectangle GetRightBlock(int left, int top, int bottom, int iFrom) {
        for (var i = iFrom; i < _total; ++i) {
            var checkRect = _leftSortList[i];
            if (left <= checkRect.Left &&
                bottom < checkRect.Top && checkRect.Bottom < top)
                return checkRect;
        }
        // reach to wall
        return new Rectangle(_rightBoundary, _topBoundary, 0, _topBoundary);
    }

    public static void Test() {
        // gen random rec
        const int max = 100;
        var rects = new List<Rectangle> {
                new(0, 7, 4, 2),
                new(4, 10, 4, 2),
                new(6, 5, 3, 4),
                new(2, 3, 1, 4)
            }
            .ToList();
        var fitRect = new FitRect(rects, 10, 10);
        var searchRect = new Rectangle(0, 0, 1, 10);
        var point = fitRect.Find(searchRect);
        Console.WriteLine(point);
    }
}