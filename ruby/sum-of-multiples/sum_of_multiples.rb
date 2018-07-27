class SumOfMultiples
  def initialize(*factors)
    @factors = factors
  end

  def to(a)
    (0...a).find_all { |num|
      @factors.any? { |x|
        num % x == 0
      }
    }.sum
  end
end

module BookKeeping
  VERSION = 2
end
