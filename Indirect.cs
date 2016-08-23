namespace OneUpside.Data
{
  public static class Indirect
  {
    public static Indirect<A> Create<A>(A value)
    {
      return new Indirect<A>(value);
    }
  }
}
