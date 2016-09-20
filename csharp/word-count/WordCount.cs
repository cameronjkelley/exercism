using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Phrase
{
  public static Dictionary<string, int> WordCount(string input)
  {
    Dictionary<string, int> output = new Dictionary<string, int>();
    MatchCollection matches = Regex.Matches(input, @"\w+'\w+|\w+");
    foreach (Match match in matches)
    {
      string word = match.Value.ToLower();
      if (!output.ContainsKey(word)) output.Add(word, 0);
      output[word]++;
    }
    return output;
  }
}
