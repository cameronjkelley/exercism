export const triplets = ({ minFactor, maxFactor, sum }) => {
  minFactor = minFactor ?? 1;
  maxFactor = maxFactor ?? sum - minFactor;
  let trips = [];
  for (let i = minFactor; i < maxFactor; i++) {
    for (let j = i + 1; j < maxFactor; j++) {
      let k = sum - i - j;
      if (k <= maxFactor && i ** 2 + j ** 2 === k ** 2)
        trips.push(new Triplet(i, j, k));
    }
  }
  return trips;
}

class Triplet {
  constructor(a, b, c) {
    this._a = a;
    this._b = b;
    this._c = c;
  }

  toArray = () => [this._a, this._b, this._c];
}
