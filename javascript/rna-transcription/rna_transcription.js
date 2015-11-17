var DNA_COMPLEMENTS = { "U": "A", "C": "G", "G": "C", "A": "T"},
  	RNA_COMPLEMENTS = { "A": "U", "C": "G", "G": "C", "T": "A" },
	  DnaTranscriber = function() {};

DnaTranscriber.prototype.toRna = function(dna) {
	transcribe(dna, RNA_COMPLEMENTS);
};

DnaTranscriber.prototype.toDna = function(rna) {
	transcribe(rna, DNA_COMPLEMENTS);
};

function transcribe(strand, complement) {
	
	var bases = strand.split(""),
			keys = Object.keys(complement),
			result = "";

	for (var i = 0; i < bases.length; i++) {

		if complementbases[i]
	}

};

module.exports = DnaTranscriber;