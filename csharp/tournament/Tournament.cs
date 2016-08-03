using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Tournament
{
	public static void Tally(MemoryStream inStream, MemoryStream outStream)
	{
		Dictionary<string, Dictionary<string, int>> tally = EmptyTally();

		var encoding = new System.Text.UTF8Encoding();
		var reader = new StreamReader(inStream, encoding);

		for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
		{
			string[] parts = line.Trim().Split(';');
			if (parts.Length == 3)
			{
				string home = parts[0], away = parts[1], outcome = parts[2];
				if (ValidTeam(home) && ValidTeam(away) && ValidOutcome(outcome))
				{
					if (outcome == "win")
					{
						tally[home]["P"] += 3;
						tally[home]["W"]++;
						tally[away]["L"]++;
					}
					else if (outcome == "loss")
					{
						tally[away]["P"] += 3;
						tally[away]["W"]++;
						tally[home]["L"]++;
					}
					else
					{
						tally[home]["P"]++;
						tally[home]["D"]++;
						tally[away]["P"]++;
						tally[away]["D"]++;
					}
				}
			}
		}

		List<KeyValuePair<string, Dictionary<string, int>>> tallyList = tally.ToList();
		tallyList.Sort((x, y) => y.Value["P"].CompareTo(x.Value["P"]));

		var writer = new StreamWriter(outStream, encoding);
		writer.Write(FormatTally(tallyList));
		writer.Close();
	}

	private static string[] Teams = new string[]
	{
			"Allegoric Alaskans", "Blithering Badgers", "Courageous Californians", "Devastating Donkeys"
	};

	private static string[] Outcomes = new string[]
	{
			"win", "draw", "loss"
	};

	private static Dictionary<string, Dictionary<string, int>> EmptyTally()
	{
		Dictionary<string, Dictionary<string, int>> tally = new Dictionary<string, Dictionary<string, int>>();
		foreach (string team in Teams)
		{
			tally.Add(team, new Dictionary<string, int> { { "MP", 0 }, { "W", 0 }, { "D", 0 }, { "L", 0 }, { "P", 0 } });
		}
		return tally;
	}

	private static bool ValidTeam(string team)
	{
		return Teams.Contains(team);
	}

	private static bool ValidOutcome(string outcome)
	{
		return Outcomes.Contains(outcome);
	}

	private static string FormatTally(List<KeyValuePair<string, Dictionary<string, int>>> tally)
	{
		string table = "Team".PadRight(31) + "| MP |  W |  D |  L |  P";
		foreach (KeyValuePair<string, Dictionary<string, int>> team in tally)
		{
			team.Value["MP"] = team.Value["W"] + team.Value["D"] + team.Value["L"];
			table += "\r\n" + $"{team.Key.PadRight(31)}" + $"|  {team.Value["MP"]} |  {team.Value["W"]} |  {team.Value["D"]} |  {team.Value["L"]} |  {team.Value["P"]}";
		}
		return table;
	}
}