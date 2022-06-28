using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SQT.FRAMEWORK.DAL;

namespace SQT.FRAMEWORK.SECURITY
{

    public class Preferences
    {
        private static DataSecurity security = new DataSecurity();
        private static XMLHelper xmlHelper = new XMLHelper();
        private const string PASSWORD_KEY = "password";
        private const string USERNAME_KEY = "username";
        private const string REMEMBER_ME_KEY = "rememberme";
        private const string SCANNING_RESOLUTION_KEY = "scanningResolution";
        private const string FILE_SAVE_RESOLUTION_KEY = "filesaveresolution";
        private const string DUPLEX_SCANNING_ENABLED_KEY = "duplexenabled";
        private const string DOCUMENT_FEEDER_ENABLED_KEY = "feederenabled";
        private const string LAST_LOGGED_IN_USER_KEY = "lastuser";
        private const string LAST_LOGIN_DATE_KEY = "lastlogindate";
        private const string IMAGE_SIZE_KEY = "imagesize";
        private const string XFER_COUNT_KEY = "xfercount";


        public enum Preference
        {
            RememberMe,
            Username,
            Password,
            LastUser,
            LastLoginDate
        }
        #region "Public Methods"

        public static void SavePreference(Preference preference, string value)
        {
            switch (preference)
            {
                case Preference.Username:
                    xmlHelper.SetValue(USERNAME_KEY, security.Encrypt(value));
                    break;
                case Preference.Password:
                    xmlHelper.SetValue(PASSWORD_KEY, security.Encrypt(value));
                    break;
                case Preference.LastUser:
                    xmlHelper.SetValue(LAST_LOGGED_IN_USER_KEY, security.Encrypt(value));
                    break;
                case Preference.LastLoginDate:
                    xmlHelper.SetValue(LAST_LOGIN_DATE_KEY, value);
                    break;
                case Preference.RememberMe:
                    xmlHelper.SetValue(REMEMBER_ME_KEY, value);
                    break;
            }
        }

        public static void ClearCredentials()
        {
            xmlHelper.SetValue(REMEMBER_ME_KEY, "false");
            xmlHelper.SetValue(USERNAME_KEY, string.Empty);
            xmlHelper.SetValue(PASSWORD_KEY, string.Empty);
            xmlHelper.Save();
        }
        public static void Save()
        {
            xmlHelper.Save();
        }
        public static string GetPreference(Preference preference)
        {
            string value = string.Empty;
            switch (preference)
            {
                case Preference.Username:
                    value = xmlHelper.GetValue(USERNAME_KEY);
                    if (!string.IsNullOrEmpty(value))
                        value = security.Decrypt(value);
                    else
                        value = string.Empty;
                    break;
                case Preference.Password:
                    value = xmlHelper.GetValue(PASSWORD_KEY);
                    if (!string.IsNullOrEmpty(value))
                        value = security.Decrypt(value);
                    else
                        value = string.Empty;
                    break;
                case Preference.RememberMe:
                    value = xmlHelper.GetValue(REMEMBER_ME_KEY);
                    break;
                case Preference.LastUser:
                    value = xmlHelper.GetValue(LAST_LOGGED_IN_USER_KEY);
                    if (!string.IsNullOrEmpty(value))
                        value = security.Decrypt(value);
                    else
                        value = string.Empty;
                    break;
                case Preference.LastLoginDate:
                    value = xmlHelper.GetValue(LAST_LOGIN_DATE_KEY);
                    break;
            }

            return value;
        }

        #endregion

        #region "Public Properties"
        public static PictureBoxSizeMode ImageSize
        {
            get
            {
                PictureBoxSizeMode imageSizeMode = PictureBoxSizeMode.StretchImage;
                string value = xmlHelper.GetValue(IMAGE_SIZE_KEY);

                if (!string.IsNullOrEmpty(value))
                {
                    switch (value)
                    {
                        case "AutoSize":
                            imageSizeMode = PictureBoxSizeMode.AutoSize;
                            break;
                        case "CenterImage":
                            imageSizeMode = PictureBoxSizeMode.CenterImage;
                            break;
                        case "Normal":
                            imageSizeMode = PictureBoxSizeMode.Normal;
                            break;
                        case "StretchImage":
                            imageSizeMode = PictureBoxSizeMode.StretchImage;
                            break;
                        case "Zoom":
                            imageSizeMode = PictureBoxSizeMode.Zoom;
                            break;
                        default:
                            imageSizeMode = PictureBoxSizeMode.StretchImage;
                            break;
                    }
                }

                return imageSizeMode;
            }
        }

        #endregion

    }
}