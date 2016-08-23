namespace OneUpside.Data
{

  /// <summary>
  /// A mutable variable with an object lifetime.
  /// </summary>
  public sealed class Indirect<A>
  {
    public A Value;

    public Indirect()
    {
    }

    public Indirect(A value)
    {
      Value = value;
    }

  }

}
