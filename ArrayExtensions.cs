using System;
using System.Diagnostics.Contracts;

namespace OneUpside.Data
{
  using System.Linq;
  using static Helper;

  /// <summary>
  /// Extension methods for arrays.
  /// </summary>
  public static class ArrayExtensions
  {
    /// <summary>
    ///   Finds the index of the first matching element in the array. If no
    ///   matching element is found then returns -1.
    /// </summary>
    /// <remarks>
    ///   <h4>Requires</h4>
    /// <code><![CDATA[
    /// array != null
    /// ]]></code>
    ///   <h4>Ensures (return value = r)</h4>
    /// <code><![CDATA[
    ///       r == -1
    ///    && !array.Any(x => Equals(x, element))
    /// ||    r < array.Length
    ///    && 0 <= r
    ///    && Equals(array[r], element)
    ///    && !array.Take(r).Any(x => Equals(x, element))
    /// ]]></code>
    /// </remarks>
    /// <typeparam name="A"></typeparam>
    /// <param name="array">Must not be null.</param>
    /// <param name="element"></param>
    /// <returns>An <see cref="int"/> in [-1,<see cref="int.MaxValue"/>].</returns>
    [Pure]
    public static int IndexOf<A>(this A[] array, A element)
    {
      Assume(array != null);
      var ix = Array.IndexOf(array, element);
      Assert
        (       ix == -1
             && !array.Any(x => Equals(x, element))
          ||    ix < array.Length
             && 0 <= ix
             && Equals(array[ix], element)
             && !array.Take(ix).Any(x => Equals(x, element))
        );
      return ix;
    }

  }

}
