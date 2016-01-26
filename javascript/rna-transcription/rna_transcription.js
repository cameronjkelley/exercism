var DNA_COMPLEMENTS = { "U": "A", "C": "G", "G": "C", "A": "T"},
  	RNA_COMPLEMENTS = { "A": "U", "C": "G", "G": "C", "T": "A" },
	DnaTranscriber = function() {};

DnaTranscriber.prototype.toRna = function(dna) {
	return transcribe(dna, RNA_COMPLEMENTS);
};

DnaTranscriber.prototype.toDna = function(rna) {
	return transcribe(rna, DNA_COMPLEMENTS);
};

function transcribe(strand, complement) {	
	var bases = strand.split(""),
		result = "";

	for(var i = 0; i < bases.length; i++) {
		for(var key in complement) {
			if(bases[i] == key) {
				result += complement[key];
			}
		}
	}
	return result;
};

module.exports = DnaTranscriber;
