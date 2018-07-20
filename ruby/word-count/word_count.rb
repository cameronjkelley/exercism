class Phrase
  def initialize(phrase)
    @phrase = phrase.downcase.scan(/\w+'\w|\w+/)
  end

  def word_count
    @phrase.each_with_object(Hash.new(0)) { |word, acc| acc[word] += 1 }
  end
end

module BookKeeping
  VERSION = 1
end
