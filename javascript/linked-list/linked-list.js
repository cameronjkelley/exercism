class Node {
  constructor(value) {
      this.val = value;
      this.prev = null;
      this.next = null;
  }
}

export class LinkedList {
  constructor() {
      this.size = 0;
      this.head = null;
      this.tail = null;
  }

  push(x) {
      let node = new Node(x);
      if (this.size === 0) {
          this.setHeadAndTail(node);
      } else {
          this.tail.next = node;
          node.prev = this.tail;
          this.tail = node;
      }
      this.size++;
  }

  pop() {
      this.size--;
      let node = this.tail;
      if (this.size === 0) {
        this.setHeadAndTail(null);
      } else {
        this.tail = this.tail.prev;
        this.tail.next = null;
      }
      return node.val;
  }

  shift() {
      this.size--;
      let node = this.head;
      if (this.size === 0) {
        this.setHeadAndTail(null);
      } else {
        this.head = this.head.next;
        this.head.prev = null;
      }
      return node.val;
  }

  unshift(x) {
      let node = new Node(x);
      if (this.size === 0) {
          this.setHeadAndTail(node);
      } else {
          this.head.prev = node;
          node.next = this.head;
          this.head = node;
      }
      this.size++;
  }

  delete(x) {
      let node = this.head;
      while (node !== null && node.val !== x) {
          node = node.next;
      }

      if (node !== null) {
          if (this.size === 1) {
              this.setHeadAndTail(null);
          } else if (node === this.head) {
              this.head = node.next;
              this.head.prev = null;
          } else if (node === this.tail) {
              this.tail = node.prev;
              this.head.next = null;
          } else {
              node.prev.next = node.next;
              node.next.prev = node.prev;
          }
          this.size--;
      }        
  }

  count() {
      return this.size;
  }

  setHeadAndTail(node) {
      this.head = this.tail = node;
  }
}