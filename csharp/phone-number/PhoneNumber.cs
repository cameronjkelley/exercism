using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
  private string _number { get; set; }

  public PhoneNumber(string num)
  {
    _number = FormatNumber(num);
  }

  public string Number()
  {
    return _number;
  }

  public string AreaCode()
  {
    return _number.Substring(0, 3);
  }

  public override string ToString()
  {
    string a = _number.Substring(0, 3),
           b = _number.Substring(3, 3),
           c = _number.Substring(6, 4);

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
    {
      return result;
    }
    else if (result.Length == 11 && result.IndexOf("1") == 0)
    {
      return result.Substring(1);
    }
    return "0000000000";
  }
}
