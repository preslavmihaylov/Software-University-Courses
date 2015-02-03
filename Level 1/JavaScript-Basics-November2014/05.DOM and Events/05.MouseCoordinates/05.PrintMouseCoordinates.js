document.onmousemove = function (e) { mouseMoved(e); };

function mouseMoved(event) {
    var x = event.clientX;
    var y = event.clientY;
    var time = new Date();

    document.getElementById('x').innerText = x;
    document.getElementById('y').innerText = y;
    document.getElementById('time').innerText = time;

}