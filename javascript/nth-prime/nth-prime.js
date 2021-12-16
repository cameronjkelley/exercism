export const prime = (i) => {
  if (i < 1) 
    throw new Error('there is no zeroth prime');

  let list = [];
  for (let a = 2; list.length < i; a += (a == 2 ? 1 : 2)) {
    if (isPrime(a))
      list.push(a);
  }
  return list[i - 1];
};

const isPrime = (a) => {
  for (let i = 3; i <= Math.sqrt(a); i += 2) {
    if (a % i === 0)
      return false;
  }
  return true;
}
