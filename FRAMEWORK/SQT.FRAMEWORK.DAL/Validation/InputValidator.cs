using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SQT.FRAMEWORK.DAL.Validation
{
    public abstract class InputValidator
    {
        public static bool IsAlpha(string strToCheck)
        {
            Regex objAlphaPattern = new Regex("[^a-zA-Z ]");
            return !objAlphaPattern.IsMatch(strToCheck);
        }

        public static bool IsValidURL(String strEmail)
        {
            Regex objURLPatterns = new Regex(@"^([\w-\.]+)((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$");
            return objURLPatterns.IsMatch(strEmail);
        }

        public static bool IsValidEMailAddress(String strEmail)
        {
            Regex objEMailPatterns = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            return objEMailPatterns.IsMatch(strEmail);
        }

        public static bool IsNaturalNumber(String strNumber)
        {
            Regex objNotNaturalPattern = new Regex("[^0-9]");
            Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");
            return !objNotNaturalPattern.IsMatch(strNumber.Replace(",", "")) && objNaturalPattern.IsMatch(strNumber.Replace(",", ""));
        }

        // Function to test for Positive Integers with zero inclusive
        public static bool IsWholeNumber(string strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber.Replace(",", ""));
        }

        // Function to Test for Integers both Positive & Negative
        public static bool IsInteger(string strNumber)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotIntPattern.IsMatch(strNumber.Replace(",", "")) && objIntPattern.IsMatch(strNumber.Replace(",", ""));
        }

        // Function to Test for Positive Number both Integer & Real
        public static bool IsPositiveNumber(string strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9.]");
            Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            return !objNotPositivePattern.IsMatch(strNumber.Replace(",", "")) && objPositivePattern.IsMatch(strNumber.Replace(",", "")) && objTwoDotPattern.IsMatch(strNumber.Replace(",", ""));
        }

        // Function to test whether the string is valid number or not
        public static bool IsNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
            return !objNotNumberPattern.IsMatch(strNumber.Replace(",","")) &&
                   !objTwoDotPattern.IsMatch(strNumber.Replace(",", "")) &&
                   !objTwoMinusPattern.IsMatch(strNumber.Replace(",", "")) &&
                   objNumberPattern.IsMatch(strNumber.Replace(",", ""));
        }

        // Function to Check for AlphaNumeric.
        public static bool IsAlphaNumeric(string strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9] ");
            return !objAlphaNumericPattern.IsMatch(strToCheck.Replace(",", ""));
        }

        public static bool IsNull(string strAdd)
        {
            strAdd = strAdd.Trim();
            if (strAdd != "")
                return false;
            return true;
        }
    }
}
