using System.Linq;

class Isogram
{
	public static bool IsIsogram(string input)
	{
		string lowered = input.ToLower();
		return input.Length == lowered.Where(x => lowered.IndexOf(x) == lowered.LastIndexOf(x) || (x == ' ' || x == '-')).Count();
	}
}
