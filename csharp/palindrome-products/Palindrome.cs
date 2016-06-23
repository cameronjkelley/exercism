using System;
using System.Collections.Generic;
using System.Linq;

public class Palindrome
{
  public int Value { get; private set; }
  public Tuple<int, int>[] Factors { get; private set; }

  private Palindrome(int value, Tuple<int, int>[] factors)
  {
    Value = value;
    Factors = factors;
  }

  public static Palindrome Largest(int max)
  {
    return Largest(1, max);
  }

  public static Palindrome Largest(int min, int max)
  {
    return FindPalindrome(min, max, (x, y) => x >= y);
  }

  public static Palindrome Smallest(int max)
  {
    return Smallest(1, max);
  }

  public static Palindrome Smallest(int min, int max)
  {
    return FindPalindrome(min, max, (x, y) => x < y);
  }

  private static Palindrome FindPalindrome(int min, int max, Func<int, int, bool> compare)
  {
    int value = 0;
    List<Tuple<int, int>> factors = new List<Tuple<int, int>>();
    for (int i = min; i <= max; i++)
    {
      for (int j = i; j <= max; j++)
      {
        int product = j * i;
        if (IsPalindrome(product) && (compare(product, value) || value == 0))
        {
          value = product;
          factors.Add(Tuple.Create(i, j));
        }
      }
    }
    return new Palindrome(value, factors.Select(x => x).Where(y => y.Item1 * y.Item2 == value).ToArray());
  }

  private static bool IsPalindrome(int num)
  {
    int temp = num;
    int rem = 0;
    while (num > 0)
    {
      rem = rem * 10 + num % 10;
      num /= 10;
    }
    return temp == rem;
  }
}