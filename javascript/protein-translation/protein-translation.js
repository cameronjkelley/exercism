const mapping = {
  Methionine: ['AUG'],
  Phenylalanine: ['UUU', 'UUC'],
  Leucine: ['UUA', 'UUG'],
  Serine: ['UCU', 'UCC', 'UCA', 'UCG'],
  Tyrosine: ['UAU', 'UAC'],
  Cysteine: ['UGU', 'UGC'],
  Tryptophan: ['UGG'],
  STOP: ['UAA', 'UAG', 'UGA']
}

export const translate = (rna) => {
  let proteins = [];
  if (!(rna === undefined || rna.length === 0)) {
    let codons = getCodons(rna);
    for (let i = 0; i < codons.length; i++) {
      let protein = getProtein(codons[i]);
      if (!protein) throw new Error('Invalid codon');
      else if (protein === 'STOP') break;
      else proteins.push(protein);
    }
  }  
  return proteins;
};

const getCodons = (rna) => {
  return rna.match(/(.{1,3})/g);
}

const getProtein = (codon) => {
  return Object.keys(mapping).find(protein => mapping[protein].includes(codon));
}