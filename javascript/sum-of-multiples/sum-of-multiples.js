export const sum = (factors, limit) => {
  return [...Array(limit).keys()].filter(n => factors.some(f => n % f === 0)).reduce((a, b) => a + b, 0);
};
