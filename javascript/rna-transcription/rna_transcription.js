var RNA_COMPLEMENTS = { A: "U", C: "G", G: "C", T: "A" },
    DNA_COMPLEMENTS = { U: "A", C: "G", G: "C", A: "T"};

function transcribe(strand, complement) {
	return strand.split("").map(e => complement[e]).join("");
};

function DnaTranscriber() {
  this.toRna = dna => transcribe(dna, RNA_COMPLEMENTS);
  this.toDna = rna => transcribe(rna, DNA_COMPLEMENTS);
};

module.exports = DnaTranscriber;
