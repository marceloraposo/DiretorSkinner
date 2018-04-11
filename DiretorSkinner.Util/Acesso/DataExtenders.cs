using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiretorSkinner.Util.Acesso
{
    public static class DataExtenders
    {
        #region Fields

        private static Func<DataRow, bool> hasOracleErrorsFunc = row => Convert.ToInt32(row["ErrorNumber"]) != 0;
        private static IFormatProvider oracleCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");

        #endregion Fields

        #region Methods

        public static bool HasOracleErrors(this DataTable tb)
        {
            if (tb == null)
                return true;

            bool hasErrors = false;

            hasErrors = tb.Rows.Cast<DataRow>().Any(hasOracleErrorsFunc);

            return hasErrors;
        }

        public static bool ToBoolean(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return false;

            return Convert.ToBoolean(ln[fieldName]);
        }

        public static bool ToBoolean(this IDataRecord ln, string fieldName)
        {
            return Convert.ToBoolean(ln[fieldName]);
        }

        public static bool? ToBooleanOrNull(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToBoolean(ln[fieldName]);
        }

        public static bool? ToBooleanOrNull(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToBoolean(ln[fieldName]);
        }

        public static byte[] ToByteArray(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return default(byte[]);

            return (byte[])(ln[fieldName]);
        }

        public static byte[] ToByteArray(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return default(byte[]);

            return (byte[])(ln[fieldName]);
        }

        public static char ToChar(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return new char();

            return Convert.ToChar(ln[fieldName]);
        }

        public static char ToChar(this IDataRecord ln, string fieldName)
        {
            return Convert.ToChar(ln[fieldName]);
        }

        public static DateTime ToDateTime(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return new DateTime();

            return Convert.ToDateTime(ln[fieldName]);
        }

        public static DateTime ToDateTime(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return new DateTime();

            return Convert.ToDateTime(ln[fieldName]);
        }

        public static DateTime? ToDateTimeOrNull(this object obj)
        {
            DateTime retorno;
            DateTime.TryParse(obj.ToString(), out retorno);
            return retorno;
        }

        public static DateTime? ToDateTimeOrNull(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToDateTime(ln[fieldName]);
        }

        public static DateTime? ToDateTimeOrNull(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToDateTime(ln[fieldName]);
        }

        public static decimal ToDecimal(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return 0.0m;

            return Convert.ToDecimal(ln[fieldName], oracleCulture);
        }

        public static decimal ToDecimal(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return 0.0m;

            return Convert.ToDecimal(ln[fieldName], oracleCulture);
        }

        public static decimal? ToDecimalOrNull(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToDecimal(ln[fieldName], oracleCulture);
        }

        public static decimal? ToDecimalOrNull(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToDecimal(ln[fieldName], oracleCulture);
        }

        public static int ToInteger(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return 0;

            return Convert.ToInt32(ln[fieldName]);
        }

        public static int ToInteger(this IDataRecord ln, string fieldName)
        {
            return Convert.ToInt32(ln[fieldName]);
        }

        public static int? ToIntegerOrNull(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToInt32(ln[fieldName]);
        }

        public static int? ToIntegerOrNull(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToInt32(ln[fieldName]);
        }

        public static long ToLong(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return 0;

            return Convert.ToInt64(ln[fieldName]);
        }

        public static long ToLong(this IDataRecord ln, string fieldName)
        {
            return Convert.ToInt64(ln[fieldName]);
        }

        public static long? ToLongOrNull(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToInt64(ln[fieldName]);
        }

        public static long? ToLongOrNull(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToInt64(ln[fieldName]);
        }

        public static short ToShort(this DataRow ln, string fieldName)
        {
            return Convert.ToInt16(ln[fieldName]);
        }

        public static string ToString(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return string.Empty;

            return Convert.ToString(ln[fieldName]);
        }

        public static string ToString(this IDataRecord ln, string fieldName)
        {
            return Convert.ToString(ln[fieldName]);
        }

        public static Type ToType(this DataRow ln, string fieldName)
        {
            return (Type)ln[fieldName];
        }

        private static object GetProperty(string propertyName, object item)
        {
            if (propertyName.Contains("."))
                return GetProperty(propertyName.Split('.')[1], item.GetType().GetProperty(propertyName.Split('.')[0]).GetValue(item, null));

            if (item != null)
            {
                var pi = item.GetType().GetProperty(propertyName);
                if (pi != null)
                    return pi.GetValue(item, null);
            }

            return null;
        }

        private static bool IsNull(this IDataRecord ln, string fieldName)
        {
            return ln.IsDBNull(ln.GetOrdinal(fieldName));
        }


        #endregion Methods
    }
}
