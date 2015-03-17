Array.prototype.flatten = function flatten() {
    var flattenedArray = [];
    for (var index = 0; index < this.length; index++) {
        if (this[index] instanceof Array) {
            flattenedArray = flattenedArray.concat(this[index].flatten());
        } else {
            flattenedArray.push(this[index]);
        }
    }

    return flattenedArray;
}

var arr = [1, [2, 4], [5, 6]];
var flattened = arr.flatten();
console.log(flattened);
console.log(arr);