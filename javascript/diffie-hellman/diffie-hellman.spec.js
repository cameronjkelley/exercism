/* eslint-disable no-new */
import { DiffieHellman } from './diffie-hellman';

describe('diffie-hellman', () => {
  test('throws an error if the constructor arguments are out of range', () => {
    expect(() => {
      new DiffieHellman(0, 9999);
    }).toThrow();
  });

  test('throws an error if the constructor arguments are not prime', () => {
    expect(() => {
      new DiffieHellman(10, 13);
    }).toThrow();
  });

  describe('input validation', () => {
    let p = 23;
    let g = 5;
    //let diffieHellman = new DiffieHellman(p, g);

    test('throws an error if private key is negative', () => {
      expect(() => {
        new DiffieHellman(p, g).getPublicKey(-1);
      }).toThrow();
    });

    test('throws an error if private key is zero', () => {
      expect(() => {
        new DiffieHellman(p, g).getPublicKey(0);
      }).toThrow();
    });

    test('throws an error if private key is one', () => {
      expect(() => {
        new DiffieHellman(p, g).getPublicKey(1);
      }).toThrow();
    });

    test('throws an error if private key equals the modulus parameter p', () => {
      expect(() => {
        new DiffieHellman(p, g).getPublicKey(p);
      }).toThrow();
    });

    test('throws an error if private key is greater than the modulus parameter p', () => {
      expect(() => {
        new DiffieHellman(p, g).getPublicKey(p + 1);
      }).toThrow();
    });
  });

  describe('stateless calculation', () => {
    let diffieHellman = new DiffieHellman(23, 5);

    let alicePrivateKey = 6;
    let alicePublicKey = 8;

    let bobPrivateKey = 15;
    let bobPublicKey = 19;

    test('can calculate public key using private key', () => {
      expect(diffieHellman.getPublicKey(alicePrivateKey)).toEqual(
        alicePublicKey
      );
    });

    test('can calculate public key when given a different private key', () => {
      expect(diffieHellman.getPublicKey(bobPrivateKey)).toEqual(bobPublicKey);
    });
  });

  describe('shared secret', () => {
    let diffieHellman = new DiffieHellman(23, 5);

    test("can calculate secret using other party's public key", () => {
      expect(diffieHellman.getSecret(19, 6)).toEqual(2);
    });
  
    test('key exchange', () => {
      let alicePrivateKey = 6;
      let bobPrivateKey = 15;
      let alicePublicKey = diffieHellman.getPublicKey(alicePrivateKey);
      let bobPublicKey = diffieHellman.getPublicKey(bobPrivateKey);
  
      let secretA = diffieHellman.getSecret(bobPublicKey, alicePrivateKey);
      let secretB = diffieHellman.getSecret(alicePublicKey, bobPrivateKey);
  
      expect(secretA).toEqual(secretB);
    });
  });
  
});
