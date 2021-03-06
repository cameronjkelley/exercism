class Bob
  def self.hey(remark)
    stripped = remark.strip
    
    if asking_forcefully?(stripped)
      "Calm down, I know what I'm doing!"
    elsif asking?(stripped)
      "Sure."
    elsif yelling?(stripped)
      "Whoa, chill out!"
    elsif silent?(stripped)
      "Fine. Be that way!"
    else
      "Whatever."
    end
  end

  private
    def self.asking_forcefully?(remark)
      remark[-1] == "?" && remark == remark.upcase && /[A-Z]/.match?(remark)
    end
  
    def self.asking?(remark)
      remark[-1] == "?"
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
