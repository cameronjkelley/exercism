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
			throw new ArgumentException();
	}
	
	public bool CanAttack()
	{
		return White.Rank == Black.Rank || White.File == Black.File || 
		Math.Abs(White.Rank - Black.Rank) == Math.Abs(White.File - Black.File);
	}
}
