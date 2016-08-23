using System;
using System.Diagnostics.Contracts;

namespace OneUpside.Data
{
  using static Helper;

  /// <summary>
  /// Indicates a missing case in a switch statement that was intended to be exhaustive.
  /// </summary>
  public class CaseException : Exception
  {
    /// <summary>
    /// The case that was missed.
    /// </summary>
    public readonly object TheCase;

    /// <summary>
    /// The type the case logically pertains to. This may simply be the type of <see cref="TheCase"/> but may be a different type.
    /// </summary>
    public readonly Type TheType;

    /// <summary>
    /// Constructs a <see cref="CaseException"/>.
    /// </summary>
    /// <param name="theCase">Assigned to <see cref="TheCase"/>.</param>
    /// <param name="theType">Assigned to <see cref="TheType"/>.</param>
    [Pure]
    public CaseException(object theCase, Type theType)
      : base($"missing case '{theCase}' for type '{theType.FullName}'")
    {
      Assume(theType != null);
      TheCase = theCase;
      TheType = theType;
      Assert(TheCase == theCase && TheType == theType);
    }
    
  }

}
