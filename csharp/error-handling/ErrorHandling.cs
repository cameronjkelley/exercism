using System;

class ErrorHandling : Exception
{
  public static void HandleErrorByThrowingException()
  {
    throw new Exception();
  }

  public static int? HandleErrorByReturningNullableType(string input)
  {
    try
    {
      return int.Parse(input);
    }
    catch
    {
      return null;
    }
  }
  public static bool HandleErrorWithOutParam(string x, out int output)
  {
    return int.TryParse(x, out output);
  }
  public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable input)
  {
    using (input)
    {
      throw new Exception();
    }
  }
}
