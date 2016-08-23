using System;
using System.Linq.Expressions;

namespace OneUpside.Data
{
  /// <summary>
  ///   Helpers to construct serialisable functions.
  /// </summary>
  public static class SFunc
  {
     
    /// <summary>
    ///   A convenience for constructing <see cref="SFunc{A,R}"/> from a call 
    ///   expression. You must ensure that the called function is a method. 
    /// </summary>
    /// <param name="callExpr">The call expression (see examples).</param>
    /// <example><code>Create(x => MyMethod(x))</code></example>
    /// <example><code>Create(x => MyClass.MyMethod(x))</code></example>
    public static SFunc<A,R> Create<A,R>(Expression<Func<A,R>> expr)
    {
      var callExpr = expr.Body as MethodCallExpression;
      if (callExpr != null)
      {
        return new SFunc<A,R>(callExpr.Object, callExpr.Method);
      }
      throw new ArgumentException
        ( "callExpr must be a MethodCallExpression"
        , "callExpr"
        );
    }

    /// <summary>
    ///   A convenience for constructing <see cref="SFunc{A,B,R}"/> from a call 
    ///   expression. You must ensure that the called function is a method. 
    /// </summary>
    /// <param name="callExpr">The call expression (see examples).</param>
    /// <example><code>Create(x => MyMethod(x))</code></example>
    /// <example><code>Create(x => MyClass.MyMethod(x))</code></example>
    public static SFunc<A,B,R> Create<A,B,R>(Expression<Func<A,B,R>> expr)
    {
      var callExpr = expr.Body as MethodCallExpression;
      if (callExpr != null)
      {
        return new SFunc<A,B,R>(callExpr.Object, callExpr.Method);
      }
      throw new ArgumentException
        ( "callExpr must be a MethodCallExpression"
        , "callExpr"
        );
    }

  }

}
