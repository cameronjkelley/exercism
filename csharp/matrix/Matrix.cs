using System.Linq;

public class Matrix
{
  private int[][] rows;

  public Matrix(string input)
  {
    rows = CreateRows(input);
  }

  public int[] Row(int number)
  {
    return rows[number];
  }

  public int[] Col(int number)
  {
    return rows.Select(row => row[number]).ToArray();
  }

  public int Rows
  {
    get
    {
      return rows.Length;
    }
  }

  public int Cols
  {
    get
    {
      return rows[0].Length;
    }
  }

  private int[][] CreateRows(string matrix)
  {
    return matrix.Split('\n').Select(ParseRow).ToArray();
  }

  private int[] ParseRow(string row)
  {
    return row.Split(' ').Select(int.Parse).ToArray();
  }
}
