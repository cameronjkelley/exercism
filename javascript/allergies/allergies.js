function Allergies(score) {
  var allergenScores = {
    "eggs": 1,
    "peanuts": 2,
    "shellfish": 4,
    "strawberries": 8,
    "tomatoes": 16,
    "chocolate": 32,
    "pollen": 64,
    "cats": 128
  };
  this.list = function() {
    var list = [];
    Object.keys(allergenScores).reverse().forEach(function(key) {
      if (score > 255) score -= 256;
      if (score > 0 && score / allergenScores[key] >= 1) {
        list.unshift(key);
        score -= allergenScores[key];
      }
    });
    return list;
  };
  this.allergicTo = function(allergen) {
    return score > 0 && score % allergenScores[allergen] === 0;
  };
};

module.exports = Allergies;
