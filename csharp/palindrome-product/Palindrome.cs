using System;
using System.Collections.Generic;
using System.Linq;

public class Palindrome
{
  public int Value { get; set; }

  public List<Tuple<int, int>> Factors { get; set; }

  private Palindrome(int value, List<Tuple<int, int>> factors)
  {
    Value = value;
    Factors = factors;
  }

  public static Palindrome Smallest(int max)
  {
    return Smallest(1, max);
  }

  public static Palindrome Smallest(int min, int max)
  {
    var palindromes = GetPalindromes(min, max);
    int value = palindromes.Keys.First();
    var factors = palindromes[value];
    return new Palindrome(value, factors);
  }

  public static Palindrome Largest(int max)
  {
    return Largest(1, max);
  }

  public static Palindrome Largest(int min, int max)
  {
    var palindromes = GetPalindromes(min, max);
    int value = palindromes.Keys.Last();
    var factors = palindromes[value];
    return new Palindrome(value, factors);
  }

  private static Dictionary<int, List<Tuple<int, int>>> GetPalindromes(int min, int max)
  {
    var result = new Dictionary<int, List<Tuple<int, int>>>();
    for (int i = min; i <= max; i++)
    {
      for (int j = min; j <= i; j++)
      {
        int product = i * j;
        if (IsPalindrome(product))
        {
          if (result.ContainsKey(product))
          {
            result[product].Add(new Tuple<int, int>(i, j));
          }
          else
          {
            result[product] = new List<Tuple<int, int>>() { Tuple.Create(i, j) };
          }
        }
      }
    }
    return result;
  }

  private static bool IsPalindrome(int number)
  {
    string original = number.ToString();
    char[] reversed = original.ToArray();
    Array.Reverse(reversed);
    return original == string.Join("", reversed);
  }
}