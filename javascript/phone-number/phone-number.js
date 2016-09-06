function PhoneNumber(input) {
  this.input = input.replace(/\W/g, "");
  this.number = function() {
    if (this.input.length === 10) return this.input;
    else if (this.input.length === 11 && this.input.charAt(0) === '1') return this.input.substring(1);
    else return "0000000000";
  }
  this.areaCode = function() {
      return this.number().slice(0, 3);
  }
  this.toString = function() {
    return "(" + this.areaCode() + ") " + this.number().slice(3, 6) + "-" + this.number().slice(6);
  }
};

module.exports = PhoneNumber;
