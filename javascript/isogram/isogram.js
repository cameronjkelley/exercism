function Isogram(word) {
  var chars = word.toLowerCase().replace(/\s|-/g, "").split("");
  this.isIsogram = function() {
    return chars.filter((e, i, self) => self.indexOf(e) === i).length === chars.length;
  };
};

module.exports = Isogram;
