﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LauncherLesAuDacieuX.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:/Program Files (x86)/Steam/steamapps/common/Arma 3/")]
        public string ARMA3_PATH {
            get {
                return ((string)(this["ARMA3_PATH"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\TeamSpeak 3 Client")]
        public string TS3_PATH {
            get {
                return ((string)(this["TS3_PATH"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("85.131.221.137")]
        public string SERVER_IP {
            get {
                return ((string)(this["SERVER_IP"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2302")]
        public int SERVER_PORT {
            get {
                return ((int)(this["SERVER_PORT"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("@CBA_A3;@task_force_radio;@LADX;")]
        public string ADDON_LIST {
            get {
                return ((string)(this["ADDON_LIST"]));
            }
            set {
                this["ADDON_LIST"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\85.131.221.137\\Arma 3\\")]
        public string REMOTE_ARMA3_PATH {
            get {
                return ((string)(this["REMOTE_ARMA3_PATH"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\85.131.221.137\\TeamSpeak 3 Client\\")]
        public string REMOTE_TS3_PATH {
            get {
                return ((string)(this["REMOTE_TS3_PATH"]));
            }
            set {
                this["REMOTE_TS3_PATH"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AuDacieuX.tmp")]
        public string TEMP_FILE_NAME {
            get {
                return ((string)(this["TEMP_FILE_NAME"]));
            }
            set {
                this["TEMP_FILE_NAME"] = value;
            }
        }
    }
}
