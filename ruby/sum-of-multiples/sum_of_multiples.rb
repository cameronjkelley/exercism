class SumOfMultiples
  def initialize(*multiples)
    @multiples = multiples
  end

  def to(a)
    (0...a).find_all { |num|
      @multiples.any? { |x|
        num % x == 0
      }
    }.sum
  end
end

module BookKeeping
  VERSION = 2
end
