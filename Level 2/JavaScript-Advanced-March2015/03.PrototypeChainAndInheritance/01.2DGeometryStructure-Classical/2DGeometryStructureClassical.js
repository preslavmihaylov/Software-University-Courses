Object.prototype.extends = function(parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
}

var Point = function(x, y) {
    this._x = x;
    this._y = y;
    this.toString = function () {
        return "X: " + this._x + " Y: " + this._y;
    }
}

var Shapes = (function () {
    var Shape = function(color) {
        this._color = color;
    }

    Shape.prototype.toString = function () {
        return "Color: " + this._color;
    }

    var Circle = function(center, radius, color) {
        this.extends(Shape);
        Shape.call(this, color);
        this._center = center;
        this._radius = radius;
    }

    Circle.prototype.toString = function() {
        return "Center: " + this._center.toString()
            + ", Radius: " + this._radius + ", " +
            Shape.prototype.toString.call(this);
    }

    var Rectangle = function(coords, width, height, color) {
        this.extends(Shape);
        Shape.call(this, color);
        this._coords = coords;
        this._width = width;
        this._height = height;
    }

    Rectangle.prototype.toString = function () {
        return "Coordinates: " + this._coords.toString() +
            ", Width: " + this._width + ", Height: " + this._height + ", " +
            Shape.prototype.toString.call(this);
    }

    var Triangle = function(coordsA, coordsB, coordsC, color) {
        this.extends(Shape);
        Shape.call(this, color);
        this._coordsA = coordsA;
        this._coordsB = coordsB;
        this._coordsC = coordsC;
    }

    Triangle.prototype.toString = function () {
        return "Coordinates A: " + this._coordsA.toString() +
               ", Coordinates B: " + this._coordsB.toString() +
               ", Coordinates C: " + this._coordsC.toString() +
               Shape.prototype.toString.call(this);
    }

    var Line = function(coordsA, coordsB, color) {
        this.extends(Shape);
        Shape.call(this, color);
        this._coordsA = coordsA;
        this._coordsB = coordsB;
    }

    Line.prototype.toString = function () {
        return "Coordinates A: " + this._coordsA.toString() +
               ", Coordinates B: " + this._coordsB.toString() + ", " +
               Shape.prototype.toString.call(this);
    }

    var LineSegment = function (coordsA, coordsB, color) {
        this.extends(Shape);
        Shape.call(this, color);
        this._coordsA = coordsA;
        this._coordsB = coordsB;
    }

    LineSegment.prototype.toString = function () {
        return "Coordinates A: " + this._coordsA.toString() +
               ", Coordinates B: " + this._coordsB.toString() + ", " +
               Shape.prototype.toString.call(this);
    }

    return {
        Rectangle: Rectangle,
        Circle: Circle,
        Triangle: Triangle,
        Line: Line,
        LineSegment: LineSegment
    }

})();

var rect = new Shapes.Rectangle(new Point(1, 2), 30, 30, "red");
var triangle = new Shapes.Triangle(new Point(1, 2), new Point(5, 5), new Point(5, 4), "green");
var line = new Shapes.Line(new Point(8, 8), new Point(3, 3), "green");

console.log(rect._width);
console.log(triangle.toString());
console.log(line.toString());