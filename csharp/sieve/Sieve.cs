using System.Collections.Generic;
using System.Linq;

public class Sieve
{
	public static int[] Primes(int limit)
	{
		List<int> range = Enumerable.Range(2, limit - 1).ToList();
		for (int i = 2; i < range.Count; i++)
		{
			for (int j = i; j < range.Count; j++)
			{
				range.Remove(i * j);
			}
		}
		return range.ToArray();
	}
}