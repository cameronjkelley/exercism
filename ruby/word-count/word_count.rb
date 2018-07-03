class Phrase
  def initialize(phrase)
    @array = phrase.downcase.scan(/\w+'\w|\w+/).flatten
    @count = Hash.new(0)
  end

  def word_count
    @array.each do |word|
      @count[word] += 1
    end
    @count
  end
end

module BookKeeping
  VERSION = 1
end
