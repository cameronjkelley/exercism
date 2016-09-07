function School() {
  var roll = {};
  this.roster = function() {
    return roll;
  };
  this.add = function(student, grade) {
    if (roll[grade] === undefined) roll[grade] = [student];
    else roll[grade].push(student);
    roll[grade].sort();
  };
  this.grade = function(number) {
    return roll[number] === undefined ? [] : roll[number];
  }
};

module.exports = School;
