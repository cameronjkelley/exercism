export const tournamentTally = (input) => {
  const header = 'Team                           | MP |  W |  D |  L |  P';
  if (input.length === 0)
    return header;

  let teams = [];
  input
  .split('\n')
  .map(x => x.split(';'))
  .forEach(match => {
    let t0 = teams.find(t => t.name === match[0]);
    if (t0 === undefined) {
      t0 = new Team(match[0]);
      teams.push(t0);
    }

    let t1 = teams.find(t => t.name === match[1]);
    if (t1 === undefined) {
      t1 = new Team(match[1]);
      teams.push(t1);
    }

    let result = match[2];
    switch (result) {
      case 'win':
        t0.wins += 1;
        t0.points += 3;
        t1.losses += 1;
        break;
      case 'draw':
        t0.draws += 1;
        t0.points += 1;
        t1.draws += 1;
        t1.points += 1;
        break;
      case 'loss':
        t0.losses += 1;
        t1.wins += 1;
        t1.points += 3;
        break;
      default:
        break;
    } 
  });

  teams.sort((a, b) => a.points > b.points ? -1 : a.points < b.points ? 1 : a.name < b.name ? -1 : 0);

  let output = header + '\n' + teams.map(t => `${t.name.padEnd(30)} |  ${t.wins + t.draws + t.losses} |  ${t.wins} |  ${t.draws} |  ${t.losses} |${t.points.toString().padStart(3)}\n`).join('');
  
  return output.substring(0, output.lastIndexOf('\n'));
}

class Team {
  constructor(name) {
    this.name = name;
    this.wins = 0;
    this.draws = 0;
    this.losses = 0;
    this.points = 0;
  }
}