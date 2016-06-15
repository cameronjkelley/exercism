using System;

public class Binary
{
  public static int ToDecimal(string binary)
  {
    int output = 0, i = 0;
    for (int len = binary.Length - 1; len >= 0; len--)
    {
      if (!ValidInput(binary[i]))
      {
        return 0;
      }
      output += Int32.Parse(binary[i].ToString()) * (int)Math.Pow(2, len);
      i++;
    }
    return output;
  }

  private static bool ValidInput(char input)
  {
    return input == '0' || input == '1';
  }
}
