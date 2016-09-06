using System.Text.RegularExpressions;

public class PigLatin
{
  public static string Translate(string input)
  {
    string output = "";

    Regex vowels = new Regex(@"^[aeiou]");
    Regex special = new Regex(@"^xr|^yt");
    Regex trios = new Regex(@"^sch|^squ|^thr");
    Regex duos = new Regex(@"^ch|^qu|^th");

    string[] inputArray = input.Split(' ');

    foreach (string word in inputArray)
    {
      if (vowels.IsMatch(word) || special.IsMatch(word))
        output += word + "ay ";
      else if (trios.IsMatch(word))
        output += word.Substring(3) + word.Substring(0, 3) + "ay ";
      else if (duos.IsMatch(word))
        output += word.Substring(2) + word.Substring(0, 2) + "ay ";
      else
        output += word.Substring(1) + word.Substring(0, 1) + "ay ";
    }
    return output.Trim();
  }
}
