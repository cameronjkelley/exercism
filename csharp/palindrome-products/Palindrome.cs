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
    return GetLargestPalindrome(1, max);
  }

  public static Palindrome Largest(int min, int max)
  {
    return GetLargestPalindrome(min, max);
  }

  public static Palindrome Smallest(int max)
  {
    return GetSmallestPalindrome(1, max);
  }

  public static Palindrome Smallest(int min, int max)
  {
    return GetSmallestPalindrome(min, max);
  }

  private static Palindrome GetLargestPalindrome(int min, int max)
  {
    int value = 0;
    List<Tuple<int, int>> factors = new List<Tuple<int, int>>();
    for (int i = max; i >= min; i--)
    {
      for (int j = i; j >= min; j--)
      {
        int product = j * i;
        if (product >= value)
        {
          string s = product.ToString();
          if (s == Reverse(s))
          {
            value = product;
            factors.Add(Tuple.Create(j, i));
          }
        }
      }
    }
    return new Palindrome(value, factors.Select(x => x).Where(y => y.Item1 * y.Item2 == value).ToArray());
  }

  private static Palindrome GetSmallestPalindrome(int min, int max)
  {
    int value = 0;
    List<Tuple<int, int>> factors = new List<Tuple<int, int>>();
    for (int i = min; i <= max; i++)
    {
      for (int j = i; j <= max; j++)
      {
        int product = j * i;
        if (value == 0)
        {
          string s = product.ToString();
          if (s == Reverse(s))
          {
            value = product;
            factors.Add(Tuple.Create(j, i));
            break;
          }
        }
      }
    }
    return new Palindrome(value, factors.ToArray());
  }

  private static string Reverse(string x)
  {
    char[] chars = x.ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
  }
}