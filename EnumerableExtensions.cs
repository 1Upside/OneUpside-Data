using System;
using System.Collections.Generic;
using System.Linq;

namespace OneUpside.Data
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<A> WhereLeft<A, B>
      ( this IEnumerable<Either<A, B>> source
      )
    {
      return source
        .Where(x => x.IsLeft)
        .Select
        ( x =>
            x.Cases
            ( y => y
            , _ => { throw new Exception("impossible"); }
            )
        );
    }

    public static IEnumerable<B> WhereRight<A, B>
      ( this IEnumerable<Either<A, B>> source
      )
    {
      return source
        .Where(x => x.IsRight)
        .Select
        ( x =>
            x.Cases
            ( _ => { throw new Exception("impossible"); }
            , y => y
            )
        );
    }

    public static Either<A, IEnumerable<B>> Sequence<A, B>
      ( this IEnumerable<Either<A, B>> source
      )
    {
      // Rebuild in reverse order. It is assumed that x.Concat(y) has time
      // complexity O(x.Count()).
      return source.Aggregate
        ( Either.Left<A>.Right(Enumerable.Empty<B>())
        , (acc, x) =>
            acc.BindRight
            ( prev =>
                x.Cases
                ( Either.Right<IEnumerable<B>>.Left
                , rest =>
                    Either.Left<A>.Right
                    ( Enumerable.Repeat(rest, 1).Concat(prev)
                    )
                )
            )
        )
        // Now reverse to the correct order.
        .MapRight(Enumerable.Reverse);
    }

    /// <summary>
    /// The enumerable of <paramref name="source"/> with 
    /// <paramref name="item"/> between the elements.
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <param name="source"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public static IEnumerable<A> Intersperse<A>
      ( this IEnumerable<A> source
      , A item
      )
    {
      var it = source.GetEnumerator();
      if (it.MoveNext())
      {
        yield return it.Current;
        while (it.MoveNext())
        {
          yield return item;
          yield return it.Current;
        }
      }
    }

    /// <summary>
    /// True iff <paramref name="x"/> has no elements.
    /// </summary>
    public static bool IsEmpty<A>(this IEnumerable<A> x)
    {
      foreach (var _ in x)
      {
        return false;
      }
      return true;
    }

    /// <summary>
    /// The first element if <paramref name="xs"/> is non-empty or <paramref name="default_"/> if it is.
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <param name="xs">Must not be null.</param>
    /// <param name="default_"></param>
    /// <returns></returns>
    public static A FirstOrDefault<A>
      ( this IEnumerable<A> xs
      , A default_
      )
    {
      return xs.IsEmpty() ? default_ : xs.First();
    }

    /// <summary>
    /// Only the Just-values in a list of <see cref="Maybe{A}"/>'s.
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <param name="xs"></param>
    /// <returns></returns>
    public static IEnumerable<A> WhereJust<A>(this IEnumerable<Maybe<A>> xs)
    {
      return xs
        .Where(x => x.IsJust)
        .Select
        ( x => 
            x.Cases
            ( () => { throw new Exception("impossible!"); }
            , y => y
            )
        );
    }

  }

}
