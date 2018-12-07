using System;

namespace IDMONEY.IO
{
    public class StringValueAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Holds the string value for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value">String representation for the target object</param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion Constructor
    }
}