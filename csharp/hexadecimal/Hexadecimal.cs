using System;
using System.Collections.Generic;

public class Hexadecimal
{
  private static Dictionary<char, int> alphaNumerals = new Dictionary<char, int>
  {
    { 'a', 10 },
    { 'b', 11 },
    { 'c', 12 },
    { 'd', 13 },
    { 'e', 14 },
    { 'f', 15 }
  };

  public static int ToDecimal(string input)
  {
    int output = 0;
    int power = input.Length - 1;
    for (int i = 0; i < input.Length; i++)
    {
      int number;
      bool result = Int32.TryParse(input[i].ToString(), out number);
      if (result)
      {
        output += number * (int)Math.Pow(16, power);
      }
      else
      {
        if (alphaNumerals.ContainsKey(input[i]))
        {
          output += alphaNumerals[input[i]] * (int)Math.Pow(16, power);
        }
        else
        {
          return 0;
        }
      }
      power--;
    }
    return output;
  }
}
