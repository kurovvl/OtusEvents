using OtusEvents.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OtusEvents.Classes
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection) where T : class, ICustomConvertable
        {
            using (var enumerator = collection.GetEnumerator())
            {
                T max = null;
                var cmp = float.MinValue;
                while (enumerator.MoveNext())
                {
                    var tmp = enumerator.Current.ConvertToCompare();
                    if (tmp > cmp)
                    {
                        cmp = tmp;
                        max = enumerator.Current;
                    }
                }
                return max;
            }
        }
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            using (var enumerator = collection.GetEnumerator())
            {
                var cmp = float.MinValue;
                T max = null;
                while (enumerator.MoveNext())
                {
                    var tmp = convertToNumber(enumerator.Current as T);
                    if (tmp > cmp)
                    {
                        cmp = tmp;
                        max = enumerator.Current;
                    }
                }
                return max;
            }
        }
    }



}
