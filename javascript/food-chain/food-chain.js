function FoodChain() {
  var animals = {
        1: "fly", 2: "spider", 3: "bird", 4: "cat", 5: "dog", 6: "goat", 7: "cow", 8: "horse"
      },
      refrains = {
        1: "I don\'t know why she swallowed the fly. Perhaps she\'ll die.",
        2: "It wriggled and jiggled and tickled inside her.",
        3: "How absurd to swallow a bird!",
        4: "Imagine that, to swallow a cat!",
        5: "What a hog, to swallow a dog!",
        6: "Just opened her throat and swallowed a goat!",
        7: "I don\'t know how she swallowed a cow!",
        8: "She\'s dead, of course!"
      };

  this.verse = function(num) {
    var song = "I know an old lady who swallowed a " + animals[num] + ".\n";
    song += refrains[num] + "\n";
    if (num === 8) return song;
    for (var i = num; i > 1; i--) {
      if (i === 3) song += "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n";
      else song += "She swallowed the " + animals[i] + " to catch the " + animals[i - 1] + ".\n";
    }
    if (num > 1) song += refrains[1] + "\n";
    return song;
  };
  this.verses = function(begin, end) {
    var song = "";
    for (; begin <= end; begin++) {
      song += this.verse(begin) + "\n";
    }
    return song;
  };
}

module.exports = FoodChain;
