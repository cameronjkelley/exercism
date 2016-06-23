using System.Text.RegularExpressions;

public class Acronym
{
  public static string Abbreviate(string input)
  {
    if (string.IsNullOrEmpty(input)) return string.Empty;

    string output = "";

    Regex pattern = new Regex(@"\b[A-Za-z]|[A-Z](?=[a-z])");
    MatchCollection matches = pattern.Matches(input);

    foreach (Match match in matches)
      output += match.Value;
    return output.ToUpper();
  }
}