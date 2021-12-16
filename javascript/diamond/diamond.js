export const rows = (letter) => {
  let start = letter.charCodeAt(0),
    end ='A'.charCodeAt(0);

  let columnCount = (start - end + 1) * 2 - 1,
    rowCount = 0;
  
  let diamond = [];
  for (; columnCount > 0; columnCount -= 2) {
    let exterior = Array(rowCount).fill(' '),
      interior = Array(columnCount).fill(' ');

    interior[0] = interior[columnCount - 1] = String.fromCharCode(start - rowCount);

    let layer = exterior.concat(interior).concat(exterior).join('');

    diamond.push(layer);
    if (rowCount > 0)
      diamond.unshift(layer);

    rowCount++;
  }

   return diamond;
};