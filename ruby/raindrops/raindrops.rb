class Raindrops

  RAINDROPS = { "Pling" => 3, "Plang" => 5, "Plong" => 7 }

  def self.convert(num)
    result = RAINDROPS.select { |_key, value| num % value == 0 }.keys.join
    result.empty? ? num.to_s : result
  end
end