using System;
using System.Collections.Generic;
using System.Linq;

public class Sieve
{
  public static int[] Primes(int p)
  {
    //int[] range = Enumerable.Range(2, p - 1).ToArray();
    //List<int> composites = new List<int>();

    //for (int i = 0; i < range.Length; i++)
    //{
    //  for (int j = 0; j < range.Length; j++)
    //  {
    //    int composite = range[i] * range[j];
    //    composites.Add(composite);
    //  }
    //}
    //return range.Except(composites.ToArray()).ToArray();

    List<int> primes = new List<int>();
    Queue<int> candidates = new Queue<int>(Enumerable.Range(2, p - 1).ToArray());

    while (candidates.Count > 0)
    {
      int candidate = candidates.Dequeue();
      primes.Add(candidate);
      candidates = new Queue<int>(candidates.Where(x => x % candidate != 0));
      if (candidate > Math.Sqrt(p))
      {
        primes.AddRange(candidates);
        break;
      }
    }
    return primes.ToArray();
  }
}