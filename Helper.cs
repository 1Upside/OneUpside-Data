using System;

namespace OneUpside.Data
{

  internal static class Helper
  {
    [System.Diagnostics.Conditional("DEBUG")]
    public static void Assume(bool condition)
    {
      System.Diagnostics.Debug.Assert
        ( condition
        , "Assumption violation"
        );
      if (!condition)
      {
        System.Diagnostics.Debugger.Break();
        throw new Exception("Assumption violation");
      }
    }

    [System.Diagnostics.Conditional("DEBUG")]
    public static void Assert(bool condition)
    {
      System.Diagnostics.Debug.Assert
        ( condition
        , "Assertion failed"
        );
      if (!condition)
      {
        System.Diagnostics.Debugger.Break();
        throw new Exception("Assertion failed");
      }
    }
  }

}
