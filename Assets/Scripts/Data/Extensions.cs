using System.Collections;
using UnityEngine;

namespace Data
{
    public static class Extensions
    {
        public static string ToJson(this object obj) => JsonUtility.ToJson(obj);

        public static T ToDesirialize<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}