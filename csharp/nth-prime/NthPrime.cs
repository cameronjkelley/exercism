using System;
using System.Collections.Generic;

public class NthPrime
{
  public static int Nth(int x)
  {
    List<int> primes = new List<int>() { 2 };
    int p = 3;
    while (primes.Count != x)
    {
      p += 2;
      if (isPrime(p))
      {
        primes.Add(p);
      }
    }
    return primes[x - 1];
  }

  private static bool isPrime(int x)
  {
    for(int i = 3; i <= Math.Sqrt(x); i += 2)
    {
      if (x % i == 0)
      {
        return false;
      }
    }
    return true;
  }
}
