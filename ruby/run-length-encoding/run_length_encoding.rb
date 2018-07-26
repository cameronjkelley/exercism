class RunLengthEncoding
  def self.encode(input)
    input.chars.chunk{ |x| x }.map{ |y, ary|
      [ary.length > 1 ? ary.length : "", y]
    }.join("")
  end

  def self.decode(input)
    input.scan(/(\d*?)(\D)/).map{ |ary|
      ary[0].to_i == 0 ? "#{ ary[1] }" : "#{ ary[1] * ary[0].to_i }"
    }.join("")
  end
end

module BookKeeping
  VERSION = 3
end
