using System;
using System.Linq;

public class Squares
{
  private int squares;
  private int[] range;

  public Squares(int value)
  {
    if (value < 0) 
    {  
      throw new ArgumentException("Input must be greater than or equal to 0.");
    }
    
    squares = value;
    range = Enumerable.Range(1, value).ToArray();
  }

  public int SquareOfSums()
  {
    return squares == 0 ? 0 : (int)Math.Pow(range.Aggregate((a, b) => a + b), 2);
  }

  public int SumOfSquares()
  {
    return squares == 0 ? 0 : (int)range.Select(x => Math.Pow(x, 2)).Sum();
  }

  public int DifferenceOfSquares()
  {
    return SquareOfSums() - SumOfSquares();
  }
}
