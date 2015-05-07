var app = app || {};

app.controller = (function() {
    function Controller(model) {
        this.model = model;
    }

    Controller.prototype.getHomePage = function (selector) {
        this._loadNavigation('#menu');

        if (!localStorage['sessionToken']) {
            app.guestWelcomeView.load(selector);
        } else {
            var data = {
                'username' : localStorage['username']
            }
            app.userWelcomeView.load(selector, data);
        }
    }

    Controller.prototype.getEditProductPage = function (selector, id) {
        this._loadNavigation('#menu');
        var _this = this;

        this.model.getProduct(id)
            .then(function(productData) {
                app.editProductView.load(selector, productData)
                    .then(function () {
                        $('#edit-product-button').click(function () {
                            var name = $('#item-name').val();
                            var category = $('#category').val();
                            var price = $('#price').val();

                            if (Number(price) < 0) {
                                poppy.pop('error', 'Error', 'Invalid price');
                            } else if (name.length < 4 || category.length < 4) {
                                poppy.pop('error',
                                    'Error',
                                    'The name and category cannote be less than 4 characters long.');
                            } else {
                                _this.model.editProduct(id, name, category, price)
                                    .then(function (successData) {
                                        _this._navigateToPage('Product edited successfully', '#/Products');
                                    }, function(error) {
                                        poppy.pop('error', 'Error', error.responseText.error);
                                    });
                            }
                        });
                    }, function (error) {
                        poppy.pop('error', 'Error', 'An error occured while trying to load the page.');
                    });
            }, function(error) {
                poppy.pop('error', 'Error', error.responseText.error);
            });
    }

    Controller.prototype.getDeleteProductPage = function (selector, id) {
        this._loadNavigation('#menu');
        var _this = this;

        this.model.getProduct(id)
            .then(function (productData) {
                app.deleteProductView.load(selector, productData)
                    .then(function () {
                        $('#delete-product-button').click(function() {
                            _this.model.deleteProduct(id).then(function() {
                                _this._navigateToPage('The product has been deleted successfully', '#/Products');
                            }, function(error) {
                                poppy.pop('error', 'Error', error.responseText.error);
                            });
                        });
                    }, function (error) {
                        poppy.pop('error', 'Error', 'An error occured while trying to load the page.');
                    });
            }, function (error) {
                poppy.pop('error', 'Error', error.responseText.error);
            });
    }

    Controller.prototype.getProductsPage = function (selector) {
        this._loadNavigation('#menu');
        var _this = this;

        this.model.getProducts().then(function (productsRepo) {
            var categoriesRepo = _this._getCategoriesRepo(productsRepo);

            app.filterBoxView.load(selector, categoriesRepo).then(function () {
                app.productsView.load('.products', productsRepo);
                $('.filter-button').click(function () {
                    var keyword = $('#search-bar').val();
                    var minPrice = Number($('#min-price').val());
                    var maxPrice = Number($('#max-price').val());
                    var category = $('#category').find(":selected").val();

                    _this.model.getProducts(keyword, category, minPrice, maxPrice).then(function(products) {
                        app.productsView.load('.products', products);
                    });
                });

                $('#clear-filters').click(function() {
                    $('#search-bar').val('');
                    $('#min-price').val('0');
                    $('#max-price').val('10000');
                    $('#category').val('');
                });
            });
        }, function(error) {
            poppy.pop('error', 'Error', error.responseText.error);
        });
    }

    Controller.prototype.getAddProductPage = function(selector) {
        this._loadNavigation('#menu');
        var _this = this;

        if (localStorage['sessionToken']) {
            app.addProductView.load(selector)
                .then(function (data) {
                    $('#add-product-button').click(function() {
                        var name = $('#name').val();
                        var category = $('#category').val();
                        var price = $('#price').val();
                        if (Number(price) < 0) {
                            poppy.pop('error', 'Error', 'Invalid price');
                        } else if (name.length < 4 || category.length < 4) {
                            poppy.pop('error',
                                'Error',
                                'The name and category cannote be less than 4 characters long.');
                        } else {
                            _this.model.addProduct(name, localStorage['objectId'], category, price)
                                .then(function() {
                                    _this._navigateToPage('The product has been created successfully', '#/Products');
                                }, function(error) {
                                    poppy.pop('error',
                                        'Error',
                                        'An error occured while trying to create the product on the server. ' +
                                        'Please try again later.');
                                });
                        }
                    });
                }, function(error) {
                
                });
        } else {
            this._navigateToPage();
        }
    }

    Controller.prototype.getLoginPage = function (selector) {
        this._loadNavigation('#menu');
        var _this = this;

        if (!localStorage['sessionToken']) {
            app.loginView.load(selector)
                .then(function(data) {
                $('#login-button').click(function() {
                    var username = $('#username').val();
                    var password = $('#password').val();

                    _this.model.loginUser(username, password)
                        .then(function (loginData) {
                            _this._setStorageVariables(loginData.sessionToken, username, loginData.objectId);
                            _this._navigateToPage('You have logged in successfully.');
                        }, function(error) {
                            poppy.pop('error', 'Error', 'There was an error logging in. Please try again.');    
                        });
                });
            }, function(error) {

                });
        } else {
            this._navigateToPage();
        }
    }

    Controller.prototype.getRegisterPage = function (selector) {
        this._loadNavigation('#menu');
        var _this = this;

        if (!localStorage['sessionToken']) {
            app.registerView.load(selector)
                .then(function(data) {
                $('#register-button').click(function() {
                    var username = $('#username').val();
                    var password = $('#password').val();
                    var repeatPassword = $('#confirm-password').val();
                    if (username.length < 4) {
                        poppy.pop('error', 'Error', 'The username cannot be less than 4 characters long.');
                    } else if (password.length < 4) {
                        poppy.pop('error', 'Error', 'The password cannot be less than 4 characters long.');
                    } else {
                        if (password === repeatPassword) {
                            _this.model.registerUser(username, password)
                                .then(function (data) {
                                    _this._navigateToPage("You have registered successfully. You can now login.");
                                }, function (error) {
                                    poppy.pop('error', 'Error', error.responseText.error);
                                });
                        } else {
                            poppy.pop('error', 'Error', 'The passwords do not match.');
                        }
                    }
                });
            });
        } else {
            this._navigateToPage();
        }
    }

    Controller.prototype.logoutUser = function () {
        var _this = this;

        if (localStorage['sessionToken']) {
            _this.model.logout()
                .then(function(data) {
                    _this._deleteStorageVariables();

                    _this._navigateToPage('You have logged out successfully');
                }, function(error) {
                    _this._navigateToPage();
                    poppy.pop('error', 'Error', 'There was an error logging out');
                });
        } else {
            this._navigateToPage('You have logged out already');
        }
    }

    Controller.prototype._getCategoriesRepo = function(productsRepo) {
        var categoriesRepo = {
            categories: []
        }

        for (var index in productsRepo.products) {
            var currentCategory = productsRepo.products[index];
            if (categoriesRepo.categories.indexOf(currentCategory) < 0) {
                categoriesRepo.categories.push(currentCategory);
            }
        }

        return categoriesRepo;
    }

    Controller.prototype._navigateToPage = function(message, page) {
        var splitted = window.location.href.split('#');
        if (page) {
            window.location.replace(splitted[0] + '' + page);
        } else {
            window.location.replace(splitted[0] + '#/');
        }

        if (message) {
            poppy.pop('success', 'Success', message);
        }
    }

    Controller.prototype._setStorageVariables = function (sessionToken, username, objectId) {
        localStorage['sessionToken'] = sessionToken;
        localStorage['username'] = username;
        localStorage['objectId'] = objectId;
        // localStorage['objectId'] = objectId;
        // localStorage["username"] = username;
        // localStorage['name'] = name;
    }

    Controller.prototype._deleteStorageVariables = function() {
        for (var key in localStorage) {
            delete localStorage[key];
        }
    }

    Controller.prototype._loadNavigation = function (selector) {
        $(selector).empty();
        if (localStorage['sessionToken']) {
            app.userMenuView.load(selector)
                .then(function (data) {

                }, function (error) {
                    poppy.pop('error', 'Error', 'There was an error loading the user menu');
                });
        } else {
            app.guestMenuView.load(selector)
                .then(function (data) {

                }, function (error) {
                    poppy.pop('error', 'Error', 'There was an error loading the guest menu');
                });
        }
    }

    return {
        load: function (model) {
            return new Controller(model);
        }
    }
}());