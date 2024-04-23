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
        public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float?> convertToNumber = null) where T : class, ICustomConvertable?
        {
            T? max = null;
            var cmp = float.MinValue;
            foreach (var item in collection)
            {
                var tmp = convertToNumber != null ? convertToNumber(item) : item?.ConvertToCompare();
                if (tmp == null)
                {
                    continue;
                }
                if (tmp > cmp)
                {
                    cmp = tmp.Value;
                    max = item;
                }
            }
            return max;
        }
    }



}
