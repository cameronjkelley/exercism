function accumulate(collection, predicate) {
  return collection.map((x) => predicate(x));
};

module.exports = accumulate;
