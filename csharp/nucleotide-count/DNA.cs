using System;
using System.Collections.Generic;

public class DNA
{
	public Dictionary<char, int> NucleotideCounts { get; private set; }

	public DNA(string input)
	{
		SetNucleotideCounts(input);
	}

	public int Count(char c)
	{
		if (!NucleotideCounts.ContainsKey(c))
			throw new InvalidNucleotideException();
		return NucleotideCounts[c];
	}

	private void SetNucleotideCounts(string strand)
	{
		NucleotideCounts = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
		foreach (char c in strand)
		{
			NucleotideCounts[c]++;
		}
	}
}

public class InvalidNucleotideException : Exception { }
