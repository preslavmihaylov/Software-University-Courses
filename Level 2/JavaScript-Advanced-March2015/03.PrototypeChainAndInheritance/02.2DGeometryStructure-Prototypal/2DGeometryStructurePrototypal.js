Object.prototype.extends = function (properties) {
    function f() { };
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
}


var Point = {
    constructor: function (x, y) {
        Object.defineProperty(this, "x", {
            get: function () {
                return x;
            },
            set: function (val) {
                if (!val) {
                    throw new Error("The X must be assigned");
                }
                return x = val;
            }
        });
        Object.defineProperty(this, "y", {
            get: function () {
                return y;
            },
            set: function (val) {
                if (!val) {
                    throw new Error("The Y must be assigned");
                }
                return y = val;
            }
        });

        this.x = x;
        this.y = y;

        return this;
    },
    toString: function() {
        return "X: " + this.x + ", Y: " + this.y;
    }
}

var Shapes = (function () {
    var Shape = {
        constructor: function (color) {
            Object.defineProperty(this, "color", {
                get: function () {
                    return color;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The color must be assigned");
                    }
                    return color = val;
                }
            });
            this.color = color;
        },
        toString: function() {
            return "Color: " + this.color;
        }
    }

    var Rectangle = Shape.extends({
        constructor: function (coords, width, height, color) {
            this._super.constructor.call(this, color);
            Object.defineProperty(this, "coords", {
                get: function () {
                    return coords;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates must be assigned");
                    }
                    return coords = val;
                }
            });
            Object.defineProperty(this, "width", {
                get: function () {
                    return width;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The width must be assigned");
                    }
                    return width = val;
                }
            });
            Object.defineProperty(this, "height", {
                get: function () {
                    return height;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The height must be assigned");
                    }
                    return height = val;
                }
            });
            this.coords = coords;
            this.width = width;
            this.height = height;

            return this;
        },
        toString: function () {
            return "Coordinates: " + this.coords.toString() +
                ", Width: " + this.width + ", Height:" + this.height + ", " +
                this._super.toString.call(this);
        }
    });

    var Circle = Shape.extends({
        constructor: function(center, radius, color) {
            this._super.constructor.call(this, color);
            Object.defineProperty(this, "center", {
                get: function () {
                    return center;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The center must be assigned");
                    }
                    return center = val;
                }
            });
            Object.defineProperty(this, "radius", {
                get: function () {
                    return radius;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The radius must be assigned");
                    }
                    return radius = val;
                }
            });
            this.center = center;
            this.radius = radius;

            return this;
        },
        toString: function() {
            return "Coordinates: " + this.center.toString() +
                ", " + ", Radius: " + this.radius + ", " +
                this._super.toString.call(this);
        }
    });

    var Triangle = Shape.extends({
        constructor: function (coordsA, coordsB, coordsC, color) {
            this._super.constructor.call(this, color);
            Object.defineProperty(this, "coordsA", {
                get: function () {
                    return coordsA;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates of A must be assigned");
                    }
                    return coordsA = val;
                }
            });
            Object.defineProperty(this, "coordsB", {
                get: function () {
                    return coordsB;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates of B must be assigned");
                    }
                    return coordsB = val;
                }
            });
            Object.defineProperty(this, "coordsC", {
                get: function () {
                    return coordsC;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates of C must be assigned");
                    }
                    return coordsC = val;
                }
            });
            this.coordsA = coordsA;
            this.coordsB = coordsB;
            this.coordsC = coordsC;

            return this;
        },
        toString: function () {
            return "Coordinates A: " + this.coordsA.toString() +
                ", Coordinates B: " + this.coordsB.toString() +
                ", Coordinates C: " + this.coordsC.toString() + ", " +
                this._super.toString.call(this);
        }
    });

    var Line = Shape.extends({
        constructor: function (coordsA, coordsB, color) {
            this._super.constructor.call(this, color);
            Object.defineProperty(this, "coordsA", {
                get: function () {
                    return coordsA;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates of A must be assigned");
                    }
                    return coordsA = val;
                }
            });
            Object.defineProperty(this, "coordsB", {
                get: function () {
                    return coordsB;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates of B must be assigned");
                    }
                    return coordsB = val;
                }
            });
            this.coordsA = coordsA;
            this.coordsB = coordsB;

            return this;
        },
        toString: function () {
            return "Coordinates A: " + this.coordsA.toString() +
                ", Coordinates B: " + this.coordsB.toString() + ", " +
                this._super.toString.call(this);
        }
    });

    var LineSegment = Shape.extends({
        constructor: function (coordsA, coordsB, color) {
            this._super.constructor.call(this, color);
            Object.defineProperty(this, "coordsA", {
                get: function () {
                    return coordsA;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates of A must be assigned");
                    }
                    return coordsA = val;
                }
            });
            Object.defineProperty(this, "coordsB", {
                get: function () {
                    return coordsB;
                },
                set: function (val) {
                    if (!val) {
                        throw new Error("The coordinates of B must be assigned");
                    }
                    return coordsB = val;
                }
            });
            this.coordsA = coordsA;
            this.coordsB = coordsB;

            return this;
        },
        toString: function () {
            return "Coordinates A: " + this.coordsA.toString() +
                ", Coordinates B: " + this.coordsB.toString() + ", " +
                this._super.toString.call(this);
        }
    });

    return {
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        LineSegment: LineSegment,
        Line: Line
    }

})();

var circle = Object.create(Shapes.Circle)
    .constructor(Object.create(Point).constructor(1, 2), 2, "red");

var circle2 = Object.create(Shapes.Circle)
    .constructor(Object.create(Point).constructor(2, 3), 4, "green");

console.log(circle2.toString());
console.log(circle.toString());

var triangle = Object.create(Shapes.Triangle)
    .constructor(Object.create(Point).constructor(2, 3),
                 Object.create(Point).constructor(6, 7),
                 Object.create(Point).constructor(8, 5),
                 "green");

var triangle2 = Object.create(Shapes.Triangle)
    .constructor(Object.create(Point).constructor(6, 6),
                 Object.create(Point).constructor(9, 9),
                 Object.create(Point).constructor(12, 12),
                 "pink");

console.log(triangle.toString());
console.log(triangle2.toString());