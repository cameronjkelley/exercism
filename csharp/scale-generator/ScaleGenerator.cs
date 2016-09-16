using System;
using System.Collections.Generic;
using System.Linq;

class ScaleGenerator
{
	private static string[] Flats = { "F", "Ab", "Bb", "Db", "Eb", "Gb", "c", "d", "f", "g", "bb", "eb" };
	private static string[] Notes = { "Ab", "A", "A#", "Bb", "B", "C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#" };

	public static IEnumerable<string> Pitches(string key, string intervals)
	{
		List<string> scale = new List<string> { };
		string[] notes = Flats.Contains(key) ? Notes.Where(x => !x.Contains("#")).ToArray() : Notes.Where(x => !x.Contains("b")).ToArray();
		key = key.Length == 2 ? key[0].ToString().ToUpper() + key[1] : key.ToUpper();
		int idx = Array.IndexOf(notes, key);
		for (int i = 1; i <= intervals.Length; i++)
		{
			if (idx > notes.Length - 1) idx -= notes.Length;
			scale.Add(notes[idx]);
			if (intervals[i - 1] == 'm') idx += 1;
			else if (intervals[i - 1] == 'M') idx += 2;
			else idx += 3;
		}
		return scale.ToArray();
	}
}
