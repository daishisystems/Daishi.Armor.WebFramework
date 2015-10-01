#region Includes

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;

#endregion

namespace Daishi.Armor.WebFramework {
    public class ArmorAuthorize {
        private readonly HttpRequestArmorHeaderParserFactory httpRequestArmorHeaderParserFactory;
        private readonly IdentityReaderFactory identityReaderFactory;

        public ArmorAuthorize(HttpRequestArmorHeaderParserFactory httpRequestArmorHeaderParserFactory, IdentityReaderFactory identityReaderFactory) {
            this.httpRequestArmorHeaderParserFactory = httpRequestArmorHeaderParserFactory;
            this.identityReaderFactory = identityReaderFactory;
        }

        public bool Authorize() {
            #region Read logged-in user claims

            var identityReader = identityReaderFactory.Create();
            IEnumerable<Claim> identity;

            var isAuthenticated = identityReader.TryRead(out identity);
            if (!isAuthenticated) return false;

            var claims = identity.ToList();
            var userId = claims.Single(c => c.Type.Equals("UserId")).Value;

            #endregion

            #region Ensure existence of ArmorToken in HTTP header

            var armorHeaderParser = httpRequestArmorHeaderParserFactory.Create();
            ArmorTokenHeader armorTokenHeader;

            var hasArmorTokenHeader = armorHeaderParser.TryParse(out armorTokenHeader);
            if (!hasArmorTokenHeader) return false;

            #endregion

            #region Validate ArmorToken

            var encryptionKey = Convert.FromBase64String(ConfigurationManager.AppSettings["ArmorEncryptionKey"]);
            var hashingKey = Convert.FromBase64String(ConfigurationManager.AppSettings["ArmorHashKey"]);
            var armorTimeOut = Convert.ToInt64(ConfigurationManager.AppSettings["ArmorTimeout"]);

            var secureArmorTokenValidator = new SecureArmorTokenValidator(armorTokenHeader.ArmorToken, encryptionKey, hashingKey, userId, armorTimeOut);
            secureArmorTokenValidator.Execute();

            return secureArmorTokenValidator.ArmorTokenValidationStepResult.IsValid;

            #endregion
        }
    }
}