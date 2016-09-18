function Pangram(input) {
  this.input = input.replace(/\W|\d|_/g, "").toLowerCase().split("");
  this.isPangram = function() {
    var output = [];
    this.input.forEach((elem) => if (output.indexOf(elem) === -1) output.push(elem));
    return output.length === 26;
  };
};

module.exports = Pangram;
