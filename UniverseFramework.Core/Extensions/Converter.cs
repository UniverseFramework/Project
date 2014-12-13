using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UniverseFramework.Core.Extensions
{
    [DebuggerStepThrough]
    public static class Converter
    {
        /// <summary>
        /// Convert value boolean
        /// </summary>
        public static bool? ToBooleanVal(this object value)
        {
            if (value == null)
            {
                return null;
            }

            try
            {
                return new bool?(Convert.ToBoolean(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Convert value boolean
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">True or False</param>
        /// <returns></returns>
        public static bool ToBooleanVal(this object value, bool defaultValue)
        {
            bool? x = Converter.ToBooleanVal(value);

            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        /// <summary>
        /// Convert value char
        /// </summary>
        public static Char? ToCharVal(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new char?(Convert.ToChar(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
        }

        /// <summary>
        /// Convert value char
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaulValue">Default char value</param>
        /// <returns></returns>
        public static Char ToCharVal(this object value, char defaulValue)
        {
            char? x = ToCharVal(value);

            if (x.HasValue)
            {
                return defaulValue;
            }
            return x.GetValueOrDefault();
        }

        /// <summary>
        /// Convert value datetime
        /// </summary>
        public static DateTime? ToDateTimeVal(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new DateTime?(Convert.ToDateTime(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert value datetime
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">Default datetime value</param>
        public static DateTime ToDateTimeVal(this object value, DateTime defaultValue)
        {
            DateTime? x = ToDateTimeVal(value);

            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        /// <summary>
        /// Convert value decimal
        /// </summary>
        public static decimal? ToDecimalVal(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new decimal?(Convert.ToDecimal(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert value decimal
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">Default decimal value</param>
        /// <returns></returns>
        public static decimal ToDecimalVal(this object value, decimal defaultValue)
        {
            decimal? x = ToDecimalVal(value);

            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        /// <summary>
        /// Convert value double
        /// </summary>
        public static double? ToDoubleVal(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new double?(Convert.ToDouble(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert value double
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">Default double value</param>
        /// <returns></returns>
        public static double ToDoubleVal(this object value, double defaultValue)
        {
            double? x = ToDoubleVal(value);
            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        /// <summary>
        /// Convert value guid
        /// </summary>
        public static Guid? ToGuidVal(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return new Guid(value.ToString());
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert value guid
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">Default guid value</param>
        public static Guid ToGuidVal(this object value, Guid defaultValue)
        {
            Guid? x = ToGuidVal(value);
            if (!x.HasValue)
            {
                return defaultValue;
            }
            return x.GetValueOrDefault();
        }

        /// <summary>
        /// Convert value int
        /// </summary>
        public static int? ToIntegerVal(this object value)
        {
            if (value == null)
            {
                return null;
            }
            if (value is string)
            {
                string str = value as string;
                int length = str.IndexOfAny(new char[] { ',', '.' });

                if ((length > 0) && (length < (str.Length - 1)))
                {
                    foreach (char ch in str.Substring(length + 1))
                    {
                        if (!ch.Equals('0'))
                        {
                            return null;
                        }
                    }

                    value = str.Substring(0, length);
                }
            }
            try
            {
                return new int?(Convert.ToInt32(value));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convert value int
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">Default int value</param>
        public static int ToIntegerVal(this object value, int defaultValue)
        {
            int? x = ToIntegerVal(value);

            if (!x.HasValue)
            {
                return defaultValue;
            }

            return x.GetValueOrDefault();
        }

        /// <summary>
        /// Convert value string
        /// </summary>
        public static string ToStringVal(this object value)
        {
            return ToStringVal(value, true, true);
        }

        /// <summary>
        /// Convert value string
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="convertEmptyStringToNull">Return value null</param>
        /// <param name="trim">Clears space</param>
        /// <returns></returns>
        public static string ToStringVal(this object value, bool convertEmptyStringToNull, bool trim)
        {
            if (value == null)
            {
                return null;
            }
            string str = Convert.ToString(value);
            if (trim)
            {
                str = str.Trim();
            }
            if (convertEmptyStringToNull && (str.Length == 0))
            {
                return null;
            }
            return str;
        }

        /// <summary>
        /// Convert value Md5 (MD5CryptoServiceProvider)
        /// </summary>
        public static string ToMd5(this object value)
        {
            string x = value.ToStringVal();

            if (String.IsNullOrEmpty(x))
            {
                return null;
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] byt = Encoding.UTF8.GetBytes(x);
            byt = md5.ComputeHash(byt);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in byt)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToStringVal();
        }
    }
}
