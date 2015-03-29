define('container', function() {
    return (function () {
        var Container = {
            constructor: function () {
                this.sections = [];
                this.element = this._addToDOM();
                return this;
            },
            addSection: function (section) {
                this.sections.push(section);
                this.element.insertBefore(
                    section.element,
                    this.element.childNodes[this.element.childNodes.length - 2]);
            },
            _addToDOM: function () {
                var element = document.createElement("div");

                element.style.padding = "10px";
                element.style.border = "5px solid black";

                var inputText = document.createElement('input');
                inputText.setAttribute('type', 'text');
                inputText.setAttribute('class', 'section-adder');
                inputText.setAttribute('placeholder', 'Title...');
                inputText.id = "sectionTitle";
                element.appendChild(inputText);

                var button = document.createElement('input');
                button.setAttribute('type', 'button');
                button.setAttribute('value', 'New Section');
                button.setAttribute(
                    'onclick',
                    'javascript: addSection(sectionTitle.value)');

                element.appendChild(button);

                return element;
            }
        }

        return Container;
    })();
});