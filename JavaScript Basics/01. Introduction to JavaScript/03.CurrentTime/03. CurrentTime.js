var date = new Date();

var hours = date.getHours();

var minutes = date.getMinutes();

if (minutes < 10) {
	minutes = "0" + minutes;
};

console.log(hours + ":" + minutes);