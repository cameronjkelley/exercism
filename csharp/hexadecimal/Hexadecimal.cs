using System;

public class Hexadecimal
{
  private static string Hex = "0123456789abcdef";
  public static int ToDecimal(string input)
  {
    int output = 0;
    int power = input.Length - 1;
    for (int i = 0; i < input.Length; i++)
    {
      if (Hex.IndexOf(input[i]) == -1) return 0;
      else output += Hex.IndexOf(input[i]) * (int)Math.Pow(16, power);
      power--;
    }
    return output;
  }
}
