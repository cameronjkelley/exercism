function BeerSong() {
  this.verse = function(num) {
    switch (num) {
      case 0:
        return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n";
      case 1:
        return "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n";
      case 2:
        return "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n";
      default:
        return num + " bottles of beer on the wall, " + num + " bottles of beer.\nTake one down and pass it around, " + (num - 1) + " bottles of beer on the wall.\n";
    }
  };

  this.sing = function(start, stop) {
    if (stop === undefined) stop = 0;
    var song = "";
    for (; start >= stop; start--) {
      song += start === stop ? this.verse(start) : this.verse(start) + "\n";
    }
    return song;
  };
};

module.exports = BeerSong;
