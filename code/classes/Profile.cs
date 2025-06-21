using System;
using System.Runtime.Versioning;

using Microsoft.Win32;

namespace KON.NetworkProfileEditor
{
    [SupportedOSPlatform("windows7.0")]
    public class Profile
    {
        public RegistryKey rgRegistryKey;
        public string strGUID;
        public string strName;
        public string strDescription;
        public DateTime dtDateCreated;
        public DateTime dtDateLastConnected;
        public ePropertyManaged epmManaged;
        public ePropertyCategory epcCategory;
        public ePropertyNameType epntNameType;

        public Profile(string strLocalGUID, RegistryKey rgLocalRegistryKey)
        {
            rgRegistryKey = rgLocalRegistryKey;
            strGUID = strLocalGUID;
            strName = Convert.ToString(rgLocalRegistryKey.GetValue("ProfileName"));
            strDescription = Convert.ToString(rgLocalRegistryKey.GetValue("Description"));
            dtDateCreated = Global.GetDateFromRegistry(rgLocalRegistryKey.GetValue("DateCreated"));
            dtDateLastConnected = Global.GetDateFromRegistry(rgLocalRegistryKey.GetValue("DateLastConnected"));
            epmManaged = (ePropertyManaged)Convert.ToInt32(rgLocalRegistryKey.GetValue("Managed"));
            epcCategory = (ePropertyCategory)Convert.ToInt32(rgLocalRegistryKey.GetValue("Category"));
            epntNameType = (ePropertyNameType)Convert.ToInt32(rgLocalRegistryKey.GetValue("NameType"));
        }

        public override string ToString()
        {
            return strName;
        }
    }
}