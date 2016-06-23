using System.Collections.Generic;

public class School
{
  public Dictionary<int, List<string>> Roster { get; private set; }

  public School()
  {
    Roster = new Dictionary<int, List<string>>();
  }

  public void Add(string student, int grade)
  {
    if (Roster.ContainsKey(grade))
    {
      Roster[grade].Add(student);
    }
    else
    { 
      Roster[grade] = new List<string>() { student };
    }
    Roster[grade].Sort();
  }

  public List<string> Grade(int grade)
  {
    return Roster.ContainsKey(grade) ? Roster[grade] : new List<string>();
  }
}