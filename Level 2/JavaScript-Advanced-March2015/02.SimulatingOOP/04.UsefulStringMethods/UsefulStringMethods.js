String.prototype.startsWith = function startsWith(substring) {
    return this.indexOf(substring) == 0;
}

String.prototype.endsWith = function endsWith(substring) {
    return this.indexOf(substring) == this.length - substring.length;
}

String.prototype.left = function left(count) {
    if (count > this.length) {
        return this.toString();
    } else {
        return this.substr(0, count);
    }
}

String.prototype.right = function right(count) {
    if (count > this.length) {
        return this.toString();
    } else {
        return this.substr(this.length - count, count);
    }
}

String.prototype.padLeft = function padLeft(count, character) {
    var padded = new Array(count + 1);
    if (character == undefined) {
        padded = padded.join(" ");
    } else {
        padded = padded.join(character);
    }

    return padded + this;
}

String.prototype.padRight = function padRight(count, character) {
    var padded = new Array(count + 1);
    if (character == undefined) {
        padded = padded.join(" ");
    } else {
        padded = padded.join(character);
    }

    return this + padded;
}

String.prototype.repeat = function repeat(count) {
    var result = "";
    for (var index = 0; index < count; index++) {
        result += this;
    }

    return result;
}

var str = "Illuminati";
console.log(str.startsWith("bobo"));
console.log(str.startsWith("Ill"));
console.log(str.endsWith("bati"));
console.log(str.endsWith("ati"));
console.log(str.left(4));
console.log(str.right(30));
console.log(str.padLeft(4));
console.log(str.padLeft(4, "p"));
console.log(str.padRight(4) + "a");
console.log(str.padRight(4, "p"));
console.log(str.repeat(4));
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));