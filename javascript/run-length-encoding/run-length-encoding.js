export const encode = (string) => {
  return string.match(/(.)\1*/g)?.map(c => (c.length > 1 ? c.length.toString() : '') + c[0]).join('') ?? '';
};

export const decode = (string) => {
  return string.match(/\d*./g)?.map(c => c.length > 1 ? c[c.length - 1].repeat(c.substring(0, c.length - 1)) : c[0]).join('') ?? '';
};
