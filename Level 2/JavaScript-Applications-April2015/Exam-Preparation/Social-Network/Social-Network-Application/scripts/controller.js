var app = app || {};

app.controller = (function() {
    function Controller(model) {
        this.model = model;
    }

    Controller.prototype.getEditProfilePage = function (selector) {
        this._loadHeader('#header');
        var _this = this;
        sessionStorage["pictureHasChanged"] = false;

        this.model.getUserData(localStorage['objectId'])
            .then(function (userData) {
                app.editProfileView.load(selector, userData)
                    .then(function () {
                        $('#editProfileButton').click(function() {
                            var password = $('#password').val();
                            var name = $('#name').val();
                            var about = $('#about').val();
                            var gender = $("input[type='radio'][name='gender-radio']:checked").val();

                            if (sessionStorage["pictureHasChanged"]) {
                                var image = $('#picture')[0].files[0];
                            } else {
                                image = null;
                            }

                            if (!password) {
                                password = null;
                            }

                            _this.model.editUser(localStorage['objectId'], name, about, gender, image, password)
                                .then(function (successData) {
                                    var imageUrl;

                                    if (!successData.image) {
                                        imageUrl = localStorage['imageUrl'];
                                    } else {
                                        imageUrl = successData.image.url;
                                    }

                                    _this._setStorageVariables(localStorage['objectId'],
                                        localStorage['logged-in'],
                                        localStorage['username'],
                                        name,
                                        imageUrl);

                                    var splitted = window.location.href.split('#');
                                    window.location.replace(splitted[0] + '#/');
                                    poppy.pop('success', 'Success', 'You have edited your profile successfully');
                                }, function(error) {
                                    poppy.pop('error', 'Error', error.responseText);
                                });
                        });
                }, function(error) {
                        poppy.pop('error', 'Error', error.responseText);
                    });
            }, function(error) {
                poppy.pop('error', 'Error', error.responseText);
            });
    }

    Controller.prototype.createPost = function () {
        var content = $('#post-content').val();
        this.model.createPost(content).then(function (data) {
            poppy.pop('success', 'Success', 'The post has been created successfully');

            var splitted = window.location.href.split('#');
            window.location.replace(splitted[0] + '#/');
        }, function (error) {
            poppy.pop(error.responseText);
        });
    }

    Controller.prototype.showPostBox = function (selector) {
        app.postBoxView.load(selector);
    }

    Controller.prototype.getHomePage = function (selector) {
        this._loadHeader('#header');

        if (!localStorage['logged-in']) {
            app.guestView.load(selector);
        } else {
            var _this = this;

            this.model.getPosts()
                .then(function (data) {
                    app.postsView.load(selector, data)
                        .then(function () {
                            _this._setHoverBoxEventHandlers();
                    });
                }, function (error) {
                    poppy.pop('error', 'Error', error.responseText);
                });
        }
    }

    Controller.prototype.getLoginPage = function (selector) {
        var _this = this;

        if (!localStorage['logged-in']) {
            app.loginView.load(selector)
            .then(function (data) {
                $('#loginButton').click(function () {
                    var username = $('#login-username').val();
                    var password = $('#login-password').val();

                    _this.model.loginUser(username, password)
                        .then(function (userData) {
                            _this._setStorageVariables(userData.objectId,
                                        userData.sessionToken,
                                        userData.username,
                                        userData.name,
                                        userData.image.url);

                            var splitted = window.location.href.split('#');
                            window.location.replace(splitted[0] + '#/');
                            poppy.pop('success', 'Success', 'You have logged in successfully');

                        }, function (error) {
                            poppy.pop('error', 'Error', 'Invalid username or password');
                        });
                });
            }, function (error) {

            });
        }
    }

    Controller.prototype.getRegisterPage = function (selector) {
        var _this = this;

        if (!localStorage['logged-in']) {
            app.registerView.load(selector)
                .then(function (data) {
                    $('#registerButton').click(function () {
                        var username = $('#reg-username').val();
                        var password = $('#reg-password').val();
                        var name = $('#reg-name').val();
                        var about = $('#reg-about').val();
                        var gender = $("input[type='radio'][name='gender-radio']:checked").val();
                        var image = $('#picture')[0].files[0];

                        _this.model.registerUser(username, password, name, about, gender, image)
                            .then(function (sessionData) {
                                _this.model.getUserData(sessionData.objectId).then(function (userData) {
                                    _this._setStorageVariables(userData.objectId,
                                        sessionData.sessionToken,
                                        userData.username,
                                        userData.name,
                                        userData.image.url);

                                    var splitted = window.location.href.split('#');
                                    window.location.replace(splitted[0] + '#/');
                                    poppy.pop('success', 'Success', 'You have registered successfully');
                                }, function(error) {
                                    poppy.pop(error.responseText);
                                });

                            }, function (error) {
                                poppy.pop(error.responseText);
                            });
                    });
                });
        }
    }

    Controller.prototype.logoutUser = function () {
        var _this = this;

        if (localStorage['logged-in']) {
            _this.model.logout()
                .then(function (data) {
                    _this._deleteStorageVariables();
                        
                    var splitted = window.location.href.split('#');
                    window.location.replace(splitted[0] + '#/');
                    poppy.pop('success', 'Success', 'You have logged out successfully');
                }, function (error) {
                    poppy.pop('success', 'Error', 'There was an error logging out');
                });
        }
    }

    Controller.prototype._setHoverBoxEventHandlers = function () {
        var _this = this;

        $('.profile-link').mouseenter(function (event) {
            var x = event.clientX;
            var y = event.clientY;
            var authorId = event.target.id;
        
            $('.hover-box')
                .css('position', 'absolute')
                .css('visibility', 'visible')
                .css('top', y + 10)
                .css('left', x + 10)
                .html('Loading...');
        
            _this.model.getUserData(authorId)
                .then(function (data) {
                    app.hoverBoxView.load('.hover-box', data)
                        .then(function () {
                            $(".hover-box").css('visibility', 'visible');
                        });
                }, function (error) {
                    poppy.pop('error', 'Error', error.responseText.error);
                });
        });
        
        $('.profile-link').mouseleave(function () {
            $('.hover-box').empty().css('visibility', 'hidden');
        });
    }

    Controller.prototype._setStorageVariables = function(objectId, sessionToken, username, name, imageUrl) {
        localStorage['objectId'] = objectId;
        localStorage["logged-in"] = sessionToken;
        localStorage["username"] = username;
        localStorage['name'] = name;
        localStorage['imageUrl'] = imageUrl;
    }

    Controller.prototype._deleteStorageVariables = function() {
        delete localStorage['objectId'];
        delete localStorage["logged-in"];
        delete localStorage["username"];
        delete localStorage['name'];
        delete localStorage['imageUrl'];
    }

    Controller.prototype._loadHeader = function (selector) {
        if (localStorage['logged-in']) {
            app.userHeaderView.load(selector)
                .then(function (data) {
                    $('#userProfileImage').html('<img class="thumbnail" src="' + localStorage['imageUrl'] + '" />');
                    $('#userSummary').html('<h2>Hello, ' + localStorage['name'] + '</h2>');
                    $('#usernamePreview').html('<u>' + localStorage['username'] + '</u>');
                }, function (error) {
                    // User header error
                });
        } else {
            $(selector).empty();
        }
    }

    return {
        load: function (model) {
            return new Controller(model);
        }
    }
}());