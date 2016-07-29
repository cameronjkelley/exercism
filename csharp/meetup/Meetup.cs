using System;

public enum Schedule
{
  Teenth, First, Second, Third, Fourth, Last
}

public class Meetup
{
  private int Month;
  private int Year;

  public Meetup(int month, int year)
  {
    Month = month;
    Year = year;
  }

  public DateTime Day(DayOfWeek dow, Schedule preference)
  {
    if (preference == Schedule.Last) return GetLastDay(Year, Month, dow);
    return GetPreferredDay(Year, Month, dow, preference);
  }

  private DateTime GetLastDay(int year, int month, DayOfWeek day)
  {
    for (int i = DateTime.DaysInMonth(year, month); i >= 22; i--)
    {
      DateTime dt = new DateTime(year, month, i);
      if (dt.DayOfWeek == day) return dt;
    }
    return new DateTime();
  }

  private DateTime GetPreferredDay(int year, int month, DayOfWeek day, Schedule preference)
  {
    DateTime date = new DateTime();
    int idx, lmt;
    if (preference == Schedule.Teenth)
    {
      idx = 13;
      lmt = 19;
    }
    else
    {
      idx = ((int)preference - 1) * 7 + 1;
      lmt = (int)preference * 7;
    }

    for (; idx <= lmt; idx++)
    {
      DateTime dt = new DateTime(year, month, idx);
      if (dt.DayOfWeek == day) date = dt;
    }
    return date;
  }
}
