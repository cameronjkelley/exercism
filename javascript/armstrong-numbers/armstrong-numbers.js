export const isArmstrongNumber = (n) => {
  let s = n.toString();
  return n === s.split('').reduce((a, b) => a + b ** s.length, 0);
};
