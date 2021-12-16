const SECRETS = [
  'wink',
  'double blink',
  'close your eyes',
  'jump'
];

const REVERSE = 4;

export const commands = (handshake) => {
  let secrets = SECRETS.filter((s, i) => (handshake & 1 << i) > 0);
  if ((handshake & 1 << REVERSE) > 0)
    secrets.reverse();
  return secrets;
};
