#region Includes

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;

#endregion

namespace Daishi.Armor.WebFramework {
    public class ArmorFortify {
        private readonly IdentityReaderFactory identityReaderFactory;
        private readonly HttpContext httpContext;

        public ArmorFortify(IdentityReaderFactory identityReaderFactory, HttpContext httpContext) {
            this.identityReaderFactory = identityReaderFactory;
            this.httpContext = httpContext;
        }

        public bool TryFortify() {
            var identityReader = identityReaderFactory.Create();
            IEnumerable<Claim> identity;

            var isAuthenticated = identityReader.TryRead(out identity);
            if (!isAuthenticated) return false;

            var claims = identity.ToList();

            var userId = claims.Single(c => c.Type.Equals("UserId")).Value;
            var platform = claims.Single(c => c.Type.Equals("Platform")).Value;

            var encryptionKey = Convert.FromBase64String(ConfigurationManager.AppSettings["ArmorEncryptionKey"]);
            var hashingKey = Convert.FromBase64String(ConfigurationManager.AppSettings["ArmorHashKey"]);

            var nonceGenerator = new NonceGenerator();
            nonceGenerator.Execute();

            var armorToken = new ArmorToken(userId, platform, nonceGenerator.Nonce);

            var armorTokenConstructor = new ArmorTokenConstructor();
            var standardSecureArmorTokenBuilder = new StandardSecureArmorTokenBuilder(armorToken, encryptionKey, hashingKey);
            var generateSecureArmorToken = new GenerateSecureArmorToken(armorTokenConstructor, standardSecureArmorTokenBuilder);

            generateSecureArmorToken.Execute();

            httpContext.Response.AppendHeader("ARMOR", generateSecureArmorToken.SecureArmorToken);
            return true;
        }
    }
}