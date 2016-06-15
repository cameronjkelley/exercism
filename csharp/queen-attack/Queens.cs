using System;

public class Queen
{
  public int Rank { get; private set; }
  public int File { get; private set; }

  public Queen(int x, int y)
  {
    Rank = x;
    File = y;
  }
}

public class Queens
{
  private static Queen White { get; set; }
  private static Queen Black { get; set; }

  public Queens(Queen white, Queen black)
  {
    White = white;
    Black = black;

    if (White.Rank == Black.Rank && White.File == Black.File)
    {
      throw new ArgumentException();
    }
  }

  public bool CanAttack()
  {
    return horizontal() || vertical() || diagonal();
  }

  private static bool horizontal()
  {
    return White.Rank == Black.Rank;
  }

  private static bool vertical()
  {
    return White.File == Black.File;
  }

  private static bool diagonal()
  {
    return Math.Abs(Black.File - White.File) == Math.Abs(Black.Rank - White.Rank);
  }
}