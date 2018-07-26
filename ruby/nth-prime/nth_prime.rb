class Prime
  def self.nth(n)
    raise ArgumentError if n < 1

    primes = [2, 3]
    current = primes.last

    while n > primes.length
      current += 2
      primes << current if is_prime?(current)
    end

    primes[n - 1]
  end

  private
    def self.is_prime?(x)
      (3..Math.sqrt(x)).step(2).all? do |y|
        x % y != 0
      end
    end
end

module BookKeeping
  VERSION = 1
end
