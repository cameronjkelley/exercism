var DNA_COMPLEMENTS = { U: "A", C: "G", G: "C", A: "T"},
    RNA_COMPLEMENTS = { A: "U", C: "G", G: "C", T: "A" };

function transcribe(strand, complement) {
	return strand.split("").map(e => complement[e]).join("");
};

function DnaTranscriber() {
  this.toRna = function(dna) {
  	return transcribe(dna, RNA_COMPLEMENTS);
  };
  this.toDna = function(rna) {
  	return transcribe(rna, DNA_COMPLEMENTS);
  };
};

module.exports = DnaTranscriber;
