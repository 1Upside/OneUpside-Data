using System.Runtime.Serialization;

namespace OneUpside.Data
{

  /// <summary>
  /// Serialisable data required to invoke a function.
  /// </summary>
  [DataContract]
  public struct SFuncData
  {
    [DataMember]
    public string DeclaringTypeName;

    [DataMember]
    public string MethodName;

    [DataMember]
    public object Instance;
  }

}
