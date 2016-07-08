using System.Text.RegularExpressions;

public class PhoneNumber
{
  private string number { get; set; }

  public PhoneNumber(string num)
  {
    number = FormatNumber(num);
  }

  public string Number()
  {
    return number;
  }

  public string AreaCode()
  {
    return number.Substring(0, 3);
  }

  public override string ToString()
  {
    string a = number.Substring(0, 3),
           b = number.Substring(3, 3),
           c = number.Substring(6, 4);

    return $"({a}) {b}-{c}";
  }

  private string FormatNumber(string num)
  {
    string result = "";
    Regex pattern = new Regex(@"\d+");
    MatchCollection matches = pattern.Matches(num);

    foreach (Match match in matches)
    {
      result += match.Value;
    }

    if (result.Length == 10)
      return result;
    else if (result.Length == 11 && result.IndexOf("1") == 0)
      return result.Substring(1);
    else
      return "0000000000";
  }
}
