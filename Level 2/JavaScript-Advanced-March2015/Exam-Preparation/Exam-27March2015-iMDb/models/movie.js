var imdb = imdb || {};
if (!imdb._currentID) {
    imdb._currentID = 1;
}

(function moviesModule(imdb) {
    'use strict';

    var Movie = function(title, length, rating, country) {
        this._id = imdb._currentID;
        imdb._currentID++;

        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];

        this.addActor = function addActor(actor) {
            this._actors.push(actor);
        }

        this.getActors = function getActors() {
            return this._actors;
        }

        this.addReview = function addReview(review) {
            this._reviews.push(review);
        }

        this.deleteReview = function deleteReview(review) {
            var reviewIndex = this._reviews.indexOf(review);
            this._reviews.splice(reviewIndex, 1);
        }

        this.deleteReviewById = function deleteReviewById(id) {
            var index;

            for (index = 0; index < this._reviews.length; index++) {
                if (this._reviews[index]._id === id) {
                    this._reviews.splice(index, 1);
                    return;
                }
            }
        }

        this.getReviews = function getReviews() {
            return this._reviews;
        }
    }

    imdb.getMovie = function getMovie(title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }
})(imdb);