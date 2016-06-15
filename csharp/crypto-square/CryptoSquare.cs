using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Crypto
{
  private static string plainText { get; set; }

  public Crypto(string input)
  {
    plainText = input;
  }

  public string NormalizePlaintext
  {
    get
    {
      return string.Concat(plainText.Where(char.IsLetterOrDigit)).ToLower();
    }
  }

  public int Size
  {
    get
    {
      return (int)Math.Ceiling(Math.Sqrt(NormalizePlaintext.Length));
    }
  }

  public string[] PlaintextSegments()
  {
    string input = NormalizePlaintext;
    List<string> output = new List<string>();

    for (int i = 0; i < input.Length; i += Size)
    {
      output.Add(i + Size <= input.Length ? input.Substring(i, Size) : input.Substring(i, input.Length - i));
    }
    return output.ToArray();
  }

  public string Ciphertext()
  {
    return Regex.Replace(NormalizeCiphertext(), @"\s+", "");
  }

  public string NormalizeCiphertext()
  {
    string[] input = PlaintextSegments();
    string output = "";

    for (int i = 0; i < input[0].Length; i++)
    {
      for (int j = 0; j < input.Length; j++)
      {
        if (i < input[j].Length)
          output += input[j][i];
      }
      output += " ";
    }
    return output.Trim();
  }
}
