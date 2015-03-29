define('section', function() {
    return (function () {
        var itemCreatorCounter = 1;

        var Section = {
            constructor: function (title) {
                this.title = title;
                this.element = this._addToDOM();

                return this;
            },
            addItem: function (item) {
                this.element.insertBefore(
                    item.element,
                    this.element.childNodes[this.element.childNodes.length - 2]);
            },
            _addToDOM: function () {
                var element = document.createElement("section");
                var title = document.createElement("div");
                title.innerHTML = this.title;
                title.style.align = "right";
                title.style.fontWeight = "bold";
                title.style.margin = "10px";
                element.appendChild(title);

                element.style.margin = "5px";
                element.style.border = "1px solid black";

                var inputText = document.createElement('input');
                inputText.setAttribute('type', 'text');
                inputText.setAttribute('class', 'section-adder');
                inputText.setAttribute('placeholder', 'Item title...');
                inputText.id = "newItem " + itemCreatorCounter;
                inputText.style.margin = "10px";

                element.appendChild(inputText);

                var button = document.createElement('input');
                button.setAttribute('type', 'button');
                button.setAttribute('value', 'New Item');
                button.setAttribute(
                    'onclick',
                    'javascript: addItem(document.getElementById("' +
                    inputText.id +
                    '").value, ' +
                    (itemCreatorCounter - 1) +
                    ')');



                element.appendChild(button);
                itemCreatorCounter++;

                return element;
            }
        }

        return Section;
    })();
});