var imdb = imdb || {};
if (!imdb._currentID) {
    imdb._currentID = 1;
}

(function actorsModule(imdb) {
    'use strict';

    var Actor = function (name, bio, born) {
        this._id = imdb._currentID;
        imdb._currentID++;

        this.name = name;
        this.bio = bio;
        this.born = born;
    }

    imdb.getActor = function getActor(name, bio, born) {
        return new Actor(name, bio, born);
    }
})(imdb);