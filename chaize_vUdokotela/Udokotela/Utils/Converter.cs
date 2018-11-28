using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Udokotela.Utils
{
    public class Converter
    {
        public static string SecureStringToString(SecureString secureString)
        {
            IntPtr stringBSTR = default(IntPtr);
            string insecureString = "";
            try
            {
                stringBSTR = Marshal.SecureStringToBSTR(secureString);
                insecureString = Marshal.PtrToStringBSTR(stringBSTR);
            }
            catch
            {
                insecureString = "";
            }
            return insecureString;
        }
    }
}
