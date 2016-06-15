using System.Collections.Generic;
using System.Linq;

public class SumOfMultiples
{
  public static int To(int[] multiples, int limit)
  {
    List<int> result = new List<int>();
    IEnumerable<int> range = Enumerable.Range(1, limit - 1);

    foreach (int x in range)
    {
      foreach (int y in multiples)
      {
        if (x % y == 0 && !result.Contains(x))
        {
          result.Add(x);
        }
      }
    }
    return result.Sum();
  }
}