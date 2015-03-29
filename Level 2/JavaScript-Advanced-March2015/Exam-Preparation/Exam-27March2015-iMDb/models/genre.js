var imdb = imdb || {};
if (!imdb._currentID) {
    imdb._currentID = 1;
}

(function genreModule(imdb) {
    'use strict';

    var Genre = function(name) {
        this._id = imdb._currentID;
        imdb._currentID++;

        this.name = name;
        this._movies = [];

        this.addMovie = function addMovie(movie) {
            this._movies.push(movie);
        }

        this.deleteMovie = function deleteMovie(movie) {
            var elementIndex = this._movies.indexOf(movie);
            if (elementIndex >= 0) {
                this._movies.splice(elementIndex, 1);
            }
        }

        this.deleteMovieById = function deleteMovieById(id) {
            var index;

            for (index = 0; index < this._movies.length; index++) {
                if (this._movies[index]._id === id) {
                    this._movies.splice(index, 1);
                    return;
                }
            }
        }

        this.getMovies = function getMovies() {
            return this._movies;
        }
    }

    imdb.getGenre = function getGenre(name) {
        return new Genre(name);
    }
})(imdb);