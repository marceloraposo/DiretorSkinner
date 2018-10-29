using System;

namespace DiretorSkinner.Util.Acesso
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Contrutor Default
        /// </summary>
        /// <param name="value"></param>
        public EnumValueAttribute(string value)
        {
            this.Value = value;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Valor do Item do Enum
        /// </summary>
        public string Value
        {
            get; private set;
        }

        #endregion Properties
    }
}
