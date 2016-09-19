var letters = "abcdefghijklmnopqrstuvwxyz";

function newKey() {
  var key = "";
  while (key.length < 101) {
    key += letters[Math.floor(Math.random() * 26)];
  }
  return key;
};

function translate(text, key, createIdx) {
  var code = "";
	for (var i = 0; i < text.length; i++) {
		var newIndex = createIdx(letters.indexOf(text[i]), letters.indexOf(key[i]));
		if (newIndex > 25 || newIndex < 0) code += letters[Math.abs(newIndex % 26)];
		else code += letters[newIndex];
	}
	return code;
};

function isValid(key) {
  if (/[^a-z]/g.test(key) || key.length === 0) throw new Error("Bad key");
  return key;
};

function Cipher(key) {
  this.key = arguments.length === 0 ? newKey() : isValid(key);
  this.encode = function(text) {
    return translate(text, this.key, (x, y) => x + y);
  };
  this.decode = function(text) {
    return translate(text, this.key, (x, y) => x - y);
  };
};

module.exports = Cipher;
