using System.Text.RegularExpressions;

public class Acronym
{
  public static string Abbreviate(string input)
  {
    if (string.IsNullOrEmpty(input)) return string.Empty;

    string output = "";

    Regex pattern = new Regex(@"\b[A-Za-z]|[A-Z](?=[a-z])");
    Match match = pattern.Match(input);

    while (match.Success)
    {
      output += match.Value;
      match = match.NextMatch();
    }
    return output.ToUpper();
  }
}
