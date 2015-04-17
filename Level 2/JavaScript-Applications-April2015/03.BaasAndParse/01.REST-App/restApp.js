var headers = {
    'X-Parse-Application-Id': 'cDOllTGD0mgH2eJVkoAEQX8Kl5uG9V5BOF99Rxz0',
    'X-Parse-REST-API-Key': 'Chn6ZbJZKOcaI42fa2wQdrgoMZSBg88eWJmeOmVd'
};
initializeCountries();
initializeTowns();
var currentTownIndex;

function initializeCountries() {
    $.ajax({
        method: 'GET',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Country'
    }).success(function (data) {
        var countriesContainer = $('#countriesContainer');
        var countries = $('<ul></ul>');

        for (var country in data.results) {
            var liElement = $('<li></li>').text(data.results[country].name);

            var deleteButton = document.createElement('button');
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick',
                'javascript: deleteCountry("' + data.results[country].objectId + '")');

            var editButton = document.createElement('button');
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick',
                'javascript: editCountry("' + data.results[country].objectId + '")');

            liElement.append(editButton);
            liElement.append(deleteButton);

            countries.append(liElement);
        }

        countriesContainer.append(countries);
    });
}

function initializeTowns() {
    var townsDropdown = document.createElement('select');
    townsDropdown.setAttribute('onclick', 'javascript: generateTowns(this);');
    townsDropdown.setAttribute('id', 'townsDropdown');

    $.ajax({
        method: 'GET',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Country'
    }).success(function (data) {
        for (var country in data.results) {
            var currentCountryOption = $('<option></option>')
                .text(data.results[country].name)
                .val(data.results[country].objectId);

            townsDropdown = $(townsDropdown).append(currentCountryOption);
        }
        generateTowns(townsDropdown[0]);
    });

    $('#townsContainer').before(townsDropdown);
}

function generateTowns(target) {
    if (target.selectedIndex !== currentTownIndex) {
        currentTownIndex = target.selectedIndex;
        $('#townsList').empty();

        var countryId = target.options[target.selectedIndex].value;

        var whereParameter = '{' +
            '"country":' +
                '{"__type":"Pointer","className":"Country","objectId":"' + countryId + '"}' +
            '}';

        $.ajax({
            method: 'GET',
            headers: headers,
            url: 'https://api.parse.com/1/classes/Town?where=' + whereParameter
        }).success(function (data) {
            var townsList = $('#townsList');
            for (var town in data.results) {
                var liElement = $('<li></li>').text(data.results[town].name);
                var deleteButton = document.createElement('button');
                deleteButton.innerText = "Delete";

                deleteButton.setAttribute('onclick', 'javascript: deleteTown("' +
                    data.results[town].objectId +
                    '")');

                var editButton = document.createElement('button');
                editButton.innerText = "Edit";

                editButton.setAttribute('onclick', 'javascript: editTown("' +
                    data.results[town].objectId +
                    '")');

                liElement.append(editButton);
                liElement.append(deleteButton);
                townsList.append(liElement);
            }
        });
    }
}

function addTown() {
    var townName = window.prompt('Enter the town\'s name');
    var townsDropdown = $('#townsDropdown');
    var countryName = townsDropdown[0][townsDropdown[0].selectedIndex].value;

    var whereParameter = '{"objectId":"' + countryName + '"}';

    $.ajax({
        method: 'GET',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Country?where=' + whereParameter
    }).success(function(data) {
        if (data.results.length > 0) {
            var data = {
                "name": townName,
                "country": {
                    "__type": "Pointer",
                    "className": "Country",
                    "objectId": data.results[0].objectId
                }
            };

            $.ajax({
                method: 'POST',
                headers: {
                    'X-Parse-Application-Id': 'cDOllTGD0mgH2eJVkoAEQX8Kl5uG9V5BOF99Rxz0',
                    'X-Parse-REST-API-Key': 'Chn6ZbJZKOcaI42fa2wQdrgoMZSBg88eWJmeOmVd'
                },
                url: 'https://api.parse.com/1/classes/Town',
                data: JSON.stringify(data)
            }).success(function() {
                window.location.replace(window.location.href);
            });
        } else {
            alert('Invalid country id.');
        }
    });
}

function deleteTown(id) {
    $.ajax({
        method: 'DELETE',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Town/' + id
    }).success(function () {
        window.location.replace(window.location.href);
    });
}

function deleteCountry(id) {
    $.ajax({
        method: 'DELETE',
        headers: {
            'X-Parse-Application-Id': 'cDOllTGD0mgH2eJVkoAEQX8Kl5uG9V5BOF99Rxz0',
            'X-Parse-REST-API-Key': 'Chn6ZbJZKOcaI42fa2wQdrgoMZSBg88eWJmeOmVd'
        },
        url: 'https://api.parse.com/1/classes/Country/' + id
    }).success(function() {
        window.location.replace(window.location.href);
    });
}

function editTown(id) {
    var newName = window.prompt("Enter the town's new name");

    $.ajax({
        method: 'PUT',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Town/' + id,
        data: JSON.stringify({
            'name': newName
        })
    }).success(function () {
        window.location.replace(window.location.href);
    });
}

function editCountry(id) {
    var newName = window.prompt("Enter the country's new name");

    $.ajax({
        method: 'PUT',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Country/' + id,
        data: JSON.stringify({
            'name': newName
        })
    }).success(function() {
        window.location.replace(window.location.href);
    });
}

function newCountry() {
    var name = window.prompt('Enter the country\'s name');

    $.ajax({
        method: 'POST',
        headers: headers,
        url: 'https://api.parse.com/1/classes/Country',
        data: JSON.stringify({
            'name': name
        })
    }).success(function() {
        window.location.replace(window.location.href);
    });
}
