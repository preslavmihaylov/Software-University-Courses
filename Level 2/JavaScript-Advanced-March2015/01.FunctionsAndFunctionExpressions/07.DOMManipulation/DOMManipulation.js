var domManipulator = (function() {
    function appendElement(element, parentSelector) {
        var nodesToAppendTo = document.querySelectorAll(parentSelector);
        for (var index = 0; index < nodesToAppendTo.length; index++) {
            nodesToAppendTo[index].appendChild(element);
        }
    }

    function removeChild(parentSelector, childSelector) {
        var parents = document.querySelectorAll(parentSelector);

        for (var i = 0; i < parents.length; i++) {
            var elementsToRemove = parents[i].querySelectorAll(childSelector);

            for (var j = 0; j < elementsToRemove.length; j++) {
                if (elementsToRemove[j].parentNode === parents[i]) {
                    parents[i].removeChild(elementsToRemove[j]);
                }
            }
        }
    }

    function addHandler(elementSelector, eventType, eventHandler) {
        var selectedElements = document.querySelectorAll(elementSelector);
        for (var i = 0; i < selectedElements.length; i++) {
            selectedElements[i].addEventListener(eventType, eventHandler);
        }
    }

    function retrieveElements(selector) {
        var selectedElements = document.querySelectorAll(selector);
        var elementsToReturn = [];
        for (var i = 0; i < selectedElements.length; i++) {
            elementsToReturn.push(selectedElements[i]);
        }

        return elementsToReturn;
    }

    return {
        appendElement: appendElement,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
})();

var liElement = document.createElement("li");
// Appends a list item to ul.birds-list
domManipulator.appendElement(liElement, ".birds-list");
domManipulator.removeChild("ul.birds-list", "li:first-child");
// Adds a click event to all bird list items
domManipulator.addHandler("li.bird", 'click', function () { alert("I'm a bird!") });

var elements = domManipulator.retrieveElements(".bird");
for (var index = 0; index < elements.length; index++) {
    console.log(elements[index].toString());
}


