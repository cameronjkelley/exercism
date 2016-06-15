using System.Collections.Generic;
using System.Linq;

public class Complement
{
  private static Dictionary<string, string> Nucleotides = new Dictionary<string, string>()
  {
    { "G", "C" },
    { "C", "G" },
    { "T", "A" },
    { "A", "U" }
  };

  public static string OfDna(string input)
  {
    return string.Join("", input.Select(x => Nucleotides[x.ToString()]));
  }
}