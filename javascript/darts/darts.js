const Board = {
  Inner: {
    Points: 10,
    Radius: 1
  },
  Middle: {
    Points: 5,
    Radius: 5
  },
  Outer: {
    Points: 1,
    Radius: 10,
  }
};

export const score = (x, y) => {
  let z = Math.sqrt(x * x + y * y);
  if (z <= Board.Inner.Radius) return Board.Inner.Points;
  else if (z <= Board.Middle.Radius) return Board.Middle.Points;
  else if (z <= Board.Outer.Radius) return Board.Outer.Points;
  else return 0;
};