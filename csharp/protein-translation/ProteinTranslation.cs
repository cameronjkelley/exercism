using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ProteinTranslation
{
  private static Dictionary<string, List<string>> Acids = new Dictionary<string, List<string>> {
    { "Methionine", new List<string> { "AUG" } },
    { "Phenylalanine", new List<string> { "UUU", "UUC" } },
    { "Leucine", new List<string> { "UUA", "UUG" } },
    { "Serine", new List<string> { "UCU", "UCC", "UCA", "UCG" } },
    { "Tyrosine", new List<string> { "UAU", "UAC" } },
    { "Cysteine", new List<string> { "UGU", "UGC" } },
    { "Tryptophan", new List<string> { "UGG" } },
    { "STOP", new List<string> { "UAA", "UAG", "UGA" } }
  };
  
  public static string[] Translate(string codon)
  {
    if (Regex.IsMatch(codon, @"[^ACGU]")) 
    {
      throw new Exception();
    }
    
    IEnumerable<string> codons = Enumerable.Range(0, codon.Length / 3).Select(x => codon.Substring(x * 3, 3));
    List<string> acids = new List<string>();
    
    foreach (string code in codons)
    {
      bool end = false;
      foreach (var pair in Acids)
      {
        if (pair.Value.Contains(code))
        {
          if (pair.Key == "STOP")
          {
            end = true;
            break;
          }
          else if (!acids.Contains(pair.Key))
          {
            acids.Add(pair.Key);
          }
        }
      }
      
      if (end) 
      {
        break;
      }
    }
    return acids.ToArray();
  }
}
