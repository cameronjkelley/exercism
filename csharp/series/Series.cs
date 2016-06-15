using System;
using System.Collections.Generic;
using System.Linq;

public class Series
{
  private string _series;

  public Series(string input)
  {
    _series = input;
  }

  public int[][] Slices(int sliceLength)
  {
    if (sliceLength > _series.Length)
    {
      throw new ArgumentException("The length of a slice cannot exceed the length of the series.");
    }

    var result = new List<int[]>();

    for (int i = 0; i + sliceLength - 1 < _series.Length; i++)
    {
      result.Add(SplitSeries(_series.Substring(i, sliceLength)));
    }
    return result.ToArray();
  }

  private int[] SplitSeries(string input)
  {
    return input.Select(x => int.Parse(x.ToString())).ToArray();
  }
}