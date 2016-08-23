using System;

namespace OneUpside.Data
{
  /// <summary>
  /// A sum of two types tagged as Left and Right.
  /// </summary>
  /// <typeparam name="A"></typeparam>
  /// <typeparam name="B"></typeparam>
  public sealed class Either<A,B>
  {

    private readonly Tag TheTag;

    private readonly object Value;

    /// <summary>
    /// Left constructor.
    /// </summary>
    /// <param name="left"></param>
    public Either(A left)
    {
      TheTag = Tag.Left;
      Value = left;
    }
    
    /// <summary>
    /// Right constructor.
    /// </summary>
    /// <param name="right"></param>
    public Either(B right)
    {
      TheTag = Tag.Right;
      Value = right;
    }

    private enum Tag : byte
    { Left  = 0
    , Right = 1
    }

    /// <summary>
    /// True iff this is the Left constructor.
    /// </summary>
    public bool IsLeft { get { return TheTag == Tag.Left; } }

    /// <summary>
    /// True iff this is the Right constructor.
    /// </summary>
    public bool IsRight { get { return TheTag == Tag.Right; } }

    public static bool operator ==(Either<A, B> a, Either<A, B> b)
    {
      return Equals(a, b);
    }

    public static bool operator !=(Either<A, B> a, Either<A, B> b)
    {
      return !Equals(a, b);
    }
    
    /// <summary>
    /// Case analysis.
    /// </summary>
    /// <typeparam name="C"></typeparam>
    /// <param name="caseLeft">Must not be null.</param>
    /// <param name="caseRight">Must not be null.</param>
    /// <returns></returns>
    public C Cases<C>
      ( Func<A,C> caseLeft
      , Func<B,C> caseRight
      )
    {
      switch (TheTag)
      {
        case Tag.Left:
          return caseLeft((A)Value);
        case Tag.Right:
          return caseRight((B)Value);
        default:
          throw new CaseException(TheTag, typeof(Either<A, B>));
      }
    }

    public override bool Equals(object obj)
    {
      var b = obj as Either<A, B>;
      if (b == null)
      {
        return false;
      }
      return Equals(b, null, null);
    }

    public bool Equals
      ( Either<A, B> b
      , Func<A, A, bool> eqL = null
      , Func<B, B, bool> eqR = null
      )
    {
      if (eqL == null)
      {
        eqL = (x, y) => Equals(x, y);
      }
      if (eqR == null)
      {
        eqR = (x, y) => Equals(x, y);
      }
      switch (TheTag)
      {
        case Tag.Left:
          switch (b.TheTag)
          {
            case Tag.Left:
              return eqL((A)Value, (A)b.Value);
            default:
              return false;
          }
        case Tag.Right:
          switch (b.TheTag)
          {
            case Tag.Right:
              return eqR((B)Value, (B)b.Value);
            default:
              return false;
          }
        default:
          throw new CaseException(TheTag, typeof(Either<A, B>));
      }
    }

    public override int GetHashCode()
    {
      var code = Value == null ? 0 : Value.GetHashCode();
      switch (TheTag)
      {
        case Tag.Left:
          return code;
        case Tag.Right:
          return ~code;
        default:
          throw new CaseException(TheTag, typeof(Either<A, B>));
      }
    }

  }

}
