using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        return new Regex(@"(.)\1+").Replace(input, match => $"{match.Length}{match.Value[0]}");
    }

    public static string Decode(string input)
    {
        return new Regex(@"\d+.").Replace(input, match => 
            new string(
                match.Value[match.Value.Length - 1],
                int.Parse(match.Value.Substring(0, match.Value.Length - 1))
            )
         );
    }
}
