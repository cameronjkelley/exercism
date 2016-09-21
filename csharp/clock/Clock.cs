using System;

public struct Clock
{
  private int hours;
  private int minutes;

  public Clock(int hours, int minutes = 0)
  {
    this.hours = (((hours + minutes / 60) % 60) + 24) % 24;
    this.minutes = (minutes + 60) % 60;
  }

  public override string ToString()
  {
    return $"{hours:00}:{minutes:00}";
  }

  public Clock Add(int time)
  {
    int h = (minutes + time) / 60;
		int m = (minutes + time) % 60;
		return new Clock(hours + h, m);
  }

  public Clock Subtract(int time)
  {
    int h = minutes - time < 0 ? (int)Math.Ceiling(time / 60.0) : 0;
    int m = (minutes - time + 60) % 60;
    return new Clock(hours - h, m);
  }
}
