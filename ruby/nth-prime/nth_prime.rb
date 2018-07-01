class Prime
  def self.nth(n)
    raise ArgumentError if n < 1

    primes = [2, 3]
    num = 3

    while n > primes.length
      num += 2
       if self.is_prime?(num)
         primes.push(num)
       end
    end

    primes[n - 1]
  end

  def self.is_prime?(x)
    for i in 3..Math.sqrt(x)
      return false if x % i === 0
      i += 2
    end
    true
  end
end

module BookKeeping
  VERSION = 1
end
