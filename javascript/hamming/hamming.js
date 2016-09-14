function compute(x, y) {
	if (x.length != y.length)
		throw ('DNA strands must be of equal length.');
	else
		return x.split("").reduce(function(p, _c, i) {
			return x[i] !== y[i] ? p + 1 : p + 0;
		}, 0);
};

module.exports = compute;
