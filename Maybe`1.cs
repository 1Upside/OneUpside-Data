using System;
using System.Runtime.Serialization;

namespace OneUpside.Data
{
  [DataContract]
  public struct Maybe<A>
  {
    private const bool TAG_NOTHING = default(bool);

    private const bool TAG_JUST = !default(bool);

    [DataMember]
    private readonly bool Tag;

    [DataMember]
    private readonly A Value;

    public Maybe(A value)
    {
      Tag = TAG_JUST;
      Value = value;
    }

    public bool IsJust { get { return Tag == TAG_JUST; } }

    public bool IsNothing { get { return Tag == TAG_NOTHING; } }

    public static bool operator ==(Maybe<A> a, Maybe<A> b)
    {
      return Equals(a, b);
    }

    public static bool operator !=(Maybe<A> a, Maybe<A> b)
    {
      return !Equals(a, b);
    }

    public Maybe<B> Map<B>(Func<A,B> f)
    {
      switch (Tag)
      {
        case TAG_JUST:
          return new Maybe<B>(f(Value));
        case TAG_NOTHING:
          return new Maybe<B>();
        default:
          throw new CaseException(Tag, typeof(Maybe<A>));
      }
    }

    public Maybe<B> Bind<B>(Func<A,Maybe<B>> f)
    {
      switch (Tag)
      {
        case TAG_JUST:
          return f(Value);
        case TAG_NOTHING:
          return new Maybe<B>();
        default:
          throw new CaseException(Tag, typeof(Maybe<A>));
      }
    }

    public B Cases<B>(Func<B> nothingCase, Func<A,B> justCase)
    {
      switch (Tag)
      {
        case TAG_JUST:
          return justCase(Value);
        case TAG_NOTHING:
          return nothingCase();
        default:
          throw new CaseException(Tag, typeof(Maybe<A>));
      }
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Maybe<A>))
      {
        return false;
      }
      var b = (Maybe<A>)obj;
      switch (Tag)
      {
        case TAG_JUST:
          switch (b.Tag)
          {
            case TAG_JUST:
              return Equals(Value, b.Value);
            case TAG_NOTHING:
              return false;
            default:
              throw new CaseException(Tag, typeof(Maybe<A>));
          }
        case TAG_NOTHING:
          switch (b.Tag)
          {
            case TAG_JUST:
              return false;
            case TAG_NOTHING:
              return true;
            default:
              throw new CaseException(Tag, typeof(Maybe<A>));
          }
        default:
          throw new CaseException(Tag, typeof(Maybe<A>));
      }
    }

    public override int GetHashCode()
    {
      switch (Tag)
      {
        case TAG_JUST:
          return Value == null ? 0 : Value.GetHashCode();
        case TAG_NOTHING:
          return ~0;
        default:
          throw new CaseException(Tag, typeof(Maybe<A>));
      }
    }

    public override string ToString()
    {
      switch (Tag)
      {
        case TAG_JUST:
          return $"Just({Value})";
        case TAG_NOTHING:
          return $"Nothing<{typeof(A).FullName}>()";
        default:
          throw new CaseException(Tag, typeof(Maybe<A>));
      }
    }

  }
  
}
