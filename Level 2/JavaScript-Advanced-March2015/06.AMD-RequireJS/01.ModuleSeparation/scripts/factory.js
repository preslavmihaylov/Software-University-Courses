define('factory', function (require) {
    return (function () {
        var Container = require('container');
        var Section = require('section');
        var Item = require('item');

        return {
            getContainer: function() {
                return Object.create(Container).constructor();
            },
            getSection: function(title) {
                return Object.create(Section).constructor(title);
            },
            getItem: function(title) {
                return Object.create(Item).constructor(title);
            }
        }
    })();
});