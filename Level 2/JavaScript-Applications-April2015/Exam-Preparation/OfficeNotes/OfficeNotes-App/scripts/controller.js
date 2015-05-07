var app = app || {};

app.controller = (function() {
    function Controller(model) {
        this.model = model;
    }

    Controller.prototype.getHomePage = function (selector) {
        this._loadNavigation('#menu');

        if (localStorage['sessionToken']) {
            var data = {
                'username': localStorage['username'],
                'fullName': localStorage['fullName']
            }
            
            app.userHomeView.load(selector, data);
        } else {
            app.guestHomeView.load(selector);
        }
    }

    Controller.prototype.getDeletePage = function (selector, id) {
        if (!localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You must be logged in in order to view this page.');
            return;
        }

        this._loadNavigation('#menu');
        var _this = this;

        this.model.getNote(id)
            .then(function (note) {
                app.deleteNoteView.load(selector, note)
                    .then(function () {
                        $('#deleteNoteButton').click(function () {
                            _this.model.deleteNote(id)
                                .then(function () {
                                    _this._navigateToPage('Note deleted successfully.', '#/MyNotes');
                                }, function (error) {
                                    poppy.pop('error', 'Error', error.responseText.error);
                                });
                        });
                    }, function (error) {
                        poppy.pop('error', 'Error', error.responseText.error);
                    });
            }, function (error) {
                poppy.pop('error', 'Error', error.responseText.error);
            });
    }

    Controller.prototype.getEditPage = function (selector, id) {
        if (!localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You must be logged in in order to view this page.');
            return;
        }

        this._loadNavigation('#menu');
        var _this = this;

        this.model.getNote(id)
            .then(function(note) {
                app.editNoteView.load(selector, note)
                    .then(function () {
                        $('#editNoteButton').click(function() {
                            var title = $('#title').val();
                            var text = $('#text').val();
                            var deadline = $('#deadline').val();

                            _this.model.editNote(id, title, text, deadline)
                                .then(function() {
                                    _this._navigateToPage('Note successfully edited.', '#/MyNotes');
                                }, function(error) {
                                    poppy.pop('error', 'Error', error.responseText.error);
                                });
                        });
                    }, function(error) {
                        poppy.pop('error', 'Error', error.responseText.error);
                    });
            }, function(error) {
                poppy.pop('error', 'Error', error.responseText.error);
            });
    }

    Controller.prototype.getOfficePage = function (selector, page, limit) {
        if (!localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You must be logged in in order to view this page.');
            return;
        }

        this._loadNavigation('#menu');
        var formattedDate = this._getCurrentDateFormatted();

        this.model.getNotes(null, formattedDate, (page - 1) * app.notesLimitCount, limit, 1)
            .then(function (notesRepo) {
                app.officeView.load(selector, notesRepo)
                    .then(function () {
                        $('#pagination').pagination({
                            items: notesRepo.count,
                            itemsOnPage: app.notesLimitCount,
                            cssStyle: 'light-theme',
                            hrefTextPrefix: '#/Office/'
                        }).pagination('selectPage', page);
                    });
            }, function(error) {
                poppy.pop('error', 'Error', error.responseText.error);
            });
    }

    Controller.prototype.getMyNotesPage = function (selector, page, limit) {
        if (!localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You must be logged in in order to view this page.');
            return;
        }

        var _this = this;

        this._loadNavigation('#menu');
        this.model.getNotes(localStorage['objectId'], null, (page - 1) * app.notesLimitCount, limit, 1)
            .then(function (notesRepo) {
                app.myNotesView.load(selector, notesRepo)
                    .then(function () {
                        $('.edit').click(function() {
                            var elementId = $(this).attr('data-id').split('/')[1];
                            _this._navigateToPage('', '#/Edit/' + elementId);
                        });

                        $('.delete').click(function () {
                            var elementId = $(this).attr('data-id').split('/')[1];
                            _this._navigateToPage('', '#/Delete/' + elementId);
                        });

                        $('#pagination').pagination({
                            items: notesRepo.count,
                            itemsOnPage: app.notesLimitCount,
                            cssStyle: 'light-theme',
                            hrefTextPrefix: '#/Office/'
                        }).pagination('selectPage', page);
                    }, function () {
                        _this._navigateToPage();
                        poppy.pop('error', 'Error', 'There was an error loading the page. Please try again later.');
                    });
            }, function(error) {
                poppy.pop('error', 'Error', error.responseText.error);
            });
    }

    Controller.prototype.getAddNotePage = function (selector) {
        if (!localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You must be logged in in order to view this page.');
            return;
        }

        this._loadNavigation('#menu');
        var _this = this;

        app.addNoteView.load(selector)
            .then(function () {
                $('#addNoteButton').click(function() {
                    var title = $('#title').val();
                    var text = $('#text').val();
                    var deadline = $('#deadline').val();

                    if (title.length < 4) {
                        poppy.pop('error', 'Error', 'The title\'s length must be atleast 4 characters long.');
                    } else if (text.length < 4) {
                        poppy.pop('error', 'Error', 'The text\'s length must be atleast 4 characters long.');
                    } else if (!deadline) {
                        poppy.pop('error', 'Error', 'You must select a deadline for the note.');
                    } else {
                        _this.model.addNote(title, text, deadline, localStorage['objectId'], localStorage['username'])
                            .then(function (noteData) {
                                _this._navigateToPage('The note has been added successfully', '#/MyNotes');
                            }, function (error) {
                                poppy.pop('error', 'Error', error.responseText.error);
                            });
                    }
                });
            }, function(error) {
                poppy.pop('error', 'Error', 'The was an error loading the page');
            });
    }

	/*
	 * Login Page
	 */
    Controller.prototype.getLoginPage = function (selector) {
        if (localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You are already logged in');
            return;
        }

        this._loadNavigation('#menu');
        var _this = this;

        if (!localStorage['sessionToken']) {
            app.loginView.load(selector)
                .then(function() {
                    $('#loginButton').click(function () {
						var username = $('#username').val();
						var password = $('#password').val();

						_this.model.loginUser(username, password)
							.then(function (loginData) {
							    _this._setStorageVariables(loginData.sessionToken,
                                    loginData.objectId,
                                    username,
                                    loginData.fullName);

								_this._navigateToPage('You have logged in successfully.');
							}, function() {
								poppy.pop('error', 'Error', 'There was an error logging in. Please try again.');    
							});
					});
				}, function(error) {
					poppy.pop('error', 'Error', error.responseText.error);
                });
        } else {
            this._navigateToPage();
        }
    }

	/*
	 * Register Page
	 */
    Controller.prototype.getRegisterPage = function (selector) {
        if (localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You are already logged in.');
            return;
        }

        this._loadNavigation('#menu');
        var _this = this;

        if (!localStorage['sessionToken']) {
            app.registerView.load(selector)
                .then(function() {
                    $('#registerButton').click(function () {
                        var username = $('#username').val();
                        var password = $('#password').val();
                        var fullName = $('#fullName').val();

                        if (username.length < 4) {
                            poppy.pop('error', 'Error', 'The username must be atleast 4 characters long');
                        } else if (fullName.length < 4) {
                            poppy.pop('error', 'Error', 'The full name must be atleast 4 characters long');
                        } else if (password.length < 4) {
                            poppy.pop('error', 'Error', 'The password must be atleast 4 characters long');
                        } else {
                            _this.model.registerUser(username, password, fullName)
						        .then(function (data) {
						            _this._navigateToPage("You have registered successfully. You can now login.");
						        }, function (error) {
						            poppy.pop('error', 'Error', error.responseText.error);
						        });
                        }
                    });
                });
        } else {
            this._navigateToPage();
        }
    }

	/*
	 * Logout user
	 */
    Controller.prototype.logoutUser = function () {
        if (!localStorage['sessionToken']) {
            this._navigateToPage();
            poppy.pop('error', 'Error', 'You have already logged out.');
            return;
        }
        var _this = this;

        if (localStorage['sessionToken']) {
            _this.model.logout()
                .then(function() {
                    _this._deleteStorageVariables();

                    _this._navigateToPage('You have logged out successfully');
                }, function() {
                    _this._navigateToPage();
                    poppy.pop('error', 'Error', 'There was an error logging out');
                });
        } else {
            this._navigateToPage('You have logged out already');
        }
    }

    Controller.prototype._loadNavigation = function (selector) {
        if (localStorage['sessionToken'] && !$(selector).html().trim()) {
            var data = {
                'username' : localStorage['username']
            }

            app.navigationBarView.load(selector, data)
                .then(function() {
                    $(selector).css('visibility', 'visible');
                }, function() {
                    poppy.pop('error', 'Error', 'There was an error loading the user menu');
                });
        } else if (!localStorage['sessionToken']) {
            $(selector).empty();
            $(selector).css('visibility', 'hidden');
        }
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

    Controller.prototype._setStorageVariables = function (sessionToken, objectId, username, fullName) {
        localStorage['sessionToken'] = sessionToken;
        localStorage['username'] = username;
        localStorage['objectId'] = objectId;
        localStorage['fullName'] = fullName;
        // localStorage['objectId'] = objectId;
        // localStorage["username"] = username;
        // localStorage['name'] = name;
    }

    Controller.prototype._deleteStorageVariables = function() {
        for (var key in localStorage) {
            delete localStorage[key];
        }
    }

    Controller.prototype._getCurrentDateFormatted = function() {
        var currentDate = new Date();
        var day = currentDate.getDate();
        var month = currentDate.getMonth() + 1;
        var year = currentDate.getFullYear();
        var formattedDate = ''
            + year
            + '-' + ('0' + month).slice(-2)
            + '-' + ('0' + day).slice(-2);

        return formattedDate;
    }

    return {
        load: function (model) {
            return new Controller(model);
        }
    }
}());