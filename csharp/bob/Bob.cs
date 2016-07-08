using System.Text.RegularExpressions;

public class Bob
{
  public static string Hey(string input)
  {
    if (Silent(input)) return "Fine. Be that way!";
    else if (Yelling(input)) return "Whoa, chill out!";
    else if (Asking(input)) return "Sure.";
    else return "Whatever.";
  }

  public static bool Silent(string input)
  {
    return input.Trim() == "";
  }

  public static bool Yelling(string input)
  {
    return input.ToUpper() == input && Regex.IsMatch(input, "[a-zA-Z]+");
  }

  public static bool Asking(string input)
  {
    return input.Trim().EndsWith("?");
  }
}
