var app = app || {};

/*
 * This is the model working directly with the requester and
 * handling requests to the server.
 */
app.serverManager = (function() {
    function ServerManager(requester) {
        this._requester = requester;
        this.productsRepo = {
            products: []
        };
        this.categoriesRepo = {
            categories: []
        };
    }

    ServerManager.prototype.getProducts = function (keyword, category, priceMin, priceMax) {
        var defer = Q.defer();
        var _this = this;
        this.productsRepo.products.length = 0;

        this._requester.get('classes/Product')
            .then(function (productData) {
                for (var index in productData.results) {
                    var productId = productData.results[index].objectId;
                    var productCategory = productData.results[index].category;
                    var name = productData.results[index].name;
                    var price = productData.results[index].price;
                    var authorId = productData.results[index].authorId;
                    var isValid = true;

                    if (keyword) {
                        if (name.toLowerCase().indexOf(keyword.toLowerCase()) < 0) {
                            isValid = false;
                        }
                    }

                    if (category) {
                        if (productCategory !== category) {
                            isValid = false;
                        }
                    }

                    if (priceMin && priceMax) {
                        if (!(price >= priceMin && price <= priceMax)) {
                            isValid = false;
                        }
                    }

                    if (isValid) {
                        var product;

                        if (authorId === localStorage['objectId']) {
                            product = new Product(productId, name, productCategory, price, true);
                        } else {
                            product = new Product(productId, name, productCategory, price, false);
                        }

                        _this.productsRepo.products.push(product);
                    }
                }

                defer.resolve(_this.productsRepo);
            }, function(error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.getProduct = function(id) {
        var defer = Q.defer();
        var _this = this;

        this._requester.get('classes/Product/' + id)
            .then(function (productData) {
                defer.resolve(productData);
            }, function(error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.editProduct = function (id, name, category, price) {
        var defer = Q.defer();

        var data = {
            'name': name,
            'category': category,
            'price' : Number(price)
        }

        this._requester.put('classes/Product/' + id, data)
            .then(function (productData) {
                defer.resolve(productData);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.deleteProduct = function (id) {
        var defer = Q.defer();

        this._requester.delete('classes/Product/' + id)
            .then(function (productData) {
                defer.resolve(productData);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.addProduct = function(name, authorId, category, price) {
        var defer = Q.defer();
        var _this = this;

        var data = {
            'name' : category
        }

        this._requester.post('classes/Category', data)
            .then(function (categoryData) {
                data = {
                    'name': name,
                    'category': category,
                    'authorId' : authorId,
                    'price' : Number(price)
                }

                _this._requester.post('classes/Product', data)
                    .then(function(productData) {
                        defer.resolve(productData);
                    }, function(error) {
                        defer.reject(error);
                    });
            }, function(error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.getCategories = function() {
        var defer = Q.defer();
        var _this = this;
        this.categoriesRepo.categories.length = 0;

        this._requester.get('classes/Category')
            .then(function (categoryData) {
                for (var index in categoryData.results) {
                    _this.categoriesRepo.categories.push(categoryData.results[index]);
                }

                defer.resolve(_this.categoriesRepo);
            }, function(error) {
                    defer.reject(error);
                });

        return defer.promise;
    }

    ServerManager.prototype.loginUser = function (username, password) {
        var defer = Q.defer();

        this._requester.get('login?username=' + username + '&password=' + password)
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.registerUser = function (username, password) {
        var defer = Q.defer();
        var _this = this;

        var data = {
            'username': username,
            'password': password
        }

        _this._requester.post('users', data)
            .then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.logout = function () {
        var defer = Q.defer();
        this._requester.post('logout').then(function (data) {
            defer.resolve(data);
        }, function (error) {
            defer.reject(error);
        });

        return defer.promise;
    }

    return {
        load: function (requester) {
            return new ServerManager(requester);
        }
    }
}());
