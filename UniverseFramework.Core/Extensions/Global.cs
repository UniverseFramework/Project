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

            if (typeof(T).Equals(typeof(bool)))
            {
                return (T?)(object)value.ToBooleanVal();
            }

            if (typeof(T).Equals(typeof(byte)))
            {
                return (T?)(object)value.ToIntegerVal();
            }

            if (typeof(T).Equals(typeof(char)))
            {
                return (T?)(object)value.ToCharVal();
            }

            if (typeof(T).Equals(typeof(decimal)))
            {
                return (T?)(object)value.ToDecimalVal();
            }

            if (typeof(T).Equals(typeof(double)))
            {
                return (T?)(object)value.ToDoubleVal();
            }

            if (typeof(T).IsEnum)
            {
                return value.ToEnumVal<T>();
            }

            if (typeof(T).Equals(typeof(float)))
            {
                return (T?)(object)value.ToDoubleVal();
            }

            if (typeof(T).Equals(typeof(int)))
            {
                return (T?)(object)value.ToIntegerVal();
            }

            if (typeof(T).Equals(typeof(long)))
            {
                var val = default(long);

                return (T?)(object)(long.TryParse(value.ToString(), out val) ? (long?)val : null);
            }

            if (typeof(T).Equals(typeof(sbyte)))
            {
                var val = default(sbyte);

                return (T?)(object)(sbyte.TryParse(value.ToString(), out val) ? (sbyte?)val : null);
            }

            if (typeof(T).Equals(typeof(short)))
            {
                return (T?)(object)(value.ToIntegerVal());
            }

            if (typeof(T).Equals(typeof(uint)))
            {
                var val = default(uint);

                return (T?)(object)(uint.TryParse(value.ToString(), out val) ? (uint?)val : null);
            }

            if (typeof(T).Equals(typeof(ulong)))
            {
                var val = default(ulong);

                return (T?)(object)(ulong.TryParse(value.ToString(), out val) ? (ulong?)val : null);
            }

            if (typeof(T).Equals(typeof(ushort)))
            {
                var val = default(ushort);

                return (T?)(object)(ushort.TryParse(value.ToString(), out val) ? (ushort?)val : null);
            }

            try
            {
                return (T?)(value);
            }
            catch
            {
            }

            return null;
        }

        public static T As<T>(this object value) where T : class
        {
            return value as T;
        }

        public static T? GetPropVal<T>(this object obj, string propertyName) where T : struct, IComparable
        {
            var objType = obj.GetType();
            var property = objType.GetProperties().Where(c => c.Name == propertyName).FirstOrDefault();

            if (property.IsNull())
            {
                return null;
            }

            return property.GetValue(obj).ConvertTo<T>();
        }
    }
}
