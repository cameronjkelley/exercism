function parseTime(time) {
  return parseFloat(time.toFixed(2));
};

function SpaceAge(seconds) {
  this.seconds = seconds;
  this.earthPeriod = seconds / 31557600;
  this.orbitalPeriods = {
    Mercury: 0.2408467,
    Venus: 0.61519726,
    Mars: 1.8808158,
    Jupiter: 11.862615,
    Saturn: 29.447498,
    Uranus: 84.016846,
    Neptune:  164.79132
  };
  this.onEarth = function() {
    return parseTime(this.earthPeriod);
  };
  this.onMercury = function() {
    return parseTime(this.earthPeriod / this.orbitalPeriods["Mercury"]);
  };
  this.onVenus = function() {
    return parseTime(this.earthPeriod / this.orbitalPeriods["Venus"]);
  };
  this.onMars = function() {
    return parseTime(this.earthPeriod / this.orbitalPeriods["Mars"]);
  };
  this.onJupiter = function() {
    return parseTime(this.earthPeriod / this.orbitalPeriods["Jupiter"]);
  };
  this.onSaturn = function() {
    return parseTime(this.earthPeriod / this.orbitalPeriods["Saturn"]);
  };
  this.onUranus = function() {
    return parseTime(this.earthPeriod / this.orbitalPeriods["Uranus"]);
  };
  this.onNeptune = function() {
    return parseTime(this.earthPeriod / this.orbitalPeriods["Neptune"]);
  };
};

module.exports = SpaceAge;
