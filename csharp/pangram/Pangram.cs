using System.Linq;
using System.Text.RegularExpressions;

class Pangram
{
	public static bool IsPangram(string phrase)
	{
		phrase = Regex.Replace(phrase.ToLower(), @"\W|\d|_|[^\u0000-\u007F]+", "");
		return phrase.Where((x, i) => phrase.IndexOf(x) == i).Count() == 26;
	}
}
