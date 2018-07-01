class Prime
  def self.nth(n)
    raise ArgumentError if n < 1

    primes = [2, 3]
    current = 3

    while n > primes.length
      current += 2
       if self.is_prime?(current)
         primes << current
       end
    end

    primes[n - 1]
  end

  def self.is_prime?(x)
    range = 3..Math.sqrt(x)
    range.step(2) do |y|
      return false if x % y === 0
    end

    true
  end
end

module BookKeeping
  VERSION = 1
end
