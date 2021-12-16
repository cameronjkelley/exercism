export class Element {
  #value;
  #next;

  constructor(val) {
    this.#value = val;
    this.#next = null;
  }

  get value() {
    return this.#value;
  }

  set value(val) {
    this.#value = val;
  }

  get next() {
    return this.#next;
  }

  set next(element) {
    this.#next = element;
  }
}

export class List {
  #head;
  #length;
  
  constructor(args) {
    this.#head = null;
    this.#length = 0;
    if (args !== undefined) {
      args.forEach(a => { this.add(new Element(a)) });
    }
  }

  add(nextValue) {
    if (this.#head === null) {
      this.#head = nextValue;
    } else {
      let prevValue = this.#head;
      this.#head = nextValue;
      this.#head.next = prevValue;
    }
    this.#length++;
  }

  get length() {
    return this.#length;
  }

  get head() {
    return this.#head;
  }

  toArray() {
    const ary = [];
    let e = this.#head;
    while (e) {
      ary.push(e.value);
      e = e.next;
    }
    return ary;
  }

  reverse() {
    return new List(this.toArray());
  }
}
