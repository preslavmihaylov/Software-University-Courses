var models = models || {};

(function() {
    var Category = function(name) {
        this.name = name;
        this._categories = [];
        this._items = [];

        this.addCategory = function(category) {
            this._categories.push(category);
        }

        this.getCategories = function() {
            return this._categories;
        }

        this.addItem = function (item) {
            this._items.push(item);
        }

        this.getItems = function() {
            return this._items;
        }
    }

    // var cat = new Category("pesho");
    // cat.addCategory(new Category("tosho"));
    // var cat2 = new Category("toshko");
    // console.log(cat2._categories);
    models.getCategory = function(name) {
        return new Category(name);
    }

})(models);