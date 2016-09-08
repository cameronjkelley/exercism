function Triangle(a, b, c) {
  this.kind = function() {
    if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || b + c <= a || a + c <= b) throw new Error("Illegal");

    if (a === b && b === c) return "equilateral";
    else if ((a === b && a != c) || (a === c && a != b) || (b === c && b != a)) return "isosceles";
    else return "scalene";
  };
};

module.exports = Triangle;
