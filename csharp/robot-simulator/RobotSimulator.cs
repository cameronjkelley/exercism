public enum Bearing
{
	North, East, South, West
}

public struct Coordinate
{
	public int X { get; set; }
	public int Y { get; set; }

	public Coordinate(int x, int y)
	{
		X = x;
		Y = y;
	}
}

public class RobotSimulator
{
	public Bearing Bearing { get; set; }
	public Coordinate Coordinate { get; set; }

	public RobotSimulator(Bearing bearing, Coordinate coordinate)
	{
		Bearing = bearing;
		Coordinate = coordinate;
	}

	public void TurnLeft()
	{
		switch (Bearing)
		{
			case Bearing.North:
				Bearing = Bearing.West;
				break;
			case Bearing.South:
				Bearing = Bearing.East;
				break;
			case Bearing.East:
				Bearing = Bearing.North;
				break;
			case Bearing.West:
				Bearing = Bearing.South;
				break;
		}
	}

	public void TurnRight()
	{
		switch (Bearing)
		{
			case Bearing.North:
				Bearing = Bearing.East;
				break;
			case Bearing.South:
				Bearing = Bearing.West;
				break;
			case Bearing.East:
				Bearing = Bearing.South;
				break;
			case Bearing.West:
				Bearing = Bearing.North;
				break;
		}
	}

	public void Simulate(string directions)
	{
		foreach (char c in directions)
		{
			if (c == 'A') Advance();
			else if (c == 'L') TurnLeft();
			else TurnRight();
		}
	}

	private void Advance()
	{
		switch (Bearing)
		{
			case Bearing.North:
				Coordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
				break;
			case Bearing.South:
				Coordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
				break;
			case Bearing.East:
				Coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
				break;
			case Bearing.West:
				Coordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y);
				break;
		}
	}
}
