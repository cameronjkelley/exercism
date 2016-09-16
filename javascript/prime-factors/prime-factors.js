var primeFactors = {
  for: function(num) {
    var factors = [], prime = 2;
    while (num > 1) {
      while (num % prime === 0) {
        factors.push(prime);
        num /= prime;
      }
      prime++;
    }
    return factors;
  }
};

module.exports = primeFactors;
