﻿namespace SQT.FRAMEWORK.DAL 
{
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    public sealed partial class DBConnection : global::System.Configuration.ApplicationSettingsBase 
    {
        
        private static DBConnection defaultInstance = ((DBConnection)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new DBConnection())));
        
        public static DBConnection Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=VEGA;User Id=hari;Password=hari;Integrated Security=no;")]
        public string Oracle {
            get {
                return ((string)(this["Oracle"]));
            }
            set {
                this["Oracle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Driver={Microsoft ODBC for Oracle};Server=Vega.world;Uid=hari;Pwd=hari;")]
        public string Odbc {
            get {
                return ((string)(this["Odbc"]));
            }
            set {
                this["Odbc"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=OraOLEDB.Oracle;Data Source=Vega;User Id=hari;Password=hari; ")]
        public string Oledb {
            get {
                return ((string)(this["Oledb"]));
            }
            set {
                this["Oledb"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=HARI;Initial Catalog=QuestPMS;User ID=sa; Password=HariKiUmlup01cli;ti" +
            "meout=60;")]
        public string SQL {
            get {
                return ((string)(this["SQL"]));
            }
            set {
                this["SQL"] = value;
            }
        }
    }
}
