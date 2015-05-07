var Product = (function () {
    function Product(objectId, name, category, price, editable) {
        this.id = objectId;
        this.name = name;
        this.category = category;
        this.price = price;
        this.editable = editable;
    }

    return Product;
}());