using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseFramework.Core.Extensions.Converters;

namespace UniverseFramework.Core
{
    public static class Global
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static Nullable<T> ConvertTo<T>(this object value) where T : struct, IComparable
        {
            if (value.IsNull())
            {
                return null;
            }

            if (!typeof(T).IsValueType)
            {
                return null;
            }

            if(typeof(T).Equals(typeof(bool)))
            {
                return (T?)value.ToBooleanVal();
            }



            return null;
        }

        public static T GetPropVal<T>(this object obj,string propertyName)
        {

        }
    }
}
