"use strict";

class Rectangle {
    constructor(left, top, width, height) {
        [this.Left, this.Top, this.Width, this.Height] = [+left, +top, +width, +height];
    }
    
    get Right() {
        return this.Left + this.Width;
    }

    get Bottom() {
        return this.Top - this.Height;
    }

    toString() {
        return `${Left} ${Top} ${Width} ${Height}`;
    }
}