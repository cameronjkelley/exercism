function getRandom(max) {
  return Math.floor(Math.random() * max);
};
function createName() {
  var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
      model = alphabet[getRandom(26)] + alphabet[getRandom(26)],
      serial = Math.random().toString().substring(2, 5);
  return model + serial;
};
function Robot() {
  this.name = createName();
  this.reset = function() {
    this.name = createName();
  };
};

module.exports = Robot;
