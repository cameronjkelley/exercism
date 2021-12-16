export const flatten = (input) => input.reduce((a, b) => b === undefined || b === null ? a : a.concat(Array.isArray(b) ? flatten(b) : b), []);
