using System;
using System.Collections.Generic;
public class PrimeFactors
{
  public static List<int> For(long n)
  {
    List<int> primes = new List<int>();
    int i = 2;
    while (n > 1)
    {
      while (n % i == 0)
      {
        primes.Add(i);
        n /= i;
      }
      i++;
    }
    return primes;
  }
}