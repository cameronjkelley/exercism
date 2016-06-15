using System.Collections.Generic;
using System.Linq;

public class Atbash
{
  private static string Alphabet = "abcdefghijklmnopqrstuvwxyz";
  private static string AtbashAlphabet = "zyxwvutsrqponmlkjihgfedcba";

  public static string Encode(string input)
  {
    string code = string.Concat(ValidCharacters(input).ToLower().Select(Encipher));
    return ProperlySpaced(code);
  }

  private static string ValidCharacters(string input)
  {
    return string.Concat(input.Where(char.IsLetterOrDigit));
  }

  private static char Encipher(char input)
  {
    int index = Alphabet.IndexOf(input);
    return index != -1 ? AtbashAlphabet[index] : input;
  }

  private static string ProperlySpaced(string input)
  {
    var output = new List<string>();
    for (int i = 0; i < input.Length; i += 5)
    {
      output.Add(i + 5 <= input.Length ? input.Substring(i, 5) : input.Substring(i));
    }
    return string.Join(" ", output);
  }
}