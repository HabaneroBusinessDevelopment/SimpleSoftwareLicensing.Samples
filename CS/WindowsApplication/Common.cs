using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Habanero.Licensing.Validation;

namespace WindowsApplication
{
    internal static class Common
    {
        private static string LicenseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SampleApplication");
        private static string LicenseFileName = "SampleLicenseFile.lic";
        private static string LicenseFileLocation = Path.Combine(LicenseFolder, LicenseFileName);
        

        //create code for applicationsecret - taken from the License Manager application
        static byte[] applicationSecret = Convert.FromBase64String("JdZlrqJqbEemYDIaUXTKVQ==");
        //create code for public key - taken from the License Manager application
        static byte[] publicKey = Convert.FromBase64String("BgIAAACkAABSU0ExAAIAAAEAAQCJVIQQWZoDItPbDQMMsz+Q3Sz2Z+iBFZuKNPQG1cTSToOoSQpZ35VAx9bPSvRURvOrktPbMZeGW0TwpuoLFT6q");

        private static string productName = "Demo product 2012";

        internal static LicenseValidator FileValidator
        {
            get
            {
                //make sure that the license folder exists
                var licensePath = Path.GetDirectoryName(LicenseFileLocation);
                if (!Directory.Exists(licensePath))
                    Directory.CreateDirectory(licensePath);
                //now return the validator
                return new LicenseValidator(LicenseLocation.File, LicenseFileLocation, productName, publicKey, applicationSecret, ThisVersion);
            }
        }

        //this demonstrates using isolated storage instead of a regular file.
        internal static LicenseValidator IsolatedStorageValidator
        {
            get
            {
                //now return the validator
                return new LicenseValidator(LicenseLocation.UserIsolatedStorage, LicenseFileName, productName, publicKey, applicationSecret, ThisVersion);
            }
        }

        internal static Version ThisVersion
        {
            get
            {
                //Get the executing files filesversion
                var fileversion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                var myVersion = new Version(fileversion.FileMajorPart, fileversion.FileMinorPart, fileversion.FileBuildPart, fileversion.FilePrivatePart);

                return myVersion;
            }
        }

        internal static string[] StandardOrHigher = new string[3] { "Standard", "Pro","Enterprise" };
        internal static string[] ProOrHigher = new string[2] { "Pro", "Enterprise" };
       internal static string[] EnterpriseOrHigher = new string[1] { "Enterprise" };
    }
}
