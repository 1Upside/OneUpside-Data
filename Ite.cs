namespace OneUpside.Data
{
  public static class Ite
  {
    public static Ite<A> ProduceThen<A>(A value)
    {
      return Ite<A>.ProduceThen(value);
    }

    public static Ite<A> ProduceElse<A>()
    {
      return Ite<A>.ProduceElse();
    }
  }

}
