class CollatzConjecture
  def self.steps(n)
    raise ArgumentError if n < 1
    return 0 if n == 1
    steps = 0
    until n == 1
      steps += 1
      n = n.even? ? n / 2 : n * 3 + 1;
    end
    steps
  end
end

module BookKeeping
  VERSION = 1
end
