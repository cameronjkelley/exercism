var letters = "abcdefghijklmnopqrstuvwxyz";

function newKey() {
  var key = "";
  while (key.length < 101) {
    key += letters[Math.floor(Math.random() * letters.length)];
  }
  return key;
};

function translate(text, key, createIdx) {
  var message = "";
  for (var i = 0; i < text.length; i++) {
    message += letters[Math.abs(createIdx(letters.indexOf(text[i]), letters.indexOf(key[i]))) % letters.length];
  };
  return message;
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
