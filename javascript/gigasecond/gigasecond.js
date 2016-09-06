var Gigasecond = function (date) {
	this.startDate = date;
};

Gigasecond.prototype.date = function () {
	var date = this.startDate.getTime();
	return new Date(date + 1000000000000);
};

module.exports = Gigasecond;