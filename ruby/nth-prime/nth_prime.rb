require 'prime'

class Prime

  def self.nth(n)
    raise ArgumentError, "Input must be positive" if n < 1
    first(n).last
  end
end