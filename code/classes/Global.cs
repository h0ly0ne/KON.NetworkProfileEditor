using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Windows.Forms;

using Microsoft.Win32;

namespace KON.NetworkProfileEditor
{
    public enum ePropertyManaged
    {
        Unmanaged = 0x0,
        Managed = 0x1
    }
    public enum ePropertyCategory
    {
        Public = 0x0,
        Private = 0x1,
        Domain = 0x2,
    }
    public enum ePropertyNameType
    {
        Wired = 0x06,
        VPN = 0x17,
        Wireless = 0x47,
        Mobile = 0xF3
    }

    [SupportedOSPlatform("windows7.0")]
    public static class Global
    {
        public static void LoadProfiles(ListBox lbTargetListBox)
        {
            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                try
                {
                    RegistryKey rkProfiles = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles", writable: true);
                    if (rkProfiles != null)
                    {
                        string[] saProfiles = rkProfiles.GetSubKeyNames();
                        foreach (string strProfile in saProfiles)
                        {
                            RegistryKey rkProfile = rkProfiles.OpenSubKey(strProfile, writable: true);
                            lbTargetListBox.Items.Add(new Profile(strProfile, rkProfile));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static Signature LoadSignature(ePropertyManaged epmLocalManaged, string strLocalProfileGUID)
        {
            Signature sLocalSignature = null;

            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                try
                {
                    RegistryKey rkSignatures;
                    if (epmLocalManaged == ePropertyManaged.Managed)
                        rkSignatures = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Managed", writable: true);
                    else
                        rkSignatures = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged", writable: true);

                    if (rkSignatures != null)
                    {
                        string[] saSignatures = rkSignatures.GetSubKeyNames();
                        foreach (string strSignature in saSignatures)
                        {
                            RegistryKey rkSignature = rkSignatures.OpenSubKey(strSignature, writable: true);
                            if(Convert.ToString(rkSignature.GetValue("ProfileGuid")).Equals(strLocalProfileGUID)) {
                                sLocalSignature = new Signature(strSignature, rkSignature);
                                sLocalSignature.strProfileGUID = strLocalProfileGUID;
                                sLocalSignature.strDescription = Convert.ToString(rkSignature.GetValue("Description"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            

            return sLocalSignature;
        }

        public static void RemoveSignatureForProfile(ePropertyManaged epmLocalManaged, string strLocalProfileGUID)
        {
            try
            {
                RegistryKey rkSignatures;
                if (epmLocalManaged == ePropertyManaged.Managed)
                    rkSignatures = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Managed", writable: true);
                else
                    rkSignatures = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged", writable: true);

                if (rkSignatures != null)
                {
                    string[] saSignatures = rkSignatures.GetSubKeyNames();
                    foreach (string strSignature in saSignatures)
                    {
                        RegistryKey rkSignature = rkSignatures.OpenSubKey(strSignature, writable: true);
                        if (Convert.ToString(rkSignature.GetValue("ProfileGuid")).Equals(strLocalProfileGUID))
                            rkSignatures.DeleteSubKey(strSignature);
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void CleanupSignatures()
        {
            RegistryKey rkSignatures = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Managed", writable: true);

            if (rkSignatures != null)
            {
                string[] saSignatures = rkSignatures.GetSubKeyNames();
                foreach (string strSignature in saSignatures)
                {
                    RegistryKey rkSignature = rkSignatures.OpenSubKey(strSignature, writable: true);
                    if (!Global.ProfileExists(Convert.ToString(rkSignature.GetValue("ProfileGuid"))))
                        rkSignatures.DeleteSubKey(strSignature);
                }
            }

            rkSignatures = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged", writable: true);

            if (rkSignatures != null)
            {
                string[] saSignatures = rkSignatures.GetSubKeyNames();
                foreach (string strSignature in saSignatures)
                {
                    RegistryKey rkSignature = rkSignatures.OpenSubKey(strSignature, writable: true);
                    if (!Global.ProfileExists(Convert.ToString(rkSignature.GetValue("ProfileGuid"))))
                        rkSignatures.DeleteSubKey(strSignature);
                }
            }
        }

        public static bool ProfileExists(string strLocalProfileGUID)
        {
            if (OperatingSystem.IsWindows() && OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                try
                {
                    RegistryKey rkProfiles = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles", writable: true);
                    if (rkProfiles != null)
                    {
                        string[] saProfiles = rkProfiles.GetSubKeyNames();
                        foreach (string strProfile in saProfiles)
                        {
                            if (strProfile.Equals(strLocalProfileGUID))
                                return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return false;
        }
        public static DateTime GetDateFromRegistry(object oRegistryValue)
        {
            DateTime dtReturnValue = DateTime.Now;
            byte[] baRegistryValue = oRegistryValue as byte[];

            List<string> strlValueList = new List<string>();

            for (int i = 0; i < baRegistryValue.Length; i += 2)
            {
                strlValueList.Add(baRegistryValue[i + 1].ToString("x2") + baRegistryValue[i].ToString("x2"));
            }

            dtReturnValue = new DateTime(Convert.ToInt32(strlValueList[0], 16), Convert.ToInt32(strlValueList[1], 16), Convert.ToInt32(strlValueList[3], 16), Convert.ToInt32(strlValueList[4], 16), Convert.ToInt32(strlValueList[5], 16), Convert.ToInt32(strlValueList[6], 16));
            return dtReturnValue;
        }
    }
}