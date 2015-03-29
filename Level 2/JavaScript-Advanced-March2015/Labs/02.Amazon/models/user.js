var models = models || {};

(function () {
    var User = function(username, fullName, balance) {
        this.username = username;
        this.fullName = fullName;
        this._balance = balance;
        this._shoppingCart = models._getShoppingCart();

        this.addItemToCart = function(item) {
            this._shoppingCart.addItem(item);
        }
    }

    models.getUser = function(username, fullName, balance) {
        return new User(username, fullName, balance);
    }
})(models);