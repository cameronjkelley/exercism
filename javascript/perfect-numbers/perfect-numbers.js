export const classify = (n) => {
  if (n < 1)
    throw new Error('Classification is only possible for natural numbers.');
  else if (n === 1)
    return 'deficient';
  else {
    let sum = [...Array(Math.floor(n/2)).keys()]
      .map((_, i, ary) => ary[i] += 1)
      .filter(x => n % x === 0)
      .reduce((a, b) => a + b);

    if (sum === n) return 'perfect';
    else if (sum > n) return 'abundant';
    else return 'deficient';
  }
};


