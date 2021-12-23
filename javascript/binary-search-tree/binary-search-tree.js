export class BinarySearchTree {
  constructor(data) {
    this._data = data;
    this._left = null;
    this._right = null;
  }

  get data() {
    return this._data;
  }

  get left() {
    return this._left;
  }

  get right() {
    return this._right;
  }

  insert(data) {
    if (data <= this._data) {
      if (this._left === null)
        this._left = new BinarySearchTree(data);
      else
        this._left.insert(data);
    } else {
      if (this._right === null)
        this._right = new BinarySearchTree(data);
      else
        this._right.insert(data);
    }
  }

  each(func) {
    if (this._left !== null) {
      this._left.each(func)
    }
    func(this._data)
    if (this._right !== null) {
      this._right.each(func)
    }
  }
}