class Series
  def initialize(input)
    @input = input
  end

  def slices(n)
    raise ArgumentError if n > @input.length
    @input.chars.each_cons(n).map(&:join)
  end
end
