function Isogram(word) {
  var chars = word.toLowerCase().replace(/\s|-/g, "").split("");
  this.isIsogram = function() {
    return chars.filter((e, _i, self) => self.indexOf(e) === self.lastIndexOf(e)).length === chars.length;
  };
};

module.exports = Isogram;
