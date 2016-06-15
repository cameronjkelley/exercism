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
    string[] pieces = problem.Split(new char[] { ' ', '?' }, StringSplitOptions.RemoveEmptyEntries);

    GetOperands(pieces);
    GetOperators(pieces);

    if (Operators.Count == 0 || Operators.Count >= Operands.Count)
    {
      throw new ArgumentException();
    }

    int i = 0;
    do
    {
      Operands[i + 1] = Operation(Operands[i], Operands[i + 1], i);
      i++;
    } while (i < Operands.Count - 1);

    return Operands.Last();
  }

  private static void GetOperands(string[] pieces)
  {
    foreach (string piece in pieces)
    {
      int num;
      if (Int32.TryParse(piece, out num))
      {
        Operands.Add(num);
      }
    }
  }

  private static void GetOperators(string[] pieces)
  {
    Regex pattern = new Regex(@"plus|minus|multiplied|divided");
    foreach (string piece in pieces)
    {
      Match match = pattern.Match(piece);
      if (match.Success)
      {
        Operators.Add(match.Value);

      }
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