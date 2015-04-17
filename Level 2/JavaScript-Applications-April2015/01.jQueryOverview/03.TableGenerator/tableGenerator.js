generateTable('[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},' +
               '{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},' +
               '{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]');

function generateTable(json) {
    var objects = JSON.parse(json);
    var table = $(document.createElement('table'));
    table.css('border-collapse', 'collapse');
    // $(document.body).append(table);

    var thead = $('<tr></tr>');
    for (var key in objects[0]) {
        var th = $('<th></th>').text(key);
        th.css('padding', '10px');
        th.css('font-size', '20px');
        th.css('color', 'white');
        th.css('border', '1px solid black');
        th.css('background-color', 'darkgreen');
        thead.append(th);
    }
    table.append(thead);

    for (var index = 0; index < objects.length; index++) {
        var tr = $('<tr></tr>');
        for (var key in objects[index]) {
            var td = $('<td></td>').text(objects[index][key]);
            td.css('padding', '10px');
            td.css('font-size', '20px');
            td.css('border', '1px solid black');
            tr.append(td);
        }
        table.append(tr);
    }
    $(document.body).append(table);
}