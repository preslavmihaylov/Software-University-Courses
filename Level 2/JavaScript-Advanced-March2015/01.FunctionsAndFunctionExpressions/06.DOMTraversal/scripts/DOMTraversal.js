
traverse(".birds");

function traverse(selector) {
    var nodeToTraverse = document.querySelectorAll(selector);

    for (var index = 0; index < nodeToTraverse.length; index++) {
        traverseNode(nodeToTraverse[index], "");
    }

    function traverseNode(node, spacing) {
        spacing = spacing || '  ';
        var output = spacing + node.nodeName.toLowerCase() + ": ";
        if (node.id != "") {
            output += "id=\"" + node.id + "\"";
        }

        if (node.className != "") {
            if (node.id != "") {
                output += ", ";
            }
            output += "class=\"" + node.className + "\"";
        }

        console.log(output);

        for (var i = 0, len = node.childNodes.length; i < len; i += 1) {

            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '   ');
            }
        }
    }
}
