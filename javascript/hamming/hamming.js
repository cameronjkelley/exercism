function compute(x, y) {
	if (x.length != y.length)
		throw ('DNA strands must be of equal length.');

	return x.split("").reduce(function(p, c, i) {
		return c !== y[i] ? p + 1 : p;
	}, 0);
};

module.exports = compute;
