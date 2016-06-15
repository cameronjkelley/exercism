public class Raindrops
{
  public static string Convert(int input)
  {
    string result = "";

    if (input % 3 == 0)
      result += "Pling";
    if (input % 5 == 0)
      result += "Plang";
    if (input % 7 == 0)
      result += "Plong";

    return string.IsNullOrEmpty(result) ? input.ToString() : result;
  }
}