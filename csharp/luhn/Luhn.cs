using System;
using System.Linq;

public class Luhn
{
  private int[] numbers;

  public Luhn(long number)
  {
    numbers = number.ToString().Select(x => (int)Char.GetNumericValue(x)).ToArray();
  }

  public int CheckDigit
  {
    get
    {
      return numbers.Last();
    }
  }

  public int[] Addends
  {
    get
    {
      return Doubled(numbers);
    }
    
  }

  public int Checksum
  {
    get
    {
      return Addends.Sum();
    }
  }

  public bool Valid
  {
    get
    {
      return Checksum % 10 == 0;
    }
  }

  public static long Create(long number)
  {
    number *= 10;
    Luhn luhn = new Luhn(number);
    return luhn.Valid ? number : number + (10 - (luhn.Checksum % 10));
  }

  private int[] Doubled(int[] input)
  {
    int[] output = input.ToArray();
    int i = output.Length % 2 == 0 ? 0 : 1;
    for (; i < output.Length - 1; i += 2)
    {
      int doubled = output[i] * 2;
      output[i] = doubled > 9 ? doubled - 9 : doubled;
    }
    return output;
  }
}
