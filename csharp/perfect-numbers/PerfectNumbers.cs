using System.Linq;

class PerfectNumbers
{
	public enum NumberType
	{
		Deficient, Abundant, Perfect
	}

	public static NumberType Classify(int number)
	{
		int sum = Enumerable.Range(1, number / 2).Where(x => number % x == 0).Sum();

		if (sum < number) return NumberType.Deficient;
		else if (sum > number) return NumberType.Abundant;
		else return NumberType.Perfect;
	}
}
