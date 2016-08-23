using System;

namespace OneUpside.Data
{

  public sealed class RefObject<A>
  {

    private readonly Func<A> Getter;

    private readonly Action<A> Setter;

    public RefObject(Func<A> getter, Action<A> setter)
    {
      Getter = getter;
      Setter = setter;
    }

    public A Value
    {
      get { return Getter(); }
      set { Setter(value); }
    }

  }

}
