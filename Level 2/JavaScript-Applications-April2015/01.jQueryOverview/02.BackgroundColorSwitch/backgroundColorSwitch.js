function backgroundColorSwitch() {
    var classToSwitch = $('#classToSwitch').val();
    var colorPicked = $('#colorPicker').val();

    $('.' + classToSwitch).css('background-color', colorPicked);
}