using System;
using System.Collections.Generic;

public class DNA
{
  public DNA(string input)
  {
    SetNucleotideCounts(input);
  }

  public Dictionary<char, int> NucleotideCounts { get; set; }

  private void SetNucleotideCounts(string strand)
  {
    NucleotideCounts = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };

    foreach(var x in strand)
    {
      NucleotideCounts[x] += 1;
    }
  }

  public int Count(char input)
  {
    int count;
    if (!NucleotideCounts.TryGetValue(input, out count))
    {
      throw new InvalidNucleotideException();
    }
    return count;
  }
}

public class InvalidNucleotideException : Exception { }