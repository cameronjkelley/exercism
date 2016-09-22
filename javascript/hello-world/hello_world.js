var HelloWorld = function() {};

HelloWorld.prototype.hello = function(input) {
	return `Hello, ${input || "World"}!`;
};

module.exports = HelloWorld;
