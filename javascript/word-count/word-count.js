function words(input) {
	this.count = function(input) {
		var output = {};
		input.trim().toLowerCase().split(/\s+/).forEach((word) => output.hasOwnProperty(word) ? output[word]++ : output[word] = 1);
		return output;
	}
};

module.exports = words;
