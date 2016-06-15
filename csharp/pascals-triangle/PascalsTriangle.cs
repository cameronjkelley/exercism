using System.Collections.Generic;

public class PascalsTriangle
{
  public static List<List<int>> Calculate(int number)
  {
    List<List<int>> rows = new List<List<int>>();
    rows.Add(new List<int>() { 1 });
    for (int i = 1; i < number; i++)
    {
      List<int> row = new List<int>();
      row.Add(1);
      for (int j = 1; j < i; j++)
      {
        if (i > 1)
        {
          row.Add(rows[i - 1][j - 1] + rows[i - 1][j]);
        }
      }
      row.Add(1);
      rows.Add(row);
    }
    return rows;
  }
}
