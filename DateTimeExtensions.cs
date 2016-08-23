using System;
using System.Diagnostics.Contracts;

namespace OneUpside.Data
{
  /// <summary>
  /// Extension methods for <see cref="DateTime"/>.
  /// </summary>
  public static class DateTimeExtensions
  {

    /// <summary>
    ///   Equal iff <paramref name="a" /> and <paramref name="b" /> denote the same time once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>.
    /// </summary>
    /// <remarks>
    ///   <see cref="ExtensionalEqual(DateTime, DateTime)"/> is an equivalence relation.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalEqual(this DateTime a, DateTime b)
    {
      return a - b == a.RelativeOffset(b);
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> and <paramref name="b" /> denote the same time once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>. <c>null</c> is equal to itself.
    /// </summary>
    /// <remarks>
    ///   <see cref="ExtensionalEqual(DateTime, DateTime)"/> is an equivalence relation.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalEqual(this DateTime? a, DateTime? b)
    {
      return a.HasValue && b.HasValue && a.Value.ExtensionalEqual(b.Value)
        || !a.HasValue && !b.HasValue;
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time less than <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>.
    /// </summary>
    /// <remarks>
    ///  <see cref="ExtensionalLess(DateTime, DateTime)"/> is a total order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalLess(this DateTime a, DateTime b)
    {
      return a - b < a.RelativeOffset(b);
    }
    
    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time less than <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>. <c>null</c> is strictly less than all other values and equal to itself.
    /// </summary>
    /// <remarks>
    ///  <see cref="ExtensionalLess(DateTime?, DateTime?)"/> is a total order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalLess(this DateTime? a, DateTime? b)
    {
      return a.HasValue && b.HasValue && a.Value.ExtensionalLess(b.Value)
        || !a.HasValue && b.HasValue;
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time less than or equal to <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>. 
    /// </summary>
    /// <remarks>
    ///   <see cref="ExtensionalLessOrEqual(DateTime, DateTime)"/> is a strict weak order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalLessOrEqual(this DateTime a, DateTime b)
    {
      return a - b <= a.RelativeOffset(b);
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time less than or equal to <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>. <c>null</c> is strictly less than all other values and equal to itself.
    /// </summary>
    /// <remarks>
    ///   <see cref="ExtensionalLessOrEqual(DateTime, DateTime)"/> is a strict weak order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalLessOrEqual
      ( this DateTime? a
      , DateTime? b
      )
    {
      return 
        a.HasValue && b.HasValue && a.Value.ExtensionalLessOrEqual(b.Value)
        || !a.HasValue;
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time greater than <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>.
    /// </summary>
    /// <remarks>
    ///  <see cref="ExtensionaGreater(DateTime, DateTime)"/> is a total order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalGreater(this DateTime a, DateTime b)
    {
      return a - b > a.RelativeOffset(b);
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time greater than <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>. <c>null</c> is strictly less than all other values and equal to itself.
    /// </summary>
    /// <remarks>
    ///  <see cref="ExtensionalGreater(DateTime?, DateTime?)"/> is a total order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalGreater(this DateTime? a, DateTime? b)
    {
      return 
        a.HasValue && b.HasValue && a.Value.ExtensionalGreater(b.Value)
        || a.HasValue && !b.HasValue;
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time greater than or equal to <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>.
    /// </summary>
    /// <remarks>
    ///   <see cref="ExtensionalGreaterOrEqual(DateTime, DateTime)"/> is a strict weak order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalGreaterOrEqual
      ( this DateTime a
      , DateTime b
      )
    {
      return a - b >= a.RelativeOffset(b);
    }

    /// <summary>
    ///   Equal iff <paramref name="a" /> denotes a time greater than or equal to <paramref name="b" /> once both are converted to UTC. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>. <c>null</c> is strictly less than all other values but equal to itself.
    /// </summary>
    /// <remarks>
    ///   <see cref="ExtensionalGreaterOrEqual(DateTime?, DateTime?)"/> is a strict weak order.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static bool ExtensionalGreaterOrEqual
      ( this DateTime? a
      , DateTime? b
      )
    {
      return 
           a.HasValue 
           && b.HasValue 
           && a.Value.ExtensionalGreaterOrEqual(b.Value)
        || !b.HasValue;
    }

    /// <summary>
    ///   The <see cref="TimeZoneInfo"/> denoted by the <see cref="DateTime.Kind"/> property of <paramref name="a" />. <see cref="DateTimeKind.Unspecified"/> is equivalent to <see cref="DateTimeKind.Local"/>.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    [Pure]
    public static TimeZoneInfo GetTimeZoneInfo(this DateTime a)
    {
      Contract.Ensures(Contract.Result<TimeZoneInfo>() != null);
      switch (a.Kind)
      {
        case DateTimeKind.Local:
          return TimeZoneInfo.Local;
        case DateTimeKind.Utc:
          return TimeZoneInfo.Utc;
        default:
          return TimeZoneInfo.Local;
      }
    }

    /// <summary>
    /// The <see cref="TimeSpan" /> between <paramref name="a" /> and <paramref name="b" /> once both are converted to UTC.
    /// </summary>
    /// <remarks>
    ///   <list type="bullet">
    ///     <item>
    ///       <description>
    ///         <term><see cref="DateTime"/>'s with the same <see cref="DateTime.Kind"/> have a zero relative offset.</term>
    ///         <code><![CDATA[(a.Kind == b.Kind) == (a.RelativeOffset(b) == TimeSpan.FromTicks(0))]]></code>
    ///       </description>
    ///     </item>
    ///     <item>
    ///       <term>Anticommutative</term>
    ///       <description>
    ///         <code><![CDATA[a.RelativeOffset(b) == -(b.RelativeOffset(a))]]></code>
    ///       </description>
    ///     </item>
    ///   </list>
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [Pure]
    public static TimeSpan RelativeOffset(this DateTime a, DateTime b)
    {
      return
        a.GetTimeZoneInfo().BaseUtcOffset
        - b.GetTimeZoneInfo().BaseUtcOffset;
    }

  }
}
