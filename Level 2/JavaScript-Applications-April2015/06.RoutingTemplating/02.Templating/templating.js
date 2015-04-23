var data = {
    people: [
        { name: 'Pesho', job: 'Programmer', website: 'pesho.com' },
        { name: 'Gosho', job: 'Artist', website: 'gosho.com' },
        { name: 'Tosho', job: 'Singer', website: 'tosho.com' },
        { name: 'Bosho', job: 'Plumber', website: 'bosho.com' }
    ]
}

$.get('template.html', function (template) {
    var output = Mustache.render(template, data);

    $('#wrapper').html(output);
});