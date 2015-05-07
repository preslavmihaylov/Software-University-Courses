var app = app || {};

/*
 * This is the model working directly with the requester and
 * handling requests to the server.
 */
app.serverManager = (function() {
    function ServerManager(requester) {
        this._requester = requester;
        this._notesRepo = {
            notes: [],
            count: 0
        }
    }

    ServerManager.prototype.getNotes = function(id, deadline, skip, limit, count) {
        var defer = Q.defer();
        var _this = this;
        this._notesRepo.notes.length = 0;

        var whereParameter = '';
        if (id) {
            whereParameter = '?where={"authorId":"' + id + '"}';
        } else {
            whereParameter = '?where={"deadline":"' + deadline + '"}';
        }

        if (skip) {
            whereParameter += '&skip=' + skip;
        }

        if (limit) {
            whereParameter += '&limit=' + limit;
        }

        if (count) {
            whereParameter += '&count=' + count;
        }

        this._requester.get('classes/Note' + whereParameter)
            .then(function(noteData) {
                for (var noteIndex in noteData.results) {
                    var id = noteData.results[noteIndex].objectId;
                    var title = noteData.results[noteIndex].title;
                    var content = noteData.results[noteIndex].content;
                    var deadline = noteData.results[noteIndex].deadline;
                    var author = noteData.results[noteIndex].author;

                    var note = new Note(id, title, content, deadline, author);

                    _this._notesRepo.notes.push(note);
                }

                _this._notesRepo.count = noteData.count;
                defer.resolve(_this._notesRepo);
            }, function(error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.deleteNote = function (id) {
        var defer = Q.defer();

        this._requester.delete('classes/Note/' + id)
            .then(function (noteData) {
                defer.resolve(noteData);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.editNote = function (id, title, content, deadline) {
        var defer = Q.defer();

        var data = {
            'title': title,
            'content': content,
            'deadline' : deadline
        }

        this._requester.put('classes/Note/' + id, data)
            .then(function (noteData) {
                defer.resolve(noteData);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.getNote = function (id) {
        var defer = Q.defer();

        this._requester.get('classes/Note/' + id)
            .then(function (noteData) {
                var id = noteData.objectId;
                var title = noteData.title;
                var content = noteData.content;
                var deadline = noteData.deadline;
                var author = noteData.author;

                var note = new Note(id, title, content, deadline, author);

                defer.resolve(note);
            }, function (error) {
                defer.reject(error);
            });

        return defer.promise;
    }

    ServerManager.prototype.addNote = function (title, content, deadline, authorId, author) {
        var defer = Q.defer();


        var data = {
            'title': title,
            'content': content,
            'deadline': deadline,
            'authorId': authorId,
            'author': author,
            "ACL": {
                "*" : { "read": true }
            }
        }

        data.ACL[authorId] = { "write": true, "read": true };

        this._requester.post('classes/Note', data)
            .then(function (categoryData) {
                defer.resolve(categoryData);
            }, function (error) {
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

    ServerManager.prototype.registerUser = function (username, password, fullName) {
        var defer = Q.defer();
        var _this = this;

        var data = {
            'username': username,
            'password': password,
            'fullName' : fullName
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
