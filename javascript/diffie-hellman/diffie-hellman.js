export class DiffieHellman {
  #p;
  #g;
  
  constructor(p, g) {
    if (!(this.isPrime(p) && this.isPrime(g)))
      throw new Error();
    this.#p = p;
    this.#g = g;
  }

  getPublicKey(privateKey) {
    if (!this.isValidPrivateKey(privateKey))
      throw new Error();
    return this.#g ** privateKey % this.#p;
  }

  getSecret(theirPublicKey, myPrivateKey) {
    if (theirPublicKey <= 1 || !this.isValidPrivateKey(myPrivateKey))
      throw new Error();
    return theirPublicKey ** myPrivateKey % this.#p;
  }

  isPrime(n) {
    if (n < 2 || (n > 2 && n % 2 === 0))
      return false;

    for (let i = 3; i < Math.sqrt(n); i += 2) {
      if (n % i === 0)
        return false;
    }
    return true;
  }

  isValidPrivateKey(k) {
    return k > 1 && k < this.#p;
  }
}
