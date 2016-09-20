var HelloWorld = function() {};

HelloWorld.prototype.hello = function(input) {
	return !input ? "Hello, world!" : "Hello, " + input + "!";
};

module.exports = HelloWorld;
