using System;
using System.Collections.Generic;

namespace OneUpside.Data
{
  /// <summary>
  /// Extension methods for <see cref="Dictionary{TKey, TValue}"/>.
  /// </summary>
  public static class DictionaryExtensions
  {
    /// <summary>
    ///   Apply a function to every value, producing a new dictionary.
    /// </summary>
    /// <remarks>
    ///   (Dictionary K, MapValues) forms a functor.
    /// </remarks>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="W"></typeparam>
    /// <param name="dict">Must not be null.</param>
    /// <param name="map">Must not be null.</param>
    /// <returns>A non-null dictionary.</returns>
    public static Dictionary<K,W> MapValues<K,V,W>
      ( this Dictionary<K,V> dict
      , Func<V,W> map
      )
    {
      var output = new Dictionary<K,W>();
      foreach (var kv in dict)
      {
        output.Add(kv.Key, map(kv.Value));
      }
      return output;
    }

    /// <summary>
    ///   Two <see cref="Dictionary{TKey, TValue}"/>'s are equal if they have the same key/value pairs.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     Keys are compared using the key comparator of <paramref name="x"/> and <paramref name="y"/>. Values are compared by <paramref name="valueComparator"/>. Undefined if <paramref name="x"/> and <paramref name="y"/> do not use the same key comparator.
    ///   </para>
    ///   <para>
    ///     <see cref="ExtensionallyEqual{K, V}(Dictionary{K, V}, Dictionary{K, V}, Func{V, V, bool})" /> forms an equality relation.
    ///   </para>
    /// </remarks>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="x">Must not be null.</param>
    /// <param name="y">Must not be null.</param>
    /// <param name="valueComparator">If null the default object equality is used.</param>
    /// <returns></returns>
    public static bool ExtensionallyEqual<K, V>
      ( this Dictionary<K, V> x
      , Dictionary<K, V> y
      , Func<V, V, bool> valueComparator = null
      )
    {
      if (valueComparator == null)
      {
        valueComparator = (a, b) => object.Equals(a, b);
      }
      foreach (var xkv in x)
      {
        V yv;
        if (    !y.TryGetValue(xkv.Key, out yv) 
             || !valueComparator(xkv.Value, yv)
           )
        {
          return false;
        }
      }
      foreach (var ykv in y)
      {
        V xv;
        if (    !x.TryGetValue(ykv.Key, out xv) 
             || !valueComparator(ykv.Value, xv)
           )
        {
          return false;
        }
      }
      return true;
    }
    
  }
}
