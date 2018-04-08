var alphabet = "abcdefghijklmnopqrstuvwxyz";

function newKey() {
  var key = "";
  
  while (key.length < 101)
    key += alphabet[Math.floor(Math.random() * 26)];
  
  return key;
};

function isValid(key) {
  if (/[^a-z]/g.test(key) || key.length === 0)
    throw new Error("Bad key");
  
  return key;
};

function translate(text, key, createIdx) {
  var code = "";
  
  for (var i = 0; i < text.length; i++) {
    var newIdx = createIdx(alphabet.indexOf(text[i]), alphabet.indexOf(key[i]));

    if (newIdx > 25)
      code += alphabet[newIdx - 26];
    else if (newIdx < 0)
      code += alphabet[newIdx + 26];
    else
      code += alphabet[newIdx];
  }

  return code;
};

function Cipher(key) {
  this.key = arguments.length === 0 ? newKey() : isValid(key);
  this.encode = text => translate(text, this.key, (x, y) => x + y);
  this.decode = text => translate(text, this.key, (x, y) => x - y);
};

module.exports = Cipher;
