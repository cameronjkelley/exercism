export const score = (rolls, category) => {
  switch (category) {
    case 'choice':
      return sum(rolls);
    case 'yacht':
      return rolls.every(r => r === rolls[0]) ? 50 : 0;
    case 'ones':
      return scoreNumber(rolls, 1);
    case 'twos':
      return scoreNumber(rolls, 2);
    case 'threes':
      return scoreNumber(rolls, 3);
    case 'fours':
      return scoreNumber(rolls, 4);
    case 'fives':
      return scoreNumber(rolls, 5);
    case 'sixes':
      return scoreNumber(rolls, 6);
    case 'full house':
      return scoreFullHouse(rolls);
    case 'four of a kind':
      return scoreFourOfAKind(rolls);
    case 'little straight':
    case 'big straight':
      return scoreStraight(rolls, category);
    default:
      break;
  }
};

const groupRolls = (rolls) => {
  return rolls.reduce((a, b) => (a[b] = a[b] + 1 || 1, a), {});
}

const scoreFourOfAKind = (rolls) => {
  let groups = groupRolls(rolls),
    index = Object.values(groups).findIndex(v => v >= 4);
  return index > -1 ? Object.keys(groups)[index] * 4 : 0;
}

const scoreFullHouse = (rolls) => {
  let groups = groupRolls(rolls),
    values = Object.values(groups);
  return values.findIndex(v => v === 3) > -1 && values.findIndex(v => v === 2) > -1 ? sum(rolls) : 0;
}

const scoreNumber = (rolls, number) => { 
  return rolls.filter(r => r === number).length * number;
}

const scoreStraight = (rolls, category)  => {
  if (rolls.length === new Set(rolls).size) {
    let s = sum(rolls);
    if ((s === 15 && category === 'little straight') || (s === 20 && category === 'big straight'))
      return 30;
  }
  return 0;
}

const sum = (rolls) => {
  return rolls.reduce((a, b) => a + b);
}