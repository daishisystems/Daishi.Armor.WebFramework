#region Includes

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

#endregion

namespace Daishi.Armor.WebFramework {
    public class ArmorFortify {
        private readonly IdentityReaderFactory identityReaderFactory;
        private readonly HttpContext httpContext;

        public ArmorFortify(IdentityReaderFactory identityReaderFactory,
            HttpContext httpContext) {
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
            var platform = claims.SingleOrDefault(c => c.Type.Equals("Platform"));

            var encryptionKey = ArmorSettings.EncryptionKey;
            var hashingKey = ArmorSettings.HashingKey;

            var nonceGenerator = new NonceGenerator();
            nonceGenerator.Execute();

            var armorToken = new ArmorToken(userId,
                platform == null ? "ARMOR" : platform.Value,
                nonceGenerator.Nonce);

            var armorTokenConstructor = new ArmorTokenConstructor();
            var standardSecureArmorTokenBuilder =
                new StandardSecureArmorTokenBuilder(armorToken, encryptionKey,
                    hashingKey);
            var generateSecureArmorToken =
                new GenerateSecureArmorToken(armorTokenConstructor,
                    standardSecureArmorTokenBuilder);

            generateSecureArmorToken.Execute();

            httpContext.Response.AppendHeader("ARMOR",
                generateSecureArmorToken.SecureArmorToken);
            return true;
        }
    }
}