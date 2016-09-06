var words = function (input) {
	this.count = function (input) {
		var output = {};
		var array = input.trim().toLowerCase().split(/\s+/);
		array.forEach(function (word) {
			output.hasOwnProperty(word) ? output[word]++ : output[word] = 1;
		});
		return output;
	}
};

module.exports = words;