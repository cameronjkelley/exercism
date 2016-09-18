function accumulate(collection, predicate) {
  var result = [];
  collection.forEach((element) => result.push(predicate(element)));
  return result;
};

module.exports = accumulate;
