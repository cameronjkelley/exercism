var Acronyms = {
  parse: function(phrase) {
      return phrase.match(/\b\w|[A-Z](?=[a-z])/g).join("").toUpperCase();
  }
};

module.exports = Acronyms;
