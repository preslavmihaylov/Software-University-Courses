var container,
    section,
    section2;

require(['factory'], function (factory) {
    container = factory.getContainer();
    section = Object.create(factory.getSection("Section 1"));
    section.addItem(factory.getItem("item 1"));
    section.addItem(factory.getItem("item 2"));
    section.addItem(factory.getItem("item 3"));
    
    section2 = factory.getSection("Section 2");
    section2.addItem(factory.getItem("item 4"));
    section2.addItem(factory.getItem("item 5"));
    section2.addItem(factory.getItem("item 6"));
    
    container.addSection(section);
    container.addSection(section2);
    document.body.appendChild(container.element);
});

function addSection(sectionTitle) {
    require(['factory'], function (factory) {
        container.addSection(factory.getSection(sectionTitle));
    });
}

function addItem(itemTitle, sectionIndex) {
    require(['factory'], function (factory) {
        container.sections[sectionIndex].addItem(factory.getItem(itemTitle));
    });
}