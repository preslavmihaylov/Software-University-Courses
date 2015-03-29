var models = models || {};

(function () {
    var ShoppingCart = function() {
        this._items = [];

        this.addItem = function(item) {
            this._items.push(item);
        }

        this.getTotalPrice = function() {
            var price = 0;

            this._items.forEach(function(item) {
                price += item.price;
            });

            return price;
        }
    }

    models._getShoppingCart = function() {
        return new ShoppingCart();
    }

})(models);