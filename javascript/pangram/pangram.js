function Pangram(input) {
  var chars = input.toLowerCase().replace(/\W|\d|_/g, "").split("");
  this.isPangram = function() {
    return chars.filter((e, i, self) => self.indexOf(e) === i).length === 26;
  };
};

module.exports = Pangram;
