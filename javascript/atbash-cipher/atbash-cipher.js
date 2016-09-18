var letters = "abcdefghijklmnopqrstuvwxyz";

var atbash = {
  encode: function(text) {
    return text.toLowerCase().replace(/\W/g, "").split("").map(char => 
    letters.indexOf(char) === -1 ? char : letters[25 - letters.indexOf(char)])
    .join("").match(/.{1,5}/g).join(" ");
  }
};

module.exports = atbash;
