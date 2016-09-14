function Binary(input) {
  this.toDecimal = function() {
    return input.match(/[^01]/g) ? 0 : input.split("").reverse().reduce((p, c, i) => p + c * Math.pow(2, i), 0);
  };
};

module.exports = Binary;
