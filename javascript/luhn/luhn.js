function doubleThis(array) {
  var output = [array[0]];
  for (var i = 1; i < array.length; i++) {
    var x = array[i];
    if (i % 2 !== 0) {
      x *= 2
      x = x > 9 ? x - 9 : x;
    }
    output.push(x);
  }
  return output.reverse();
};

function isValid(num) {
  return num % 10 === 0;
};

function Luhn(num) {
  num = num.toString().split("").map(x => parseInt(x)).reverse();
  this.checkDigit = num[0];
  this.addends = doubleThis(num);
  this.checksum = this.addends.reduce((p, c) => p + c);
  this.valid = isValid(this.checksum);
};

Luhn.create = function(num) {
  num *= 10;
  var luhn = new Luhn(num);
  if (luhn.valid)
    return num;
  return num + (10 - (luhn.checksum % 10))
};

module.exports = Luhn;
