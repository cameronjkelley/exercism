function parseTime(time) {
  return parseFloat(time.toFixed(2));
};

function SpaceAge(seconds) {
  this.seconds = seconds;
  this.earthPeriod = seconds / 31557600;
  this.onEarth = function() {
    return parseTime(this.earthPeriod);
  };
  this.onMercury = function() {
    return parseTime(this.earthPeriod / 0.2408467;
  };
  this.onVenus = function() {
    return parseTime(this.earthPeriod / 0.61519726;
  };
  this.onMars = function() {
    return parseTime(this.earthPeriod / 1.8808158;
  };
  this.onJupiter = function() {
    return parseTime(this.earthPeriod / 11.862615;
  };
  this.onSaturn = function() {
    return parseTime(this.earthPeriod / 29.447498;
  };
  this.onUranus = function() {
    return parseTime(this.earthPeriod / 84.016846;
  };
  this.onNeptune = function() {
    return parseTime(this.earthPeriod / 164.79132;
  };
};

module.exports = SpaceAge;
