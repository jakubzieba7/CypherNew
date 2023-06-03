using System.Configuration;

namespace CypherNew
{
    public static class DecryptCredentials
    {
        private static readonly StringCipher _stringCipher = new StringCipher("6F468B68-F6B8-4B61-8F4E-B4E858FCB497");
        private const string NotEncryptedPasswordPrefix = "encrypt:";


        public static string DecryptFromPhoneNumber()
        {
            var encryptedFromPhoneNumber = ConfigurationManager.AppSettings["FromPhoneNumber"];

            if (encryptedFromPhoneNumber.StartsWith(NotEncryptedPasswordPrefix))
            {
                encryptedFromPhoneNumber = _stringCipher
                    .Encrypt(encryptedFromPhoneNumber.Replace(NotEncryptedPasswordPrefix, ""));

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configFile.AppSettings.Settings["FromPhoneNumber"].Value = encryptedFromPhoneNumber;
                configFile.Save();
            }

            return _stringCipher.Decrypt(encryptedFromPhoneNumber);
        }

        public static string DecryptToPhoneNumber()
        {
            var encryptedToPhoneNumber = ConfigurationManager.AppSettings["ToPhoneNumber"];


            if (encryptedToPhoneNumber.StartsWith(NotEncryptedPasswordPrefix))
            {
                encryptedToPhoneNumber = _stringCipher
                    .Encrypt(encryptedToPhoneNumber.Replace(NotEncryptedPasswordPrefix, ""));

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configFile.AppSettings.Settings["ToPhoneNumber"].Value = encryptedToPhoneNumber;
                configFile.Save();
            }

            return _stringCipher.Decrypt(encryptedToPhoneNumber);
        }

        public static string DecryptAccountSID()
        {
            var encryptedAccountSID = ConfigurationManager.AppSettings["AccountSID"];


            if (encryptedAccountSID.StartsWith(NotEncryptedPasswordPrefix))
            {
                encryptedAccountSID = _stringCipher
                    .Encrypt(encryptedAccountSID.Replace(NotEncryptedPasswordPrefix, ""));

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configFile.AppSettings.Settings["AccountSID"].Value = encryptedAccountSID;
                configFile.Save();
            }

            return _stringCipher.Decrypt(encryptedAccountSID);
        }

        public static string DecryptAuthToken()
        {
            var encryptedAuthToken = ConfigurationManager.AppSettings["AuthToken"];


            if (encryptedAuthToken.StartsWith(NotEncryptedPasswordPrefix))
            {
                encryptedAuthToken = _stringCipher
                    .Encrypt(encryptedAuthToken.Replace(NotEncryptedPasswordPrefix, ""));

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configFile.AppSettings.Settings["AuthToken"].Value = encryptedAuthToken;
                configFile.Save();
            }

            return _stringCipher.Decrypt(encryptedAuthToken);
        }
    }
}
