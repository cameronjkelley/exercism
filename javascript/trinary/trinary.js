function Trinary(num) {
  this.toDecimal = function() {
    return num.match(/[^012]/g) ? 0 : num.split("").reverse().reduce((p, e, i) => p + e * Math.pow(3, i), 0);
  };
};

module.exports = Trinary;
