using System.Collections.Generic;
using System.Linq;

public class Anagram
{
  private string original;

  public Anagram(string input)
  {
    original = input;
  }

  private string SortString(string input)
  {
    return string.Concat(input.ToLower().OrderBy(x => x));
  }

  public string[] Match(string[] words)
  {
    List<string> matches = new List<string>();
    string sortedoriginal = SortString(original);

    foreach (string word in words)
    {
      string lowered = word.ToLower();

      if (SortString(word) == sortedoriginal && lowered != original)
        matches.Add(word);
    }
    return matches.ToArray();
  }
}
