using System;

namespace OneUpside.Data
{

  /// <summary>
  /// Extension methods for <see cref="Either{A, B}"/> and related functions.
  /// </summary>
  public static class Either
  {
    /// <summary>
    /// Map the Left-value.
    /// </summary>
    /// <remarks>
    ///   (flip Either B, MapLeft) forms a functor.
    /// </remarks>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="B"></typeparam>
    /// <typeparam name="C"></typeparam>
    /// <param name="thiz"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Either<C,B> MapLeft<A,B,C>
      ( this Either<A,B> thiz
      , Func<A,C> f
      )
    {
      return thiz.Cases(a => new Either<C,B>(f(a)), b => new Either<C,B>(b));
    }

    /// <summary>
    /// Map the Right-value.
    /// </summary>
    /// <remarks>
    ///   (Either A, MapRight) forms a functor.
    /// </remarks>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="B"></typeparam>
    /// <typeparam name="C"></typeparam>
    /// <param name="thiz"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Either<A,C> MapRight<A,B,C>
      ( this Either<A,B> thiz
      , Func<B,C> f
      )
    {
      return thiz.Cases(a => new Either<A,C>(a), b => new Either<A,C>(f(b)));
    }

    /// <summary>
    /// Map both the Left-value and Right-value.
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="B"></typeparam>
    /// <typeparam name="C"></typeparam>
    /// <typeparam name="D"></typeparam>
    /// <param name="thiz"></param>
    /// <param name="f"></param>
    /// <param name="g"></param>
    /// <returns></returns>
    public static Either<C,D> Map<A,B,C,D>
      ( this Either<A,B> thiz
      , Func<A,C> f
      , Func<B,D> g
      )
    {
      return thiz.Cases
        ( a => new Either<C,D>(f(a))
        , b => new Either<C,D>(g(b))
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="B"></typeparam>
    /// <typeparam name="C"></typeparam>
    /// <param name="thiz"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Either<C,B> BindLeft<A,B,C>
      ( this Either<A,B> thiz
      , Func<A,Either<C,B>> f
      )
    {
      return thiz.Cases(f, b => new Either<C,B>(b));
    }

    public static Either<A,C> BindRight<A,B,C>
      ( this Either<A,B> thiz
      , Func<B,Either<A,C>> f
      )
    {
      return thiz.Cases(a => new Either<A,C>(a), f);
    }

    public static A Reduce<A>(this Either<A,A> t)
    {
      return t.Cases(x => x, x => x);
    }

    public static class Left<A>
    {
      public static Either<A,B> Right<B>(B right)
      {
        return new Either<A, B>(right);
      }
    }

    public static class Right<B>
    {
      public static Either<A,B> Left<A>(A left)
      {
        return new Either<A, B>(left);
      }
    }
    
  }

}
