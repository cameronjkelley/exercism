class SumOfMultiples
  def initialize(x = nil, y = nil, z = nil)
    @x = x
    @y = y
    @z = z
  end

  def to(a)
    (0...a).find_all { |num|
      (@x == nil ? false : num % @x == 0) ||
      (@y == nil ? false : num % @y == 0) ||
      (@z == nil ? false : num % @z == 0)
    }.sum
  end
end

module BookKeeping
  VERSION = 2
end
