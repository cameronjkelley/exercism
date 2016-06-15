public class Hamming
{
  public static int Compute(string x, string y)
  {
    int diff = 0;

    for (int i = 0; i < x.Length; i++)
    {
      if (x[i] != y[i])
      {
        diff++;
      }
    }

    return diff;
  }
}
