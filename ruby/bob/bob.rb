class Bob
  def self.hey(remark)
    stripped = remark.strip
    if self.asking_forcefully?(stripped)
      "Calm down, I know what I'm doing!"
    elsif self.asking?(stripped)
      "Sure."
    elsif self.yelling?(stripped)
      "Whoa, chill out!"
    elsif self.silent?(stripped)
      "Fine. Be that way!"
    else
      "Whatever."
    end
  end

  def self.asking?(remark)
    remark[-1] == "?"
  end

  def self.asking_forcefully?(remark)
    remark[-1] == "?" && remark == remark.upcase && /[A-Z]/.match?(remark)
  end

  def self.yelling?(remark)
    remark == remark.upcase && /[A-Z]/.match?(remark)
  end

  def self.silent?(remark)
    remark.empty?
  end
end

module BookKeeping
  VERSION = 2
end
