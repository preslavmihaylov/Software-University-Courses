var rocks;
var player;
var canvas = document.getElementById("canvas");
var ctx = canvas.getContext('2d');
var gameRunning = true;
var playerImg = new Image();
var rocksImg = new Image();

window.onload = init();
window.addEventListener("keydown", doKeyDown, true);

function init() {
    rocks = [];

    playerImg.src = "derp.png";
    rocksImg.src = "rock.png";
    player = {  x: 230, y: 460, width: 40, height: 40 };

	mainLoop();
}

function mainLoop() {
    if (ctx != null) {
        ctx.clearRect(0, 0, 500, 500);
        generateRocks();
        moveRocks();
        draw();
        outOfBoundsCheck();
        collisionCheck();
    }

    if (gameRunning) {
        var loop = setTimeout('mainLoop()', 25);
    } else {
        ctx.clearRect(0, 0, 500, 500);
    }
	
}

function newRock(x, y, width, height, array) {
    array.push({x: x, y: y, width: width, height: height});
}

function generateRocks() {
	var chance = Math.floor((Math.random() * 100) + 1);

	if (chance < 5) {
	    var x = Math.floor((Math.random() * 450) + 1);
	    var y = Math.floor((Math.random() * 50) - 100);
	    var width = Math.floor((Math.random() * 25) + 25);
	    var height = Math.floor((Math.random() * 25) + 25);
        
	    var currentRock = {x: x, y: y, width: width, height: height};

	    for (var rock = 0; rock < rocks.length; rock++) {
	        if (rockIntersection(currentRock, rocks[rock])) {
	            return;
	        }
	    }

		newRock(x, y, width, height, rocks);
	}
}

function moveRocks() {
	for (var i = 0; i < rocks.length; i++) {
		rocks[i].y += 2;
	}
}

function draw() {
    ctx.save();
    for (var i = 0; i < rocks.length; i++) {
        ctx.fillStyle = "rgba(0, 200, 0, 1)";
        ctx.drawImage(rocksImg, rocks[i].x, rocks[i].y, rocks[i].width, rocks[i].height);
    }

    ctx.fillStyle = "rgba(6, 6, 6, 1)";
    ctx.drawImage(playerImg, player.x, player.y, player.width, player.height);
    ctx.restore();
}

function outOfBoundsCheck() {
    for (var i = 0; i < rocks.length; i++) {
        
        if (rocks[i].y > 500) {
            rocks.splice(i, 1);
        }
    }
}

function rockIntersection(object, rock) {
    if (object.x < rock.x + rock.width && object.x + object.width > rock.x &&
        object.y < rock.y + rock.height && object.y + object.height > rock.y) {
        return true;
    } else {
        return false;
    }
}

function collisionCheck() {
    for (var rock = 0; rock < rocks.length; rock++) {
        if (rockIntersection(player, rocks[rock]) && rocks[rock].y < 480) {
            gameRunning = false;
            alert("Game Over");
        }
    }
}

function doKeyDown(e) {

    if (e.keyCode == 37) { // left
        player.x -= 5;
    }

    if (e.keyCode == 39) { // right
        player.x += 5;
    }
}


/* function storeCoordinate(xVal, yVal, array) {
    array.push({x: xVal, y: yVal});
}

var coords = [];
storeCoordinate(3, 5, coords);
storeCoordinate(19, 1000, coords);
storeCoordinate(-300, 4578, coords);

coords[0].x == 3   // x value
coords[0].y == 5   // y value

// to loop through coordinate values
for (var i = 0; i < coords.length; i++) {
    var x = coords[i].x;
    var y = coords[i].y;
} */



