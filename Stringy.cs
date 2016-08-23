using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OneUpside.Data
{
  public static class Stringy
  {

    private static Regex Spaces = new Regex("\\s+");

    public static string FromEnumerable(IEnumerable<char> characters)
    {
      var output = new StringBuilder();
      foreach (var c in characters)
      {
        output.Append(c);
      }
      return output.ToString();
    }

    public static string Concat(IEnumerable<string> strings)
    {
      Contract.Ensures(Contract.Result<string>() != null);
      var builder = new StringBuilder();
      foreach (var s in strings)
      {
        builder.Append(s);
      }
      var output = builder.ToString();
      Contract.Assert(output != null);
      return output;
    }

    /// <summary>
    /// Split a string into a first and last name.
    /// </summary>
    /// <param name="source">Source string.</param>
    /// <returns>(firstName, lastName)</returns>
    public static Tuple<string, string> SplitFirstAndLastNames(string source)
    {
      Contract.Requires(source != null);
      Contract.Ensures
        ( Contract.Result<Tuple<string, string>>().Item1 != null
          && Contract.Result<Tuple<string, string>>().Item2 != null
        );
      var parts = Spaces.Split(source).Where(p => !string.IsNullOrEmpty(p));
      return Tuple.Create
        ( parts.Take(1).FirstOrDefault()
        , Concat(parts.Skip(1).Intersperse(" "))
        );
    }

  }

}
