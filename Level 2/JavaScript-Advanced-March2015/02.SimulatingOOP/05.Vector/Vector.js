var Vector = function vectorInitialization() {
    this.dimensions = [];
    for (var index = 0; index < arguments.length; index++) {
        this.dimensions.push(parseInt(arguments[index]));
    }

    this.add = function add(vector) {
        if (!(vector instanceof Vector)) {
            throw new DOMException();
        }

        if (vector.dimensions.length != this.dimensions.length) {
            throw new DOMException();
        }

        var newDimensions = [];
        for (var index = 0; index < this.dimensions.length; index++) {
            newDimensions.push(this.dimensions[index] + vector.dimensions[index]);
        }

        var newVector = new Vector();
        newVector.dimensions = newDimensions;
        return newVector;
    }

    this.subtract = function subtract(vector) {
        if (!(vector instanceof Vector)) {
            throw new DOMException();
        }

        if (vector.dimensions.length != this.dimensions.length) {
            throw new DOMException();
        }

        var newDimensions = [];
        for (var index = 0; index < this.dimensions.length; index++) {
            newDimensions.push(this.dimensions[index] - vector.dimensions[index]);
        }

        var newVector = new Vector();
        newVector.dimensions = newDimensions;
        return newVector;
    }

    this.dot = function dot(vector) {
        if (!(vector instanceof Vector)) {
            throw new DOMException();
        }

        if (vector.dimensions.length != this.dimensions.length) {
            throw new DOMException();
        }

        var dotProduct = 0;
        for (var index = 0; index < this.dimensions.length; index++) {
            dotProduct += this.dimensions[index] * vector.dimensions[index];
        }

        return dotProduct;
    }

    this.norm = function norm() {
        var result = 0;
        for (var index = 0; index < this.dimensions.length; index++) {
            result += this.dimensions[index] * this.dimensions[index];
        }

        result = Math.sqrt(result);

        return result;
    }
}

Vector.prototype.toString = function() {
    return "{" + this.dimensions.join(", ") + "}";
}

var vector1 = new Vector(1, 2, 3);
var vector2 = new Vector(2, 3, 5);
var vector3 = vector1.add(vector2);
console.log(vector1.toString());
console.log(vector3.toString());
var dotProduct = vector1.dot(vector2);
console.log(dotProduct);
// vector1.add(2); - This will throw an exception