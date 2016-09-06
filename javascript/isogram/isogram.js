function Isogram(input) {
  this.input = input.replace(/\W/g, "").toLowerCase();
  this.isIsogram = function() {
      var output = this.input.split("").filter(function(elem, idx, self) {
        return self.indexOf(elem) === idx;
      });
      return output.length === this.input.length;
  };
};

module.exports = Isogram;
