var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
    bots = {};

function getRandom(max) {
  return parseInt(Math.random() * max);
};

function createName() {
  var name = letters[getRandom(26)] + letters[getRandom(26)]
             + Math.random().toString().substr(-3);

  if (bots[name]) return createName();
  else bots[name] = true;
  return name;
};

module.exports = function() {
  this.name = createName();
  this.reset = function() {
    this.name = createName();
  };
};
