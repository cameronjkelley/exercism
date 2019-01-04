using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        return Regex.Replace(input, @"(.)\1+", match => $"{match.Length}{match.Value[0]}");
    }

    public static string Decode(string input)
    {
        return Regex.Replace(input, @"\d+.", match =>
            new string(
                match.Value[match.Value.Length - 1],
                int.Parse(match.Value.Substring(0, match.Value.Length - 1))
            )
         );
    }
}
