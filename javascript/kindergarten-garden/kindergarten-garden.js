const DEFAULT_STUDENTS = [
  'Alice',
  'Bob',
  'Charlie',
  'David',
  'Eve',
  'Fred',
  'Ginny',
  'Harriet',
  'Ileana',
  'Joseph',
  'Kincaid',
  'Larry',
];

const PLANT_CODES = {
  G: 'grass',
  V: 'violets',
  R: 'radishes',
  C: 'clover',
};

export class Garden {
  #plots;

  constructor(diagram, students = DEFAULT_STUDENTS) {    
    this.#plots = this.assignPlots(diagram, students)
  }

  assignPlots(diagram, students) {
    let plots = {};
    let gardenRows = diagram.split('\n');
    students.sort().forEach((student, index) => {
      let start = index * 2, end = start + 2;
      if (end <= gardenRows[0].length && end <= gardenRows[1].length) {
        let plantCodes = gardenRows[0].slice(start, end) + gardenRows[1].slice(start, end);
        plots[student] = plantCodes.split('').map(pc => PLANT_CODES[pc]);
      }
    });
    return plots;
  }

  plants(student) {
    let plot = this.#plots[student];
    if (!plot) throw new Error();
    else return plot;
  }
}
