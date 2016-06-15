using System.Collections.Generic;

public class ETL
{
  public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> input)
  {
    Dictionary<string, int> output = new Dictionary<string, int>();
    foreach (int key in input.Keys)
    {
      IList<string> values = input[key];
      foreach (string value in values)
      {
        output[value.ToLower()] = key;
      }
    }
    return output;
  }
}
