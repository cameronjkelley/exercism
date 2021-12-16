export class Rational {
  #gcd;

  constructor(a, b) {
    this.#gcd = this.gcd(Math.abs(a), Math.abs(b));
    this.numerator = a / this.#gcd;
    this.denominator = a === 0 ? 1 : b / this.#gcd;
    
    if (this.numerator < 0 || this.denominator < 0) {
      if (this.numerator < 0 && this.denominator < 0) {
        this.numerator = Math.abs(this.numerator);
        this.denominator = Math.abs(this.denominator);
      } else {
        this.numerator = 0 - Math.abs(this.numerator);
        this.denominator = Math.abs(this.denominator);
      }
    }
  }

  add(n) {
    return new Rational(((this.numerator * n.denominator) + (this.denominator * n.numerator)), (this.denominator * n.denominator));
  }

  sub(n) {
    return new Rational(((this.numerator * n.denominator) - (this.denominator * n.numerator)), (this.denominator * n.denominator));
  }

  mul(n) {
    return new Rational((this.numerator * n.numerator), (this.denominator * n.denominator));
  }

  div(n) {
    return this.mul(new Rational(n.denominator, n.numerator));
  }

  abs() {
    return new Rational(Math.abs(this.numerator), Math.abs(this.denominator));
  }

  exprational(n) {
    return n < 0 ? new Rational(1, 1) : new Rational(this.numerator ** n, this.denominator ** n);
  }

  expreal(n) {
    return Number(Math.pow(Math.pow(n, this.numerator), 1 / this.denominator).toFixed(2));
  }

  reduce() {
    return new Rational(this.numerator, this.denominator);
  }

  gcd(a, b) {
    if (!b) 
      return a;
    return this.gcd(b, a % b);
  }
}
