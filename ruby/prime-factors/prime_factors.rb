class PrimeFactors
  def self.for(n)
    primes = []
    i = 2
    while n > 1 do
      while n % i == 0 do
        primes << i
        n /= i
      end
      i += 1
    end
    primes
  end
end
