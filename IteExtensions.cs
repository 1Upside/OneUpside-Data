using System;

namespace OneUpside.Data
{
  public static class IteExtensions
  {
    public static Ite<C> Is<A,B,C>(this A a, Func<B,C> f)
      where B : A
    {
      return a is B ? Ite.ProduceThen(f((B)a)) : Ite.ProduceElse<C>();
    }

  }

}
