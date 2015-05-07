var app = app || {};

/*
 * This is the model working directly with the requester and
 * handling requests to the server.
 */
app.serverManager = (function() {
    function ServerManager(requester) {
        this._requester = requester;
        this.postsRepo = {
            posts: []
        };
    }

    ServerManager.prototype.getPosts = function () {
        var defer = Q.defer();
        var _this = this;
        this.postsRepo.posts.length = 0;
        var postsCount;

        this._requester.get('classes/Post')
            .then(function (data) {
                postsCount = data.results.length;
                for (var obj in data.results) {
                    _this.getUserData(data.results[obj].authorId)
                        .then(function (userData) {
                            var currentIndex = (data.results.length - postsCount) + _this.postsRepo.posts.length; 

                            var post = new Post(data.results[currentIndex].objectId,
                                userData.objectId,
                                data.results[currentIndex].content,
                                userData.username,
                                userData.image.url,
                                data.results[currentIndex].createdAt);

                            _this.postsRepo.posts.push(post);
                            if (_this.postsRepo.posts.length === postsCount) {
                                defer.resolve(_this.postsRepo);
                            }
                        }, function(error) {
                            postsCount--;
                        });
                }
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.createPost = function (content) {
        var defer = Q.defer();

        var data = {
            'content' : content,
            'authorId' : localStorage['objectId']
        }

        this._requester.post('classes/Post', data)
            .then(function(data) {
                defer.resolve(data);
            }, function(error) {
                defer.reject(data);
            });

        return defer.promise;
    }

    ServerManager.prototype.getUserData = function(objectId) {
        var defer = Q.defer();

        this._requester.get('users/' + objectId)
            .then(function(data) {
                defer.resolve(data);
            }, function(error) {
                defer.reject(data);
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

    ServerManager.prototype.uploadImage = function (img) {
        var defer = Q.defer();

        if (img) {
            $.ajax({
                method: 'POST',
                url: 'https://api.parse.com/1/files/pic.jpg',
                headers: {
                    'X-Parse-Application-Id': 'll5X8iZMMBYMSctLgPfR91dPRJOCyjZuwCUhlLti',
                    'X-Parse-REST-API-Key': '42WRitb2YYHu5amxBNCJLmaVjh7XzKhK5jBS47JG',
                    'Content-Type': 'image/jpeg'
                },
                data: img,
                processData: false,
                success: function(data) {
                    defer.resolve(data.name);
                },
                error: function(error) {
                    defer.reject(error);
                }
            });
        } else {
            defer.resolve(null);
        }

        return defer.promise;
    }

    ServerManager.prototype.editUser = function (id, name, about, gender, img, password) {
        var defer = Q.defer();
        var _this = this;

        this.uploadImage(img)
            .then(function (imgName) {
                var data = {
                    'about': about,
                    'name': name,
                    'gender': gender,
                }

            if (imgName) {
                data['image'] = {
                    "name": imgName,
                    "__type": "File"
                }
            }

            if (password) {
                data['password'] = password;
            }

            _this._requester.put('users/' + id, data)
                .then(function (data) {
                    defer.resolve(data);
                }, function (error) {
                    defer.reject(error);
                });
        }, function(error) {
            defer.reject(error);
        });

        return defer.promise;
    }

    ServerManager.prototype.registerUser = function (username, password, name, about, gender, img) {
        var defer = Q.defer();
        var _this = this;

        this.uploadImage(img)
            .then(function (imgName) {

                var data = {
                    'username': username,
                    'password': password,
                    'about': about,
                    'name': name,
                    'gender': gender,
                    'image': {
                        "name": imgName,
                        "__type": "File"
                    }
                }

                _this._requester.post('users', data)
                    .then(function (data) {

                        defer.resolve(data);
                    }, function (error) {
                        defer.reject(error);
                    });

            }, function (err) {
                defer.reject(err);
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
