using System;
using System.Text.RegularExpressions;

public class Trinary
{
  public static int ToDecimal(string number)
  {
    int result = 0;
    if (IsValidTrinary(number))
    {
      string reversed = Reverse(number);
      for (int i = 0; i < reversed.Length; i++)
      {
        result += int.Parse(reversed[i].ToString()) * (int)Math.Pow(3, i);
      }
    }
    return result;
  }

  private static bool IsValidTrinary(string number)
  {
    bool result = false;
    Regex pattern = new Regex(@"^[012]+$");
    if (pattern.IsMatch(number))
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