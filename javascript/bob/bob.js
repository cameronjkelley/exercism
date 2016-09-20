function asking(input) {
	return input.slice(-1) === "?";
};

function telling(input) {
	return input.trim().length > 0;
};

function yelling(input) {
	return input.toUpperCase() === input && input.toLowerCase() !== input;
};

function Bob() {
	this.hey = function(input) {
		if (yelling(input)) return "Whoa, chill out!";
		else if (asking(input)) return "Sure.";
		else if (telling(input)) return "Whatever.";
		else return "Fine. Be that way!";
	};
};

module.exports = Bob;
