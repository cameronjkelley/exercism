using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class WordProblem
{
  private static List<int> Operands = new List<int>();
  private static List<string> Operators = new List<string>();

  public static int Solve(string problem)
  {
    GetComponents(problem);

    if (Operators.Count == 0 || Operators.Count >= Operands.Count)
      throw new ArgumentException();

    int i = 0;
    do
    {
      Operands[i + 1] = Operation(Operands[i], Operands[i + 1], i);
      i++;
    } while (i < Operands.Count - 1);

    return Operands.Last();
  }

  private static void GetComponents(string input)
  {
    Regex pattern = new Regex(@"plus|minus|multiplied|divided|\d");
    MatchCollection matches = pattern.Matches(input);
    foreach (Match match in matches)
    {
      int num;
      if (Int32.TryParse(match.ToString(), out num))
        Operands.Add(num);
      else
        Operators.Add(match.ToString());
    }
  }

  private static int Operation(int a, int b, int index)
  {
    int result = 0;
    switch (Operators[index])
    {
      case "plus":
        result = a + b;
        break;
      case "minus":
        result = a - b;
        break;
      case "multiplied":
        result = a * b;
        break;
      default:
        result = a / b;
        break;
    }
    return result;
  }
}
