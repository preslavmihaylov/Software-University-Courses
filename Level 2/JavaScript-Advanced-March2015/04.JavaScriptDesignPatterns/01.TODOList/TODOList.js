var ElementsCreator = (function () {
    var itemCreatorCounter = 1;
    var itemIdCounter = 1;

    var Container = {
        constructor: function() {
            this.sections = [];
            this.element = this._addToDOM();
            return this;
        },
        addSection: function(section)
        {
            if (!(Object.getPrototypeOf(section) == Section)) {
                throw new Error("The parameter must be of type Section.");
            }

            this.sections.push(section);
            this.element.insertBefore(
                section.element,
                this.element.childNodes[this.element.childNodes.length - 2]);
        },
        _addToDOM: function() {
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
                'javascript: container.addSection(Object.create(ElementsCreator.Section).constructor(document.getElementById("sectionTitle").value));');

            element.appendChild(button);

            return element;
        }
    }

    var Section = {
        constructor: function(title) {
            this.title = title;
            this.element = this._addToDOM();

            return this;
        },
        addItem: function(item) {
            if (!(Object.getPrototypeOf(item) == Item)) {
                throw new Error("The parameter must be of type Item.");
            }
            
            this.element.insertBefore(
                item.element,
                this.element.childNodes[this.element.childNodes.length - 2]);
        },
        _addToDOM: function() {
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
                'javascript: container.sections[' +
                (itemCreatorCounter - 1) +
                '].addItem(Object.create(ElementsCreator.Item).constructor(document.getElementById("newItem ' +
                (itemCreatorCounter + 0) +
                '").value))');

            

            element.appendChild(button);
            itemCreatorCounter++;

            return element;
        }
    }

    var Item = {
        constructor: function(content) {
            this.content = content;
            this.element = this._addToDOM();
            return this;
        },
        _addToDOM: function () {
            var element = document.createElement("div");
            var checkbox = document.createElement('input');
            checkbox.type = "checkbox";
            checkbox.name = this.content;
            checkbox.id = "item " + itemIdCounter;

            checkbox.onclick = function() {
                if (checkbox.checked) {
                    element.style.background = "cyan";
                } else {
                    element.style.background = "transparent";
                }
            };

            var label = document.createElement('label');
            label.htmlFor = "item " + itemIdCounter;
            label.appendChild(document.createTextNode(this.content));

            itemIdCounter++;

            label.style.borderBottom = "1px solid black";
            label.style.padding = "3px";

            element.style.margin = "10px";

            element.appendChild(checkbox);
            element.appendChild(label);
            return element;
        }
    }

    return {
        Container: Container,
        Section: Section,
        Item: Item
}
})();

var container = Object.create(ElementsCreator.Container).constructor();
var section = Object.create(ElementsCreator.Section).constructor("Section 1");
section.addItem(Object.create(ElementsCreator.Item).constructor("item 1", true));
section.addItem(Object.create(ElementsCreator.Item).constructor("item 2", false));
section.addItem(Object.create(ElementsCreator.Item).constructor("item 3", true));

var section2 = Object.create(ElementsCreator.Section).constructor("Section 2");
section2.addItem(Object.create(ElementsCreator.Item).constructor("item 4"));
section2.addItem(Object.create(ElementsCreator.Item).constructor("item 5", true));
section2.addItem(Object.create(ElementsCreator.Item).constructor("item 6"));

container.addSection(section);
container.addSection(section2);
document.body.appendChild(container.element);

var temp = document.getElementById("sectionTitle");
var as;