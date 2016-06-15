using System;
using System.Text.RegularExpressions;

public class Octal
{
  public static int ToDecimal(string number)
  {
    int result = 0;
    if (IsValid(number))
    {
      string reversed = Reverse(number);
      for (int i = 0; i < reversed.Length; i++)
      {
        result += int.Parse(reversed[i].ToString()) * (int)Math.Pow(8, i);
      }
    }
    return result;
  }

  private static bool IsValid(string input)
  {
    bool result = false;
    Regex pattern = new Regex(@"^[0-7]+$");
    if (pattern.IsMatch(input))
    {
      result = true;
    }
    return result;
  }

  private static string Reverse(string s)
  {
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
  }
}