using System;
using System.Collections.Generic;

public class DNA
{
	public Dictionary<char, int> NucleotideCounts { get; private set; }

	public DNA(string input)
	{
		SetNucleotideCounts(input);
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

	private void SetNucleotideCounts(string strand)
	{
		NucleotideCounts = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };

		foreach (char x in strand)
		{
			NucleotideCounts[x] += 1;
		}
	}
}

public class InvalidNucleotideException : Exception { }
