"use strict";

class FitRect {
  constructor(rectangles, boundary) {
    [this.boundary, this.total] = [boundary, rectangles.length];
    this.Preparation(rectangles);
  }

  Find(searchRect) {
    this.searchRect = searchRect;

    for (const iRect of this.rightSortList) {
      // determine high/low boundary to form a virtual rectangle with height = topBlock - bottomBlock
      let [topBlock, bottomBlock] = [this.GetTopBlock(iRect), this.GetBottomBlock(iRect)];
      // search in boundary
      let point = this.FindInBoundary(iRect, topBlock, bottomBlock, iRect.IndexLeft);
      if (point != null) return point;
    }

    return null;
  }

  FindInBoundary(iRect, top, bottom, iFrom) {
    // check if searchRect 's height is fit to virtual rect 's height
    if (top - bottom < this.searchRect.Height) return null;
    // find next block to the right
    let rightBlock = this.GetRightBlock(iRect.Right, top, bottom, iFrom);

    let result = null;
    // check if searchRect 's width is fit to  virtual rect 's width (= rightBlock.Left - iRect.Right)
    if (this.searchRect.Width <= rightBlock.Left - iRect.Right)
      // found
      result = {X: iRect.Right, Y: top};

    // right block split virtual rectangle into two part
    // check if partAbove is totally above iRect, then not process
    if (result == null && rightBlock.Top < iRect.Top)
      result = this.FindInBoundary(iRect, top, rightBlock.Top, iFrom + 1);

    // check if partBelow is totally below iRect, then not process
    if (result == null && iRect.Bottom < rightBlock.Bottom)
      result = this.FindInBoundary(iRect, rightBlock.Bottom, bottom, iFrom + 1);

    return result;
  }

  Preparation(rectangles) {
    this.leftSortList = rectangles.toSorted((r1, r2) => r1.Left - r2.Left)
    this.leftSortList.forEach((r, i) => r.IndexLeft = i);

    this.topSortList = rectangles.toSorted((r1, r2) => r2.Top - r1.Top)
    this.topSortList.forEach((r, i) => r.IndexTop = i);

    this.bottomSortList = rectangles.toSorted((r1, r2) => r1.Bottom - r2.Bottom)
    this.bottomSortList.forEach((r, i) => r.IndexBottom = i);

    let dummyFirstRect = new Rectangle(0, this.boundary.Height, 0, this.boundary.Height);
    dummyFirstRect.IndexLeft = 0;
    dummyFirstRect.IndexBottom = dummyFirstRect.IndexTop = this.total;

    this.rightSortList = rectangles.toSorted((r1, r2) => r1.Right - r2.Right);
    this.rightSortList.unshift(dummyFirstRect);
  }

  GetTopBlock(rect) {
    for (let i = rect.IndexBottom; i < this.total; ++i) {
      let checkRect = this.bottomSortList[i];
      if (rect.Top <= checkRect.Bottom &&
        checkRect.Left <= rect.Right && rect.Right < checkRect.Right)
        return checkRect.Bottom;
    }

    return this.boundary.Height;
  }

  GetBottomBlock(rect) {
    for (let i = rect.IndexTop; i < this.total; ++i) {
      let checkRect = this.topSortList[i];
      if (checkRect.Top <= rect.Bottom &&
        checkRect.Left <= rect.Right && rect.Right < checkRect.Right)
        return checkRect.Top;
    }

    return 0; // bottom boundary
  }

  GetRightBlock(left, top, bottom, iFrom) {
    for (let i = iFrom; i < this.total; ++i) {
      let checkRect = this.leftSortList[i];
      if (left <= checkRect.Left &&
        bottom < checkRect.Top && checkRect.Bottom < top)
        return checkRect;
    }
    // reach to wall
    return new Rectangle(this.boundary.Width, this.boundary.Height, 0, this.boundary.Height);
  }
}