using System;
using System.Collections.Generic;

public class SecretHandshake
{
  private static Dictionary<string, string> commands = new Dictionary<string, string> {
    { "1", "wink"},
    { "10", "double blink" },
    { "100", "close your eyes" },
    { "1000", "jump" }
  };

  public static string[] Commands (int x)
  {
    List<string> result = new List<string>();
    foreach (KeyValuePair<string, string> command in commands) {
      int key = Convert.ToInt32(command.Key, 2);
      if ((x & key) == key) result.Add(command.Value);
    }
    if (x > (1 << commands.Count)) result.Reverse();
    return result.ToArray();
  }
}
