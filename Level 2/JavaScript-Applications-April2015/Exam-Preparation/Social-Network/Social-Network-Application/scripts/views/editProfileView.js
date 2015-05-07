var app = app || {};

app.editProfileView = (function () {
    function EditProfileView(selector, data) {
        return $.get('templates/editProfile.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
            if (data.gender == 'Male') {
                $('#male').attr('checked', 'checked');
            } else if (data.gender == 'Female') {
                $('#female').attr('checked', 'checked');
            } else {
                $('#other').attr('checked', 'checked');
            }
        });
    }

    return {
        load: function (selector, data) {
            return EditProfileView(selector, data);
        }
    }
}());