var imdb = imdb || {};

(function (scope) {
    'use strict';

	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			genresUl = loadGenres(data);

		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genreId,
					genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());

				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);
			}
		});
	}

	function loadGenres(genres) {
	    var genresUl = document.createElement('ul'),
	        liGenre;

		genresUl.setAttribute('class', 'nav navbar-nav');
		genres.forEach(function (genre) {
		    liGenre = document.createElement('li');

			liGenre.innerHTML = genre.name;
			liGenre.setAttribute('data-id', genre._id);
			genresUl.appendChild(liGenre);
		});

		return genresUl;
	}

	function loadMovies(movies) {
	    var moviesUl = document.createElement('ul'),
	        liMovie,
	        aElement,
	        deleteButton;

		movies.forEach(function (movie) {
		    liMovie = document.createElement('li');

			liMovie.setAttribute('data-id', movie._id);

		    aElement = document.createElement('a');

		    aElement.innerHTML = '<h3>' + movie.title + '</h3>';
		    aElement.innerHTML += '<div>Country: ' + movie.country + '</div>';
		    aElement.innerHTML += '<div>Time: ' + movie.length + '</div>';
		    aElement.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
		    aElement.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
		    aElement.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';

            // Task 2 - The onclick function for invoking the loading of the movie data to the details container
		    aElement.setAttribute('onclick', 'javascript: imdb._loadMovieData(' + movie._id + ')');
		    aElement.style.color = 'black';
		    aElement.style.textDecoration = 'none';

            // Task 3 - The delete button created for deleting a given movie
		    deleteButton = document.createElement('button');

		    deleteButton.innerHTML = "Delete movie";
            deleteButton.setAttribute('onclick', 'javascript: imdb._deleteMovie(' + movie._id + ')');

            liMovie.appendChild(aElement);
		    liMovie.appendChild(deleteButton);

			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

    // Task 2 - The HTML Generator for the different movies
	function generateMovieHTML(movie) {
	    var detailsContainer = document.getElementById('details'),
	        actorsUl,
	        actors,
	        actorLi,
	        index,
	        reviewsUl,
            reviews,
	        reviewLi;

	    detailsContainer.innerHTML = '<h1>Actors</h1>';

	    actorsUl = document.createElement('ul');
	    actors = movie.getActors();

	    for (index = 0; index < actors.length; index++) {
	        actorLi = document.createElement('li');

	        actorLi.innerHTML += '<h3>' + actors[index].name + '</h3>';

	        actorLi.innerHTML += '<div><strong>Bio: </strong>' + actors[index].bio + '</div>';
	        actorLi.innerHTML += '<div><strong>Born: </strong>' + actors[index].born + '</div>';

	        actorsUl.appendChild(actorLi);
	    }

	    detailsContainer.appendChild(actorsUl);

	    detailsContainer.innerHTML += '<h1>Reviews</h1>';

	    reviewsUl = document.createElement('ul');
	    reviews = movie.getReviews();

	    for (index = 0; index < reviews.length; index++) {
	        reviewLi = document.createElement('li');

	        reviewLi.innerHTML += '<h3>' + reviews[index].author + '</h3>';

	        reviewLi.innerHTML += '<div><strong>Content: </strong>' + reviews[index].content + '</div>';
	        reviewLi.innerHTML += '<div><strong>Date: </strong>' + reviews[index].date + '</div>';

	        reviewsUl.appendChild(reviewLi);
	    }

	    detailsContainer.appendChild(reviewsUl);
	}

	scope.loadHtml = loadHtml;
    scope.generateMovieHTML = generateMovieHTML;
}(imdb));