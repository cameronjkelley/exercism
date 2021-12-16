export class Squares {
  constructor(n) {
    this._squares = n;
  }

  get squareOfSum() {
    if (this._squares > 0) {
      let sum = 0;
      for (let i = 1; i <= this._squares; i++) {
        sum += i;
      }
      return Math.pow(sum, 2);
    }
    return 0;
  }

  get sumOfSquares() {
    if (this._squares > 0) {
      let sum = 0;
      for (let i = 1; i <= this._squares; i++) {
        sum += Math.pow(i, 2);
      }
      return sum;
    }
    return 0;
  }

  get difference() {
    return this.squareOfSum - this.sumOfSquares;
  }
}
