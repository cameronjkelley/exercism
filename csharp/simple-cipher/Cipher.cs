using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Cipher
{
  private static string alphabet = "abcdefghijklmnopqrstuvwxyz";
  private static Random random = new Random();

  public string Key { get; set; }

  public Cipher()
  {
    Key = ProduceKey();
  }

  public Cipher(string key)
  {
    if (InvalidKey(key)) throw new ArgumentException();
    Key = key;
  }

  public string Encode(string plainText)
  {
    return Translate(plainText, (x, y) => x + y);
  }

  public string Decode(string encodedText)
  {
    return Translate(encodedText, (x, y) => x - y);
	}

	private string ProduceKey()
	{
		return new string(Enumerable.Repeat(alphabet, 100).Select(s => s[random.Next(s.Length)]).ToArray());
	}

	private static bool InvalidKey(string key)
	{
		return key == "" || Regex.IsMatch(key, "[^a-z]");
	}

	private string Translate(string message, Func<int, int, int> createIndex)
  {
    string newMessage = "";
    for (int i = 0; i < message.Length; i++)
    {
      int newIndex = createIndex(alphabet.IndexOf(message[i]), alphabet.IndexOf(Key[i]));

      if (newIndex >= 26) newMessage += alphabet[newIndex - 26];
      else if (newIndex < 0) newMessage += alphabet[newIndex + 26];
      else newMessage += alphabet[newIndex];
    }
    return newMessage;
  }
}
