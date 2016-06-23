public class Hamming
{
  public static int Compute(string x, string y)
  {
    int diff = 0;
    for (int i = 0; i < x.Length; i++)
    {
      diff += x[i] != y[i] ? 1 : 0;
    }
    return diff;
  }
}