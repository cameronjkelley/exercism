using System;
using System.Text.RegularExpressions;

public class Octal
{
  public static int ToDecimal(string number)
  {
    int result = 0, i = 0;
    if (IsValid(number))
    {
      for (int len = number.Length - 1; len >= 0; len--)
      {
        result += int.Parse(number[i].ToString()) * (int)Math.Pow(8, len);
        i++;
      }
    }
    return result;
  }

  private static bool IsValid(string number)
  {
    return Regex.IsMatch(number, "^[0-7]+$");
  }
}
