class Anagram
  def initialize(input)
    @input = input
  end

  def match(possibles)
    possibles.map { |word|
       word if word.downcase != @input.downcase && word.downcase.chars.sort == @input.downcase.chars.sort
    }.compact
  end
end

module BookKeeping
  VERSION = 2
end
