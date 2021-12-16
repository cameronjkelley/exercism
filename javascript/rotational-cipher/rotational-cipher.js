export class RotationalCipher {
  static rotate(plainText, keyLength) {
    let cipherText = '';
    for (let i = 0; i < plainText.length; i++) {
      let str = plainText[i];
      if (this.isLetter(str)) {
        str = this.encipher(str, keyLength, this.isLowerCase(str) ? 97 : 65);
      } 
      cipherText += str;
    }
    return cipherText;
  }

  static isLetter(str) {
    return new RegExp('[a-z]', 'i').test(str);
  }

  static isLowerCase(str) {
    return str === str.toLowerCase();
  }

  static encipher(str, keyLength, firstCharCode) {
    return String.fromCharCode((str.charCodeAt(0) + keyLength - firstCharCode) % 26 + firstCharCode);
  }
}
