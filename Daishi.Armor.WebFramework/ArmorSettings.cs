#region Includes

using System;
using System.Configuration;

#endregion

namespace Daishi.Armor.WebFramework {
    // Since changes to the AppSettings will bounce the AppDomain, we can statically
    // cache the answer to all this configuration settings
    public static class ArmorSettings {
        private static byte[] s_EncryptionKey;
        public static byte[] EncryptionKey {
            get
            {
                if (s_EncryptionKey == null) {
                    s_EncryptionKey = Convert.FromBase64String(
                        ConfigurationManager.AppSettings["ArmorEncryptionKey"]);
                }

                return s_EncryptionKey;
            }
        }

        private static byte[] s_HashingKey;
        public static byte[] HashingKey {
            get
            {
                if (s_HashingKey == null) {
                    s_HashingKey = Convert.FromBase64String(
                        ConfigurationManager.AppSettings["ArmorHashKey"]);
                }

                return s_HashingKey;
            }
        }

        private static long? s_Timeout;
        public static long Timeout {
            get
            {
                if (!s_Timeout.HasValue) {
                    s_Timeout = Convert.ToInt64(
                        ConfigurationManager.AppSettings["ArmorTimeout"]);
                }

                return s_Timeout.Value;
            }
        }

        private static bool? s_IsArmed;
        public static bool IsArmed {
            get
            {
                if (!s_IsArmed.HasValue) {
                    s_IsArmed = Convert.ToBoolean(
                        ConfigurationManager.AppSettings["IsArmed"]);
                }

                return s_IsArmed.Value;
            }
        }
    }
}