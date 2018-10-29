using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;

namespace DiretorSkinner.Util.Acesso
{
    public static class DataExtenders
    {
        #region Fields

        private static Func<DataRow, bool> hasSqlErrorsFunc = row => Convert.ToInt32(row["ErrorNumber"]) != 0;
        private static IFormatProvider SqlCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");

        #endregion Fields

        #region Methods

        private static object ReturnConvertValueType(object value, Type type, SqlDbType oraType)
        {
            object returnValue = value;
            if (value != null)
            {
                //Verifica se é do tipo Enum e Pega o valor em inteiro
                if (type.IsEnum)
                {
                    returnValue = EnumValueConverter.ToString(value);
                }

                //Verifica se o value não está vazio
                if (!string.IsNullOrEmpty(value.ToString()))
                    returnValue = ReturnValueType(returnValue, oraType);
            }

            return returnValue;
        }

        public static IEnumerable<T> GetEnumerator<T>(this IDataReader reader,
            Func<IDataRecord, T> generator)
        {
            var sqlReader = reader as SqlDataReader;

            while (reader.Read())
                yield return generator(reader);
        }

        public static bool HasSqlErrors(this DataTable tb)
        {
            if (tb == null)
                return true;

            bool hasErrors = false;

            hasErrors = tb.Rows.Cast<DataRow>().Any(hasSqlErrorsFunc);

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

        public static DateTime ToDateTime(this object obj)
        {
            SqlDateTime ts = (SqlDateTime)obj;

            return ts.Value;
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

            return Convert.ToDecimal(ln[fieldName], SqlCulture);
        }

        public static decimal ToDecimal(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return 0.0m;

            return Convert.ToDecimal(ln[fieldName], SqlCulture);
        }

        public static decimal? ToDecimalOrNull(this DataRow ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToDecimal(ln[fieldName], SqlCulture);
        }

        public static decimal? ToDecimalOrNull(this IDataRecord ln, string fieldName)
        {
            if (ln.IsNull(fieldName))
                return null;

            return Convert.ToDecimal(ln[fieldName], SqlCulture);
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

        public static DateTime ToTimeStamp(this object obj)
        {
            SqlDateTime ts = (SqlDateTime)obj;

            return ts.Value;
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


        /// <summary>
        /// retorna o valor convertido para o tipo correspondente no .net para ser usado no método de salvar em lote AddArray
        /// </summary>
        /// <param name="value">Valor que será convertido</param>
        /// <param name="oraType">Tipo do Sql</param>
        /// <returns>retorna o valor convertido</returns>
        private static object ReturnValueType(object value, SqlDbType oraType)
        {
            switch (oraType)
            {
                case SqlDbType.Bit:
                    value = Convert.ToBoolean(value);
                    break;
                case SqlDbType.Char:
                    value = Convert.ToString(value);
                    break;
                case SqlDbType.Text:
                    break;
                case SqlDbType.Date:
                    value = Convert.ToDateTime(value);
                    break;
                case SqlDbType.Decimal:
                    value = Convert.ToDecimal(value);
                    break;
                case SqlDbType.Real:
                    value = Convert.ToDouble(value);
                    break;
                case SqlDbType.SmallInt:
                    value = Convert.ToInt16(value);
                    break;
                case SqlDbType.Int:
                    value = Convert.ToInt32(value);
                    break;
                case SqlDbType.BigInt:
                    value = Convert.ToInt64(value);
                    break;
                case SqlDbType.TinyInt:
                    value = Convert.ToInt16(value);
                    break;
                case SqlDbType.NChar:
                    value = value as byte[];
                    break;
                case SqlDbType.Timestamp:
                    value = Convert.ToDateTime(value).ToString("yyyy.MM.dd.HH:mm:ss.fff");
                    break;
                case SqlDbType.VarChar:
                    value = Convert.ToString(value);
                    break;
                case SqlDbType.Xml:
                    break;
                default:
                    break;
            }

            return value;
        }

        #endregion Methods
    }
}
