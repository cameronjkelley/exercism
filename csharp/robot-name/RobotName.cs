using System;

public class Robot
{
  public string Name { get; private set; }

  public Robot()
  {
    Reset();
  }

  public void Reset()
  {
    Name = RobotName();
  }

  private string RobotName()
  {
    return GetLetter() + GetLetter() + GetNumbers();
  }

  private static Random random = new Random();

  private string GetLetter()
  {
    return ((char)('A' + random.Next(26))).ToString();
  }

  private string GetNumbers()
  {
    return (random.Next(1000)).ToString("000"); 
  }
}