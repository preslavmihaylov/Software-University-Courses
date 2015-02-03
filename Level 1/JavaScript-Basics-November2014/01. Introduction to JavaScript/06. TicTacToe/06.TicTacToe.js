window.onload = init();

var squares;

var canvas;
var ctx;
var playerTurn;

function init() {
    canvas = document.getElementById("canvas");
    ctx = canvas.getContext("2d");
    ctx.canvas.addEventListener('mousedown', mouseDown);
    playerTurn = 0;

    squares = [{ x: 0, y: 0, width: 200, height: 200, selected: false, value: "none" },
               { x: 200, y: 0, width: 200, height: 200, selected: false, value: "none" },
               { x: 400, y: 0, width: 200, height: 200, selected: false, value: "none" },
               { x: 0, y: 200, width: 200, height: 200, selected: false, value: "none" },
               { x: 200, y: 200, width: 200, height: 200, selected: false, value: "none" },
               { x: 400, y: 200, width: 200, height: 200, selected: false, value: "none" },
               { x: 0, y: 400, width: 200, height: 200, selected: false, value: "none" },
               { x: 200, y: 400, width: 200, height: 200, selected: false, value: "none" },
               { x: 400, y: 400, width: 200, height: 200, selected: false, value: "none" }
    ];

    for (var i = 0; i < squares.length; i++) {
        ctx.strokeRect(squares[i].x, squares[i].y, squares[i].width, squares[i].height);
        // ctx.fillStyle = "red";
        // ctx.font = "bold 150px Arial";
        // ctx.fillText("O", squares[i].x + squares[i].width * 0.20, squares[i].y + squares[i].height * 0.75);
    }
}

function mouseDown(event) {
    var mouseX = event.clientX - ctx.canvas.offsetLeft;
    var mouseY = event.clientY - ctx.canvas.offsetTop;

    for (var index = 0; index < squares.length; index++) {
        if (mouseX > squares[index].x && mouseX < squares[index].x + squares[index].width &&
            mouseY > squares[index].y && mouseY < squares[index].y + squares[index].height && !squares[index].selected) {
            
            squares[index].selected = true;

            ctx.font = "bold 150px Arial";
            if (playerTurn % 2 == 0) {
                squares[index].value = "O";
                ctx.fillStyle = "green";
                ctx.fillText("O", squares[index].x + squares[index].width * 0.20, squares[index].y + squares[index].height * 0.75);
            } else {
                squares[index].value = "X";
                ctx.fillStyle = "red";
                ctx.fillText("X", squares[index].x + squares[index].width * 0.20, squares[index].y + squares[index].height * 0.75);
            }

            playerTurn++;

            gameOverCheck();

            break;
            
        }
    }

}

function gameOverCheck() {
    for (var count = 0; count < 9; count+= 3) { // horizontal check
        if (squares[count].value == squares[count + 1].value && squares[count + 1].value == squares[count + 2].value &&
            squares[count].value != "none" && squares[count + 1].value != "none" && squares[count + 2].value != "none") {
            gameOver(squares[count].value);
        }
    }

    for (var count = 0; count < 3; count++) { // vertical check
        if (squares[count].value == squares[count + 3].value && squares[count + 3].value == squares[count + 6].value &&
            squares[count].value != "none" && squares[count + 3].value != "none" && squares[count + 6].value != "none") {
            gameOver(squares[count].value);
        }
    }

    // first diagonal check
    if (squares[0].value == squares[4].value && squares[4].value == squares[8].value &&
            squares[0].value != "none" && squares[4].value != "none" && squares[8].value != "none") {
        gameOver(squares[0].value);
    }

    // second diagonal check
    if (squares[2].value == squares[4].value && squares[4].value == squares[6].value &&
            squares[2].value != "none" && squares[4].value != "none" && squares[6].value != "none") {
        gameOver(squares[2].value);
    }

    // tie check
    var tied = true;
    for (var index = 0; index < squares.length; index++) {
        if (squares[index].value == "none") {
            tied = false;
            break;
        }
    }

    if (tied) {
        alert("Draw!");
    }
}

function gameOver(value) {
    alert("Player " + value + " wins");
    squares = null;
}