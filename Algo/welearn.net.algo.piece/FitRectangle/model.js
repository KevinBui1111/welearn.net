"use strict";

class Rectangle {
    constructor(left, top, width, height) {
        [this.Left, this.Top, this.Height, this.Width] = [left, top, width, height];
    }

    toString() {
        return `${Left} ${Top} ${Width} ${Height}`;
    }
}