public class Beer
{
  public static string Verse(int number)
  {
    switch (number)
    {
      case 0:
        return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n";
      case 1:
        return "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n";
      case 2:
        return "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n";
      default:
        return $"{number} bottles of beer on the wall, {number} bottles of beer.\nTake one down and pass it around, {number - 1} bottles of beer on the wall.\n";
    }
  }

  public static string Sing(int start, int stop)
  {
    string song = "";
    for (int i = start; i >= stop; i--)
    {
      song += Verse(i) + "\n";
    }
    return song;
  } 
}
