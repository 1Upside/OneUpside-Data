using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace OneUpside.Data
{
  public static class ImmutableDictionaryExtensions
  {
    public static ImmutableDictionary<K,U> MapValues<K,V,U>
      ( this ImmutableDictionary<K,V> dict
      , Func<V,U> map
      )
    {
      return ImmutableDictionary.CreateRange
        ( dict.Select(kv => new KeyValuePair<K,U>(kv.Key, map(kv.Value)))
        );
    }

    public static ImmutableDictionary<K,U> MapValuesWithKey<K,V,U>
      ( this ImmutableDictionary<K,V> dict
      , Func<K,V,U> map
      )
    {
      return ImmutableDictionary.CreateRange
        ( dict.Select
          ( kv => new KeyValuePair<K,U>(kv.Key, map(kv.Key, kv.Value))
          )
        );
    }

  }

}
