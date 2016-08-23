using Newtonsoft.Json;
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace OneUpside.Data
{
  /// <summary>
  ///   A serialisable function.
  /// </summary>
  /// <typeparam name="A">Argument type</typeparam>
  /// <typeparam name="R">Return type</typeparam>
  [DataContract]
  public sealed class SFunc<A,R>
  {
    [DataMember]
    private SFuncData Data;

    /// <summary>
    /// Construct a <see cref="SFunc{A, R}"/>.
    /// </summary>
    /// <param name="func">
    ///   A public method (instance or static) castable to
    ///   <see cref="Func{A,R}" />. If an instance method, the object must be 
    /// serializable.
    /// </param>
    /// <param name="obj">
    ///   If <paramref name="func" /> is an instance method then this must be 
    ///   an appropriate and serializable object. Otherwise, if it is a static 
    ///   method then this must be null.
    /// </param> 
    public SFunc(object obj, MethodInfo func)
    {
      Contract.Requires
        ( func.GetParameters().Equals(new Type[] { typeof(A) })
          && func.ReturnType.Equals(typeof(R))
          && ( (!func.IsStatic && obj != null) 
               || (func.IsStatic && obj == null)
             )
        );
      Data = new SFuncData
        { DeclaringTypeName = func.DeclaringType.AssemblyQualifiedName
        , MethodName = func.Name
        , Instance = obj
        };
    }

    [JsonConstructor]
    private SFunc(SFuncData data)
    {
      Data = data;
    }

    /// <summary>
    ///   Apply this function to an argument.
    /// </summary>
    /// <param name="a">Function argument</param>
    /// <returns>Function return value</returns>
    public R Apply(A a)
    {
      var parameterTypes = new Type[] { typeof(A) };
      var method = 
        Type.GetType(Data.DeclaringTypeName).GetTypeInfo()
          .DeclaredMethods.Where
          ( m => m.Name == Data.MethodName
            && m.GetParameters()
               .Select(p => p.ParameterType)
               .SequenceEqual(parameterTypes)
          )
          .First();
      return (R)method.Invoke(Data.Instance, new object[] { a });
    }

  }

}
