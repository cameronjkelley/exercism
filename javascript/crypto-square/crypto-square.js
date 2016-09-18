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
  // this.ciphertext = function() {};
};

module.exports = Crypto;
