var imdb = imdb || {};

(function extensionsModule(imdb) {

    // Task 2 - The function which is invoked from the onclick event of a li element
    imdb._loadMovieData = function loadMovieData(dataId) {
        'use strict';

        var movie,
            genres,
            genreIndex,
            movies,
            movieIndex;

        genres = imdb.getGenres();

        for (genreIndex = 0; genreIndex < genres.length; genreIndex++) {
            movies = genres[genreIndex].getMovies();

            for (movieIndex = 0; movieIndex < movies.length; movieIndex++) {
                if (movies[movieIndex]._id === dataId) {
                    movie = movies[movieIndex];
                    break;
                }
            }
        }

        if (movie) {
            imdb.generateMovieHTML(movie);
            imdb._selectedMovieDataId = dataId;
        }
    }

    // Task 3 - The function which is invoked when a given delete button is clicked
    imdb._deleteMovie = function deleteMovie(dataId) {
        'use strict';

        var genres,
            genreIndex,
            moviesUl,
            movieLi,
            index,
            movieDataId;

        genres = imdb.getGenres();

        for (genreIndex = 0; genreIndex < genres.length; genreIndex++) {
            genres[genreIndex].deleteMovieById(dataId);
        }

        moviesUl = document.querySelector('#movies').childNodes[0];

        for (index = 0; index < moviesUl.childNodes.length; index++) {
            movieDataId = parseInt(moviesUl.childNodes[index].dataset.id);

            if (movieDataId === dataId) {
                movieLi = moviesUl.childNodes[index];

                if (movieDataId === imdb._selectedMovieDataId) {
                    var details = document.getElementById('details');
                    details.innerHTML = '';
                }
            }
        }
        if (movieLi) {
            moviesUl.removeChild(movieLi);
        }
    }
})(imdb);