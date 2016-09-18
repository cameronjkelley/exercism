function Pangram(input) {
  this.input = input.replace(/\W|\d|_/g, "").toLowerCase().split("");
  this.isPangram = function() {
    var output = [];
    this.input.forEach((char) => if (output.indexOf(char) === -1) output.push(char));
    return output.length === 26;
  };
};

module.exports = Pangram;
