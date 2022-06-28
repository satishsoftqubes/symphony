using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQT.FRAMEWORK.EXCEPTION;
using System.Configuration;
using System.Globalization;

namespace SQT.FRAMEWORK.COMMON.Util
{
    public static class Formatter
    {
        #region ConfigurationVariables.
        private static string _dateFormat = ConfigurationManager.AppSettings["DateFormat"];
        private static string _cultureInfo = ConfigurationManager.AppSettings["CultureInfo"];
        #endregion

        #region Private Attributes.
        private static IFormatProvider format = new CultureInfo(_cultureInfo);
        #endregion

        #region Public Methods.
        /// <summary>
        /// Formats date in DD/MM/YYYY format 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetFormattedDate(DateTime date)
        {
            #region LogMethodStart
            ArrayList methodvalues = null;
            #endregion
            if (!string.IsNullOrEmpty(date.ToString()))
            {
                try
                {
                    return date.ToString(_dateFormat, format);
                }
                catch (FormatException)
                {
                    throw new FormatException("Date Format is not valid.");
                }
            }
            else
            {
                #region LogMethodReturn
                methodvalues = new ArrayList();
                methodvalues.Add("Date in " + _dateFormat + " format");
                methodvalues.Add(string.Empty);
                #endregion
                return string.Empty;
            }
        }
        /// <summary>
        /// Gets the formatted currency as string
        /// Inserts commas in thousands field.
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string GetCurrencyFormat(double currency)
        {
            #region LogMethodStart
            ArrayList methodvalues = null;
            #endregion
            string amount = "0.00";
            try
            {
                if (!double.IsNaN(currency))
                {
                    if (!double.IsInfinity(currency))
                    {
                        amount = string.Format(format, "{0:##,##,###0.00}", currency);
                    }
                    else
                    {
                        throw new IVAPSBaseException("Currency cannot have infinite value");
                    }
                }
                else
                {
                    throw new IVAPSBaseException("Currency should be a number");
                }
            }
            catch
            {
                throw;
            }
            #region LogMethodReturn
            methodvalues = new ArrayList();
            methodvalues.Add("amount");
            methodvalues.Add(amount);
            #endregion
            return amount;
        }
        /// <summary>
        /// Gets the formated currency as double.
        /// Removes commas.
        /// </summary>
        /// <param name="amount">amount in string format</param>
        /// <returns>amount as a double</returns>
        public static double GetCurrencyFormat(string amount)
        {
            #region LogMethodStart
            ArrayList methodvalues = null;
            #endregion
            double currency = 0.00;
            try
            {
                if (!string.IsNullOrEmpty(amount))
                {
                    amount = amount.ToString().Replace(",", "").Replace("£", "").Replace("$", "").Replace(" ", "");
                    try
                    {
                        currency = Convert.ToDouble(amount, format);
                    }
                    catch (InvalidCastException inEx)
                    {
                        throw new IVAPSBaseException("Amount should have only numeric values.", inEx);
                    }
                }
                else
                {
                    throw new IVAPSBaseException("Amount cannot be null or empty.");
                }
            }
            catch
            {
                throw;
            }
            #region LogMethodReturn
            methodvalues = new ArrayList();
            methodvalues.Add("currency");
            methodvalues.Add(currency);
            #endregion
            return currency;
        }
        #endregion
    }
}
