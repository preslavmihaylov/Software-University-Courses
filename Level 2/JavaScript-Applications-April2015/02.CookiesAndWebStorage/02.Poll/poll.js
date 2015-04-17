generateQuestions();

var correctAnswers = {
    "question1": "first",
    "question2": "second",
    "question3": "fourth",
    "question4": "third",
    "question5": "second"
}

function generateQuestions() {
    if (!localStorage['question1']) {
        generateQuestion("Are you homo?", 1);
    } else {
        $('body').append('<div id="container1">Question 1 already answered</div>');
    }

    if (!localStorage['question2']) {
        generateQuestion("No, seriously?", 2);
    } else {
        $('body').append('<div id="container2">Question 2 already answered</div>');
    }

    if (!localStorage['question3']) {
        generateQuestion("Oh wait, are you sirius?", 3);
    } else {
        $('body').append('<div id="container3">Question 3 already answered</div>');
    }

    if (!localStorage['question4']) {
        generateQuestion("Ohhhh, So you are gay...", 4);
    } else {
        $('body').append('<div id="container4">Question 4 already answered</div>');
    }

    if (!localStorage['question5']) {
        generateQuestion("... and you are fucking sirius?", 5);
    } else {
        $('body').append('<div id="container5">Question 5 already answered</div>');
    }

    if (pollIsFinished()) {
        showResult();
    }
}

function generateQuestion(questionText, number) {
    var container = $('<div id="container' + number + '"></div>');

    var question = $('<div>' + questionText + '</div>');
    var answer1 = $('<input type="radio" name="question' + number + '" value="first">');
    var text1 = $("<span>Yes</span>").append('</br>');
    var answer2 = $('<input type="radio" name="question' + number + '" value="second">');
    var text2 = $("<span>Of course</span>").append('</br>');
    var answer3 = $('<input type="radio" name="question' + number + '" value="third">');
    var text3 = $("<span>Definitely</span>").append('</br>');
    var answer4 = $('<input type="radio" name="question' + number + '" value="fourth">');
    var text4 = $("<span>Yups</span>").append('</br>');

    var submitButton = $('<button id="question' + number +
        '" onclick="javascript: submitAnswer(' + number + ')">' +
        'Submit answer</button>');

    container
        .append(question)
        .append(answer1)
        .append(text1)
        .append(answer2)
        .append(text2)
        .append(answer3)
        .append(text3)
        .append(answer4)
        .append(text4)
        .append(submitButton);

    $('body').append(container);
}

function submitAnswer(number) {
    var answer = $('input[name=question' + number + ']:checked').val();

    if (correctAnswers['question' + number] === answer) {
        localStorage["question" + number] = 'correct';
    } else {
        localStorage["question" + number] = 'incorrect';
    }

    $('#container' + number).empty().text('Question ' + number + ' already answered.');

    if (pollIsFinished()) {
        showResult();
    }
}

function pollIsFinished() {
    if (localStorage['question1'] &&
        localStorage['question2'] &&
        localStorage['question3'] &&
        localStorage['question4'] &&
        localStorage['question5']) {
        return true;
    }
}

function showResult() {
    var rightAnswers = 0;
    for (var index = 1; index <= 5; index++) {
        if (localStorage['question' + index] === 'correct') {
            rightAnswers++;
        }
    }

    $('body').append('<div>Right answers: ' + rightAnswers + '</div>');
    $('body').append('<button onclick="javascript: regeneratePoll()">Try again?</button>');
}

function regeneratePoll() {
    for (var index = 1; index <= 5; index++) {
        delete localStorage['question' + index];
    }
    location.reload();
}