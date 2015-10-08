class Robot
  attr_reader :name

  def initialize
    @name = random_name
  end

  def random_name
    initials + triplet
  end

  def initials
    (0...2).map { ("A".."Z").to_a[rand(26)] }.join
  end

  def triplet
    (0..2).map { rand(9) }.join
  end

  def reset
    @name = random_name
  end
end