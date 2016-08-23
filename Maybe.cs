namespace OneUpside.Data
{
  public static class Maybe
  {

    public static Maybe<A> Nothing<A>()
    {
      return new Maybe<A>();
    }

    public static Maybe<A> Just<A>(A value)
    {
      return new Maybe<A>(value);
    }

    public static Maybe<A> FromNullable<A>(A? x)
      where A : struct
    {
      if (x.HasValue)
      {
        return new Maybe<A>(x.Value);
      }
      else
      {
        return new Maybe<A>();
      }
    }

    public static A? ToNullable<A>(Maybe<A> x)
      where A : struct
    {
      return x.Cases<A?>(() => null, v => v);
    }

    public static Maybe<A> FromNull<A>(A x)
      where A : class
    {
      return x == null ? Nothing<A>() : Just(x);
    }

    public static A ToNull<A>(Maybe<A> x)
      where A : class
    {
      return x.Cases(() => null, v => v);
    }

  }

}
