var compute = function(x, y) {
	
	var result = 0;
	
	if (x.length != y.length) {
		throw ('DNA strands must be of equal length.');
	} else {
		for (var i = 0; i < x.length; i++) {
			if (x[i] != y[i]) {
				result++;
			}
		}
	}
	return result;
};

module.exports = compute;