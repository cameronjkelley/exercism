using System.Linq;

public class SumOfMultiples
{
  return return Enumerable.Range(1, limit - 1).Where(x => multiples.Any(y => x % y == 0)).Sum();
}
