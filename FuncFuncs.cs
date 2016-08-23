using System;

namespace OneUpside.Data
{
  /// <summary>
  /// Common higher-order functions.
  /// </summary>
  public static class FuncFuncs
  {
    public static A Id<A>(A x)
    {
      return x;
    }

    public static A Const<A,B>(A x, B y)
    {
      return x;
    }

    public static B Apply<A,B>(Func<A, B> f, A x)
    {
      return f(x);
    }
    
    public static Func<B,Func<A,C>> Flip<A,B,C>(Func<A,Func<B,C>> f)
    {
      return b => a => f(a)(b);
    } 

    public static Func<B,A,C> Flip<A,B,C>(Func<A,B,C> f)
    {
      return (b, a) => f(a, b);
    }

    public static Func<A,Func<B,C>> Curry<A,B,C>(Func<A,B,C> f)
    {
      return a => b => f(a, b);
    }

    public static Func<A,Func<B,Func<C,D>>> Curry3<A,B,C,D>(Func<A,B,C,D> f)
    {
      return a => b => c => f(a, b, c);
    }

    public static Func<A,B,C> Uncurry<A,B,C>(Func<A,Func<B,C>> f)
    {
      return (a, b) => f(a)(b);
    }

    public static Func<A,B,C,D> Uncurry3<A,B,C,D>(Func<A,Func<B,Func<C,D>>> f)
    {
      return (a, b, c) => f(a)(b)(c);
    }

    public static Func<A,C> Compose<A,B,C>(Func<B,C> g, Func<A,B> f)
    {
      return a => g(f(a));
    }
    
    public static Func<A,C> Ap<A,B,C>(Func<A,Func<B,C>> f, Func<A,B> g)
    {
      return a => f(a)(g(a));
    }

    public static Func<A,C> Ap<A,B,C>(Func<A,B,C> f, Func<A,B> g)
    {
      return a => f(a, g(a));
    }

    public static Func<A,C> Bind<A,B,C>(Func<A,B> f, Func<B,Func<A,C>> g)
    {
      return a => g(f(a))(a);
    }

    public static Func<A,C> Bind<A,B,C>(Func<A,B> f, Func<B,A,C> g)
    {
      return a => g(f(a), a);
    }

    public static Func<A,B> Join<A,B>(Func<A,Func<A,B>> f)
    {
      return a => f(a)(a);
    }

    public static Func<A,B> Join<A,B>(Func<A,A,B> f)
    {
      return a => f(a, a);
    }

    public static A Fix<A>(Func<Func<A>,A> f)
    {
      return f(() => Fix(f));
    }

  }
}
