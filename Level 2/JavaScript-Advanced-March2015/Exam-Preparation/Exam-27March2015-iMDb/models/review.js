var imdb = imdb || {};
if (!imdb._currentID) {
    imdb._currentID = 1;
}

(function reviewsModule(imdb) {
    'use strict';

    var Review = function (author, content, date) {
        this._id = imdb._currentID;
        imdb._currentID++;

        this.author = author;
        this.content = content;
        this.date = date;
    }

    imdb.getReview = function getReview(author, content, date) {
        return new Review(author, content, date);
    }
})(imdb);