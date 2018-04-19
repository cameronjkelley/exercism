using System;
using System.Collections.Generic;

class OcrNumbers
{
	public static string Convert(string input)
	{
		string[] inputArray = input.Split('\n');
		string[] outputArray = new string[inputArray[0].Length];
		
		for (int i = 0; i < inputArray.Length - 1; i++)
		{
			int counter = 0;
			
			for (int j = 0; j < inputArray[i].Length; j += 3)
			{
				counter++;
				string temp = "";
				
				for (int k = 0; k < 3; k++)
				{
					temp += inputArray[i][j + k];
				}
				
				outputArray[counter] += temp;
			}
		}

		string numbers = "";
		foreach (string num in outputArray)
		{
			if (!string.IsNullOrEmpty(num))
			{
				numbers += Numbers.ContainsKey(num) ? Numbers[num] : "?";
			}
		}
		
		return numbers;
	}

	private static Dictionary<string, string> Numbers = new Dictionary<string, string> {
		{ " _ | ||_|", "0" }, { "     |  |", "1" },
		{ " _  _||_ ", "2" }, { " _  _| _|", "3" },
		{ "   |_|  |", "4" }, { " _ |_  _|", "5" },
		{ " _ |_ |_|", "6" }, { " _   |  |", "7" },
		{ " _ |_||_|", "8" }, { " _ |_| _|", "9" }
	};
}
