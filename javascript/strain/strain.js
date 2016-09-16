var strain = {
  keep: function(collection, predicate) {
    return filter(collection, predicate);
  },
  discard: function(collection, predicate) {
    return filter(collection, x => !predicate(x));
  }
};

function filter(collection, predicate) {
  var output = [];
  for (var i = 0; i < collection.length; i++) {
    if (predicate(collection[i])) output.push(collection[i]);
  }
  return output;
};

module.exports = strain;
