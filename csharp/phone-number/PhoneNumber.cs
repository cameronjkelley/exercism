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
    Regex pattern = new Regex(@"\W");
    num = pattern.Replace(num, "");

    if (num.Length == 10) 
      return num;
    else if (num.Length == 11 && num.StartsWith("1")) 
      return num.Substring(1);
    else 
      return "0000000000";
  }
}
