using System;
using System.Runtime.Versioning;

using Microsoft.Win32;

namespace KON.NetworkProfileEditor
{
    [SupportedOSPlatform("windows7.0")]
    public class Signature
    {
        public RegistryKey rgRegistryKey;
        public ePropertyManaged epmManaged;
        public string strSignatureID;
        public string strProfileGUID;
        public string strDescription;
        public string strDNSSuffix;
        public string strFirstNetwork;
        public string strDefaultGatewayMAC;
        public int iSource;

        public Signature(string strLocalSignatureID, RegistryKey rgLocalRegistryKey)
        {
            rgRegistryKey = rgLocalRegistryKey;
            strSignatureID = strLocalSignatureID;
            strProfileGUID = Convert.ToString(rgLocalRegistryKey.GetValue("ProfileGuid"));
            strDescription = Convert.ToString(rgLocalRegistryKey.GetValue("Description"));
            strDNSSuffix = Convert.ToString(rgLocalRegistryKey.GetValue("DnsSuffix"));
            strFirstNetwork = Convert.ToString(rgLocalRegistryKey.GetValue("FirstNetwork"));
            strDefaultGatewayMAC = BitConverter.ToString((byte[])rgLocalRegistryKey.GetValue("DefaultGatewayMac"));
            iSource = Convert.ToInt32(rgLocalRegistryKey.GetValue("Source"));
        }

        public override string ToString()
        {
            return strSignatureID;
        }
    }
}