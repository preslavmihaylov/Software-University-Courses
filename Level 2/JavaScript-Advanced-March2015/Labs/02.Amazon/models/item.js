var models = models || {};

(function () {
    var Item = function(title, description, price) {
        this._customerReviews = [];
        this.title = title;
        this.description = description;
        this.price = price;

        this.addCustomerReview = function(customerReview) {
            this._customerReviews.push(customerReview);
        }

        this.getCustomerReviews = function() {
            return this._customerReviews;
        }
    }

    var UsedItem = function(title, description, price, condition) {
        this.extends(Item);
        Item.call(this, title, description, price);
        this.condition = condition;
    }

    models.getItem = function(title, description, price) {
        return new Item(title, description, price);
    }

    models.getUsedItem = function(title, description, price, condition) {
        return new UsedItem(title, description, price, condition);
    }

})(models);