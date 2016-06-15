using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
  private string detector;

  public Anagram(string input)
  {
    detector = input;
  }

  private string SortString(string input)
  {
    return string.Concat(input.ToLower().OrderBy(x => x));
  }

  public string[] Match(string[] words)
  {
    List<string> matches = new List<string>();

    string sortedDetector = SortString(detector);

    foreach (string word in words)
    {
      string lowered = word.ToLower();

      if (SortString(word) == sortedDetector && !matches.Contains(lowered) && lowered != detector)
      {
        matches.Add(word);
      }
    }
    return matches.ToArray();
  }
}