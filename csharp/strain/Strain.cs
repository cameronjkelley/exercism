using System;
using System.Collections.Generic;

public static class Strain
{
  public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
  {
    return Filter(collection, predicate);
  }

  public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
  {
    return Filter(collection, x => !predicate(x));
  }

  private static IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> predicate)
  {
    List<T> result = new List<T>();
    foreach (T item in source)
    {
      if (predicate(item))
      {
        result.Add(item);
      }
    }
    return result;
  }
}
