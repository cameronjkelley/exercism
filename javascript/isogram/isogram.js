function Isogram(word) {
  this.word = word.replace(/\W/g, "").toLowerCase().split("");
  this.isIsogram = function() {
    var chars = this.word.filter((elem, idx, self) => self.indexOf(elem) === idx);
    return chars.length === this.word.length;
  };
};

module.exports = Isogram;
