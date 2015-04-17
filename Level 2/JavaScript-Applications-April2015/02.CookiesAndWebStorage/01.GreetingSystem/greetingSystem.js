// delete localStorage['username'];
// delete localStorage['totalVisits'];

if (!localStorage["username"]) {
    var textField = $('<input type="text" id="username">');
    var button = $('<button onclick="javascript: registerUser()">Register</button>');
    $('body').append(textField);
    $('body').append(button);
} else {
    localStorage['totalVisits']++;
    if (!sessionStorage['sessionVisits']) {
        sessionStorage.setItem('sessionVisits', 1);
    } else {
        sessionStorage['sessionVisits']++;
    }

    $('body').append('<div>Welcome ' + localStorage['username'] + '</div>');
    $('body').append('<div>Total visits: ' + localStorage['totalVisits'] + '</div>');
    $('body').append('<div>Session visits: ' + sessionStorage['sessionVisits'] + '</div>');
}

function registerUser() {
    var username = $('#username').val();
    localStorage['username'] = username;
    localStorage['totalVisits'] = 1;
    sessionStorage.setItem('sessionVisits', 1);

    $('body').empty();
    $('body').append('<div>Welcome ' + username + '</div>');
    $('body').append('<div>Total visits: ' + localStorage['totalVisits'] + '</div>');
    $('body').append('<div>Session visits: ' + sessionStorage['sessionVisits'] + '</div>');
}