class Anagram
  def initialize(input)
    @input = input.downcase
  end

  def match(possibles)
    possibles.map { |word|
       word if word.downcase != @input && word.downcase.chars.sort == @input.chars.sort
    }.compact
  end
end

module BookKeeping
  VERSION = 2
end
