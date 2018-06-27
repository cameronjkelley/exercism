class Sieve
  attr_reader :primes

  def initialize(limit)
    @primes = (2..limit).to_a
    @primes.each do |x|
      (x..limit).each do |y|
        @primes.delete(x * y)
      end
    end
    @primes
  end
end

module BookKeeping
  VERSION = 1
end
