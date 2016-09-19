var letters = "abcdefghijklmnopqrstuvwxyz";

function newKey() {
  var key = "";
  while (key.length < 101) {
    key += letters[Math.floor(Math.random() * 26)];
  }
  return key;
};

function isValid(key) {
  if (/[^a-z]/g.test(key) || key.length === 0) throw new Error("Bad key");
  return key;
};

function translate(text, key, createIdx) {
  var code = "";
  for (var i = 0; i < text.length; i++) {
    var newIdx = createIdx(letters.indexOf(text[i]), letters.indexOf(key[i]));
    if (newIdx > 25) code += letters[newIdx - 26];
    else if (newIdx < 0) code += letters[newIdx + 26];
    else code += letters[newIdx];
  }
  return code;
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
