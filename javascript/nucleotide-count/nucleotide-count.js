export function countNucleotides(strand) {
  let nucleotides = { 'A': 0, 'C': 0, 'G': 0, 'T': 0 };
  if (strand.length > 0) {
    strand.split('').forEach(x => {
      if (nucleotides[x] === undefined)
        throw new Error('Invalid nucleotide in strand');
      else
        nucleotides[x]++;
    });
  }
  return Object.values(nucleotides).join(' ');
}
