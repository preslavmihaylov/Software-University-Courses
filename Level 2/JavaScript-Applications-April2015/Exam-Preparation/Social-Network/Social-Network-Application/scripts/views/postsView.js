var app = app || {};

app.postsView = (function () {
    function PostsView(selector, data) {
        $(selector).empty();
        return $.get('templates/posts.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        });
    }

    return {
        load: function (selector, data) {
            return PostsView(selector, data);
        }
    }
}());