function evalResult() {
    var expression = document.getElementById('input').value;

    var result = document.getElementById('output');
    result.innerHTML = eval(expression);
}

// I am sick of HTML/CSS bullshit s I'm not bothering styling that html file