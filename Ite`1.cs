using System;

namespace OneUpside.Data
{

  public struct Ite<A>
  {
    private enum Tag
    {
      ProduceThen,
      ProduceElse
    }

    private readonly Tag TheTag;

    private readonly A Value;

    private Ite(Tag theTag, A value)
    {
      TheTag = theTag;
      Value = value;
    }

    public Ite<A> Else(Func<Ite<A>> ite)
    {
      switch (TheTag)
      {
        case Tag.ProduceThen:
          return this;
        case Tag.ProduceElse:
          return ite();
        default:
          throw new CaseException(TheTag, typeof(Tag));
      }
    }

    public Ite<A> Else(Ite<A> ite)
    {
      switch (TheTag)
      {
        case Tag.ProduceThen:
          return this;
        case Tag.ProduceElse:
          return ite;
        default:
          throw new CaseException(TheTag, typeof(Tag));
      }
    }

    public A Else(Func<A> otherwise)
    {
      switch (TheTag)
      {
        case Tag.ProduceThen:
          return Value;
        case Tag.ProduceElse:
          return otherwise();
        default:
          throw new CaseException(TheTag, typeof(Tag));
      }
    }

    public A Else(A otherwise)
    {
      switch (TheTag)
      {
        case Tag.ProduceThen:
          return Value;
        case Tag.ProduceElse:
          return otherwise;
        default:
          throw new CaseException(TheTag, typeof(Tag));
      }
    }

    public static Ite<A> ProduceThen(A value)
    {
      return new Ite<A>(Tag.ProduceThen, value);
    }

    public static Ite<A> ProduceElse()
    {
      return new Ite<A>(Tag.ProduceElse, default(A));
    }
      
  }

}
