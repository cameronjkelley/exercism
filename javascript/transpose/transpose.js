export const transpose = (input) => {
  let output = [];
  if (input.length > 0) {
    let map = input.map(x => x.split(''));
    if (map.length === 1) 
      return map[0];
      
    let longest = map.reduce((a, b) => a.length > b.length ? a : b).length;
    for (let i = 0; i < longest; i++) {
      output.push(map.reduce((a, b) => a + (b[i] === undefined ? ' ' : b[i]), ''));
    }
    output[output.length - 1] = output[output.length - 1].trimEnd();
  }
  return output;
};
