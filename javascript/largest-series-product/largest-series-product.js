export const largestProduct = (series, span) => {
  if (span === 0) return 1;
  else if (span < 0) throw new Error('Span must be greater than zero');
  else if (series.length < span) throw new Error('Span must be smaller than string length');
  else if (series.length === 0 && span > 0) throw new Error('Span must be smaller than string length');
  else if (!new RegExp(`\\d{${series.length}}`, 'g').test(series)) throw new Error('Digits input must only contain digits');
  else {
    let lsp = 0;
    for (let i = 0; i + span <= series.length; i++) {
      let tmp = series.substring(i, i + span).split('').reduce((a, b) => a * b, 1);
      if (tmp > lsp)
        lsp = tmp;
    }
    return lsp;
  }
};
