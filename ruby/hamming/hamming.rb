class Hamming
  VERSION = 1

  def self.compute(a, b)
    raise ArgumentError, "The DNA strands entered are of unequal length" unless a.size == b.size 
    (0...a.size).reduce(0) { |sum, i| a[i] != b[i] ? sum + 1 : sum }
  end
end