using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace SQT.FRAMEWORK.COMMON.Util
{
    public class Utility
    {
        #region ActiveDIrectory Utility Variables
            public System.Text.StringBuilder sb;
            public System.Text.StringBuilder sbProperty;
            public DirectoryEntry searchRoot;
            public DirectorySearcher search;
            public SearchResult result;
            public System.DirectoryServices.PropertyCollection properties;
            public SearchResultCollection resultCol;
        #endregion ActiveDIrectory Utility Variables

        #region Enbcryption Utility Variable
        private string strDecryptName;
        private string strEncryptName;
        private string strEncryptKey = "PMS";
        public string strModule;
        private int intDivide = 10;
        private int[] intA = new int[253];
        private int[] intB = new int[1000];
        private int[] intC = new int[1000];
        private char[] intD = new char[1000];
        #endregion Enbcryption Utility Variable

        #region ComputerHistory Utility Variable
        public ArrayList arlComputerName;
        public ArrayList arlIpAddress;
        public ArrayList arlMACAddress;
        public ArrayList arlUnreachableComputers;
        #endregion ComputerHistory Utility Variable

        #region Static Variable Declaration
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);
        #endregion Static Variable Declaration

        #region Constructor Definition
        /// <summary>
        ///     Initialize the new instance of the Utility Class, initialize the default value.
        /// </summary>
        public Utility()
        {
            strDecryptName = String.Empty;
            strEncryptName = String.Empty;
            strModule = String.Empty;
            intB[0] = 2;    intB[1] = 3;            intB[2] = 5;            intB[3] = 7;
            intB[4] = 11;   intB[5] = 13;           intB[6] = 17;           intB[7] = 19;
            intB[8] = 27;   intB[9] = 29;
        }
        #endregion Constructor Definition

        #region Encryption Logic
        /// <summary>
        ///     Encripting the String.
        /// </summary>
        /// <param name="Password">string argument specified the string password that we want to encrypt.</param>
        /// <returns>Encrypted string are retrun.</returns>
        public string Encryption(string Password)
        {
            int intLength = Password.Length;
            for (int intN = 0; intN < intLength; intN++)
            {
                int intCode = 0;
                intCode = Convert.ToInt16(Convert.ToChar(Password.Substring(intN, 1)));
                intCode = (intCode + intB[intN % intLength] + Convert.ToInt16(Convert.ToChar(strEncryptKey.Substring(intN % (strEncryptKey.Length), 1))));
                intC[intN] = (intCode % intDivide);
                intCode = intCode / intDivide;
                if (intCode > 253)
                {
                    intCode = intCode - 253;
                }
                if (intCode == 39)
                {
                    intCode = 254;
                }

                strEncryptName = strEncryptName + Convert.ToChar(intCode);
            }

            for (int intN = 0; intN < intLength; intN++)
            {
                int intTempCode = 0;
                string intA = "";
                intA = Convert.ToString(intC[intN]);
                intTempCode = (Convert.ToInt16(Convert.ToChar(intA.Substring(0, 1))) + intB[intN % intLength]);
                if (intTempCode > 253)
                {
                    intTempCode = intTempCode - 253;
                }
                if (intTempCode == 39)
                {
                    intTempCode = 254;
                }

                strModule = strModule + Convert.ToChar(intTempCode);
            }
            return strEncryptName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intLength"></param>
        /// <param name="strEncryptedString"></param>
        /// <returns></returns>
        public string Decryption(int intLength, string strEncryptedString)
        {
            string strTempModule = "";
            strDecryptName = "";
            for (int intN = 0; intN < intLength; intN++)
            {
                int intTempCode = 0;
                intTempCode = (Convert.ToInt16(Convert.ToChar(strModule.Substring(intN, 1))) - intB[intN % intLength]);

                if (intTempCode < 0)
                {
                    intTempCode = intTempCode + 253;
                }
                if (intTempCode == 254)
                {
                    intTempCode = 39;
                }

                strTempModule = strTempModule + Convert.ToChar(intTempCode);
            }

            intD = strEncryptedString.ToCharArray();
            for (int intN = 0; intN < intLength; intN++)
            {
                int intCode = 0;
                intCode = Convert.ToInt16(intD[intN]);
                if (intCode < 0)
                {
                    intCode = intCode + 253;
                }
                if (intCode == 254)
                {
                    intCode = 39;
                }
                intCode = (((intCode * intDivide) + (Convert.ToInt16(strTempModule.Substring(intN, 1)))) - intB[intN % intLength] - Convert.ToInt16(Convert.ToChar(strEncryptKey.Substring(intN % (strEncryptKey.Length), 1))));
                strDecryptName = strDecryptName + Convert.ToChar(intCode);
            }
            return strDecryptName;
        }
        #endregion Encryption Logic

        #region Active Directory Logic
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainpath"></param>
        /// <returns></returns>
        public ArrayList getAllUsersOfTheDomain(string domainpath)
        {
            sb = new System.Text.StringBuilder();
            sbProperty = new System.Text.StringBuilder();
            DirectoryEntry searchRoot;
            DirectorySearcher search;
            SearchResult result;
            System.DirectoryServices.PropertyCollection properties;
            SearchResultCollection resultCol;
            
            //domainpath = "LDAP://in.Quest-Software.com";

            ArrayList allUsers = new ArrayList();
            sb = new System.Text.StringBuilder();
            sbProperty = new System.Text.StringBuilder();
            searchRoot = new DirectoryEntry(domainpath);
            search = new DirectorySearcher(searchRoot);
            search.Filter = "(&(objectClass=user)(objectCategory=person))";
            search.PropertiesToLoad.Add("samaccountname");
            search.PropertiesToLoad.Add("name");
            search.PropertiesToLoad.Add("desacription");
            search.PropertiesToLoad.Add("givenName");
            // search.PropertiesToLoad.Add("userPassword");
            
            resultCol = search.FindAll();
            if (resultCol != null)
            {
                for (int counter = 0; counter < resultCol.Count; counter++)
                {
                    result = resultCol[counter];
                    if (result.Properties.Contains("samaccountname"))
                    {
                        allUsers.Add((String)result.Properties["samaccountname"][0]);
                    }
                }
               
                //Get the Properties of the User.
                properties = searchRoot.Properties;
                foreach (string name in properties.PropertyNames)
                {
                    foreach (object obj in properties[name])
                    {
                        sb.Append(name + "\t:  " + obj.ToString());
                        sb.AppendLine();
                    }
                }
            }
            return allUsers;
        }
        /// <summary>
        /// 
        /// </summary>
        public void createDomainUser()
        {
            //DirectoryEntry de = new DirectoryEntry("LDAP://in.Quest-Software.com");
            //DirectoryEntries Users = de.Children;
            //DirectoryEntry User = Users.Add("CN=Harikrishna", "user");
            //User.Properties["company"].Add("Impulsive SofSolution Pvt. Ltd.");
            //User.Properties["department"].Add("Operation");
            //User.Properties["employeeId"].Add("09");
            //User.Properties["samAccountName"].Add("JDoe");
            //User.Properties["userPrincipalName"].Add("Quest01");
            //User.Properties["givenName"].Add("hari");
            //User.Properties["sn"].Add("doe");
            //User.Properties["userPassword"].Add("shriji");
            //User.CommitChanges();
        }
        
        #endregion Active Directory Logic

        #region Computer History Logic
        /// <summary>
        /// 
        /// </summary>
        public void GetCurrentNodeInfo()
        {
            System.Net.IPHostEntry Tempaddr = null;
            string[] Ipaddr = new string[3];
            arlMACAddress = new ArrayList();
            arlIpAddress = new ArrayList();

            string CurrentHostName;
            CurrentHostName = Dns.GetHostName();

            arlIpAddress.Add(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString());
            Tempaddr = (System.Net.IPHostEntry)Dns.GetHostByName(CurrentHostName);
            System.Net.IPAddress[] TempAd = Tempaddr.AddressList;
            foreach (IPAddress TempA in TempAd)
            {
                Ipaddr[1] = TempA.ToString();

                byte[] ab = new byte[6];
                int len = ab.Length;

                // This Function Used to Get The Physical Address
                int r = SendARP((int)TempA.Address, 0, ab, ref len);
                string mac = BitConverter.ToString(ab, 0, 6);

                Ipaddr[2] = mac;
            }
            arlMACAddress.Add(Ipaddr[2].ToString());

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="DomainName"></param>
        /// <returns></returns>
        public string GetHostName(string Address, string DomainName)
        {
            DirectoryEntry DomainEntry = new DirectoryEntry("WinNT://" + DomainName.Trim());
            DomainEntry.Children.SchemaFilter.Add("computer");
            foreach (DirectoryEntry machine in DomainEntry.Children)
            {
                string[] Ipaddr = new string[3];
                Ipaddr[0] = machine.Name;
                System.Net.IPHostEntry Tempaddr = null;
                try
                {
                    Tempaddr = (System.Net.IPHostEntry)Dns.GetHostByName(machine.Name);
                    if(Address == Dns.GetHostByName(machine.Name).AddressList[0].ToString())
                        return machine.Name;
                }
                catch (Exception ex)
                {
                    arlUnreachableComputers.Add(machine.Name);
                    continue;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DomainName"></param>
        public void getNetworkComputerInformation(string DomainName)
        {
            arlComputerName = new ArrayList();
            arlIpAddress = new ArrayList();
            arlMACAddress = new ArrayList();
            arlUnreachableComputers = new ArrayList();
            try
            {
                DirectoryEntry DomainEntry = new DirectoryEntry("WinNT://" + DomainName.Trim());
                DomainEntry.Children.SchemaFilter.Add("computer");
                foreach (DirectoryEntry machine in DomainEntry.Children)
                {
                    string[] Ipaddr = new string[3];
                    Ipaddr[0] = machine.Name;
                    System.Net.IPHostEntry Tempaddr = null;
                    try
                    {
                        Tempaddr = (System.Net.IPHostEntry)Dns.GetHostByName(machine.Name);
                        arlIpAddress.Add(Dns.GetHostByName(machine.Name).AddressList[0].ToString());
                        arlComputerName.Add(machine.Name);
                    }
                    catch (Exception ex)
                    {
                        arlUnreachableComputers.Add(machine.Name);
                        continue;
                    }
                    System.Net.IPAddress[] TempAd = Tempaddr.AddressList;
                    foreach (IPAddress TempA in TempAd)
                    {
                        Ipaddr[1] = TempA.ToString();

                        byte[] ab = new byte[6];
                        int len = ab.Length;

                        // This Function Used to Get The Physical Address
                        int r = SendARP((int)TempA.Address, 0, ab, ref len);
                        string mac = BitConverter.ToString(ab, 0, 6);

                        Ipaddr[2] = mac;
                    }
                    arlMACAddress.Add(Ipaddr[2].ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK);
                //Application.Exit();
            }
        }
        #endregion Computer History Logic

        #region Send Mail
        public string SendEmailMessage(string strFrom, string strTo, string strCc, string strSubject, string strMessage, string fileList, string SmtpAddress)
        {
            //This procedure overrides the first procedure and accepts a single
            try
            {
                //For each to address create a mail message
                MailMessage MailMsg = new MailMessage(new MailAddress(strFrom.Trim()), new MailAddress(strTo));
                if (strCc != "")
                    MailMsg.CC.Add(new MailAddress(strCc));
                MailMsg.BodyEncoding = Encoding.Default;
                MailMsg.Subject = strSubject.Trim();
                MailMsg.Body = strMessage;
                MailMsg.Priority = MailPriority.High;
                MailMsg.IsBodyHtml = true;

                //attach each file attachment
                if (fileList != "")
                {
                    Attachment MsgAttach = new Attachment(fileList);
                    MailMsg.Attachments.Add(MsgAttach);
                }

                //Smtpclient to send the mail message
                SmtpClient SmtpMail = new SmtpClient();
                SmtpMail.Host = SmtpAddress;
                SmtpMail.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                SmtpMail.Send(MailMsg);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
       
        public string SendEmailMessage(string strFrom, string strTo, string strCc, string strSubject, string strMessage, FileInfo[] fileList,string SmtpAddress)
        {
            //This procedure overrides the first procedure and accepts a single
            try
            {
                //For each to address create a mail message
                MailMessage MailMsg = new MailMessage(new MailAddress(strFrom.Trim()), new MailAddress(strTo));
                if (strCc != "")
                    MailMsg.CC.Add(new MailAddress(strCc));
                MailMsg.BodyEncoding = Encoding.Default;
                MailMsg.Subject = strSubject.Trim();
                MailMsg.Body = strMessage;
                MailMsg.Priority = MailPriority.High;
                MailMsg.IsBodyHtml = true;

                //attach each file attachment
                if (fileList != null)
                {
                    foreach (FileInfo fl in fileList)
                    {
                        Attachment MsgAttach = new Attachment(fl.FullName);
                        MailMsg.Attachments.Add(MsgAttach);
                    }
                }

                //Smtpclient to send the mail message
                SmtpClient SmtpMail = new SmtpClient();
                SmtpMail.Host = SmtpAddress;
                SmtpMail.Port = 25;
                SmtpMail.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                SmtpMail.Send(MailMsg);
                MailMsg.Dispose();
                
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static int FindUnusedLocalPort()
        {
            TcpListener portChooser = new TcpListener(IPAddress.Loopback, 0);
            int connectionPort;

            portChooser.Start();
            connectionPort = ((IPEndPoint)portChooser.LocalEndpoint).Port;
            portChooser.Stop();

            return connectionPort;
        }
        #endregion
    }
    /// <summary>
    /// Purpose : It is used in ValidateUserPath method to check valid LDAP user and group.
    /// </summary>
    public enum ObjectClass
    {
        User, Group
    }

}
