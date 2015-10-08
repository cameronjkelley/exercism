class Complement
  VERSION = 2
  
  DNA_COMPLEMENTS = { "U" => "A", "C" => "G", "G" => "C", "A" => "T"}
  RNA_COMPLEMENTS = { "A" => "U", "C" => "G", "G" => "C", "T" => "A" }
  
  class << self
    def of_dna(dna)
      transcribe(dna, RNA_COMPLEMENTS)
    end

    def of_rna(rna)
      transcribe(rna, DNA_COMPLEMENTS)
    end

    private

    def transcribe(strand, complement)
      result = ""
      bases = strand.split("")
      bases.each do |base|
        raise ArgumentError, "Strand contains invalid nucleotides" unless complement.has_key?(base)
        result += complement[base]
      end
      result
    end
  end
end