using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Tournament
{
	public static void Tally(MemoryStream inStream, MemoryStream outStream)
	{
		Dictionary<string, Dictionary<string, int>> tally = new Dictionary<string, Dictionary<string, int>>();

		var encoding = new System.Text.UTF8Encoding();
		using (StreamReader reader = new StreamReader(inStream, encoding))
		{
			while (reader.Peek() >= 0)
			{
				string[] line = reader.ReadLine().Trim().Split(';');
				if (line.Length == 3 && ValidOutcome(line[2]))
				{
					string home = line[0], away = line[1], outcome = line[2];

					if (!tally.ContainsKey(home))
						tally.Add(home, new Dictionary<string, int> { { "MP", 0 }, { "W", 0 }, { "D", 0 }, { "L", 0 }, { "P", 0 } });
					if (!tally.ContainsKey(away))
						tally.Add(away, new Dictionary<string, int> { { "MP", 0 }, { "W", 0 }, { "D", 0 }, { "L", 0 }, { "P", 0 } });

					switch(outcome)
					{
						case "win":
							tally[home]["W"]++;
							tally[away]["L"]++;
							break;
						case "loss":
							tally[away]["W"]++;
							tally[home]["L"]++;
							break;
						case "draw":
							tally[home]["D"]++;
							tally[away]["D"]++;
							break;
					}

					tally[home]["P"] = tally[home]["W"] * 3 + tally[home]["D"];
					tally[away]["P"] = tally[away]["W"] * 3 + tally[away]["D"];
				}
			}
		}

		List<KeyValuePair<string, Dictionary<string, int>>> tallyList = tally.ToList();
		tallyList.Sort((x, y) => y.Value["P"].CompareTo(x.Value["P"]));

		var writer = new StreamWriter(outStream, encoding);
		writer.Write(FormatTally(tallyList));
		writer.Close();
	}

	private static bool ValidOutcome(string outcome)
	{
		return outcome == "win" || outcome == "draw" || outcome == "loss";
	}

	private static string FormatTally(List<KeyValuePair<string, Dictionary<string, int>>> tallyList)
	{
		string table = "Team".PadRight(31) + "| MP |  W |  D |  L |  P";
		foreach (KeyValuePair<string, Dictionary<string, int>> team in tallyList)
		{
			team.Value["MP"] = team.Value["W"] + team.Value["D"] + team.Value["L"];
			table += "\r\n" + $"{team.Key.PadRight(31)}" + $"|  {team.Value["MP"]} |  {team.Value["W"]} |  {team.Value["D"]} |  {team.Value["L"]} |  {team.Value["P"]}";
		}
		return table;
	}
}
