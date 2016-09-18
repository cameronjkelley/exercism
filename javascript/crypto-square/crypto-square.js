function Crypto(text) {
  this.normalizePlaintext = function() {
    return text.toLowerCase().replace(/\W/g, "");
  };
  this.size = function() {
    return Math.ceil(Math.sqrt(this.normalizePlaintext().length));
  };
  this.plaintextSegments = function() {
    return this.normalizePlaintext().match(new RegExp(".{1," + this.size() + "}", "g"));
  };
  this.ciphertext = function() {
    var text = this.plaintextSegments();
    var output = "";
    for (var i = 0; i < text[0].length; i++) {
      for (var j = 0; j < text.length; j++) {
        if (i < text[j].length)
          output += text[j][i];
      }
    }
    return output;
  };
};

module.exports = Crypto;
