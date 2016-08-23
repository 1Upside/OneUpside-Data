using System;

namespace OneUpside.Data
{

  public static class RefObject
  {

    public static RefObject<A> Create<A>(Func<A> getter, Action<A> setter)
    {
      return new RefObject<A>(getter, setter);
    }

  }

}
