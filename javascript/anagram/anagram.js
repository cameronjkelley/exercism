function Anagram(input) {
  this.sorted = input.toLowerCase().split("").sort().join("");
  this.matches = function(words) {
    words = Array.isArray(words) ? words : Array.from(arguments);
    console.log(this.sorted);
    return words.filter(function(word) {
       return word.toLowerCase() !== input.toLowerCase() &&
              new Anagram(word).sorted === new Anagram(input).sorted;
    });
  };
};

module.exports = Anagram;
