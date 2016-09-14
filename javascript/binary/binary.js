function Binary(input) {
  this.toDecimal = function() {
    var array = input.split("");
    var output = 0, i = 0;
    for (var pow = array.length - 1; pow >= 0; pow--) {
      if (array[i] === "0" || array[i] === "1")
        output += array[i] * Math.pow(2, pow);
      else
        return 0;
      i++;
    }
    return output;
  }
};

module.exports = Binary;
