var specialConsole = (function () {
    function writeLine(value) {
        if (arguments.length > 1) {
            console.log(format.apply(this, arguments));
        } else {
            console.log(value);
        }
    }

    function writeError(value) {
        if (arguments.length > 1) {
            console.error(format.apply(this, arguments));
        } else {
            console.error(value);
        }
    }

    function writeWarning(value) {
        if (arguments.length > 1) {
            console.warn(format.apply(this, arguments));
        } else {
            console.warn(value);
        }
    }

    function writeInfo(value) {
        if (arguments.length > 1) {
            console.info(format.apply(this, arguments));
        } else {
            console.info(value);
        }
    }

    function format() {
        var pattern = /([^}{]*)({[0-9]+})/ig;
        var result = arguments[0].replace(pattern, function(match, text, placeholder) {
            var numIndex = placeholder.split(/{|}/);

            if (format.arguments[parseInt(numIndex[1]) + 1] == undefined) {
                throw new RangeException();
            }

            return text + format.arguments[parseInt(numIndex[1]) + 1].toString();
        });

        return result;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeInfo: writeInfo,
        writeWarning: writeWarning
    };
})();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Object: {0}", { name: "Gosho", toString: function() { return this.name; } });
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
specialConsole.writeError("Error object: {0}", { msg: "An error happened", toString: function() { return this.msg } });
