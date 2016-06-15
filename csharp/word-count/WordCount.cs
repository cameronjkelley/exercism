using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Phrase
{
  public static Dictionary<string, int> WordCount(string input)
  {
    Dictionary<string, int> output = new Dictionary<string, int>();
    Match match = Regex.Match(input, @"\w+'\w+|\w+");

    while (match.Success)
    {
      string word = match.Value.ToLower();
      if (!output.ContainsKey(word))
      {
        output.Add(word, 0);
      }
      output[word]++;
      match = match.NextMatch();
    }
    return output;
  }
}