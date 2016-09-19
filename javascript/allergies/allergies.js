var allergenScores = {
  "cats": 128,
  "pollen": 64,
  "chocolate": 32,
  "tomatoes": 16,
  "strawberries": 8,
  "shellfish": 4,
  "peanuts": 2,
  "eggs": 1
};

function Allergies(score) {
  this.list = function() {
    var list = [];
    Object.keys(allergenScores).forEach(function(key) {
      score %= 256;
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
