var slides = [
    $('<li id="first">First</li>'),
    $('<li id="second">Second</li>'),
    $('<li id="third">Third</li>'),
    $('<li id="fourth">Fourth</li>')];

var counter = -1;
var slideshowTimer = setInterval(slideshow, 5000);

function slideshow() {
    counter++;
    if (counter >= slides.length) {
        counter = 0;
    }

    appendSlide(counter);
}

function slideLeft() {
    counter--;
    if (counter < 0) {
        counter = slides.length - 1;
    }

    appendSlide(counter);
    resetTimer();
}

function slideRight() {
    counter++;
    if (counter >= slides.length) {
        counter = 0;
    }

    appendSlide(counter);
    resetTimer();
}

function resetTimer() {
    clearInterval(slideshowTimer);
    slideshowTimer = setInterval(slideshow, 5000);
}

function appendSlide(index) {
    $('#container').empty();
    slides[index].appendTo('#container');
}