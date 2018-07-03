class Phrase
  attr_reader :word_count

  def initialize(phrase)
    @word_count = Hash.new(0)
    array = phrase.downcase.scan(/\w+'\w|\w+/).flatten
    array.each do |word|
      @word_count[word] += 1
    end
  end
end

module BookKeeping
  VERSION = 1
end
