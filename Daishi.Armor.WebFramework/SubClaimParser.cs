#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

#endregion

namespace Daishi.Armor.WebFramework {
    public class SubClaimParser {
        private readonly string subClaim;

        public SubClaimParser(string subClaim) {
            this.subClaim = subClaim;
        }

        public bool TryParse(out IEnumerable<Claim> identity) {
            var claims = new List<Claim>();
            identity = claims;

            var parsedClaims = subClaim.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            var userIdClaim = parsedClaims.SingleOrDefault(c => c.StartsWith("uid="));
            if (userIdClaim == null) return false;

            var userId = userIdClaim
                .Split(new[] {'='})
                .Last();

            var platformIdClaim = parsedClaims.SingleOrDefault(c => c.StartsWith("o="));
            if (platformIdClaim == null) return false;

            var platformId = platformIdClaim
                .Split(new[] {'='})
                .Last();

            claims.AddRange(new List<Claim> {new Claim("UserId", userId), new Claim("Platform", platformId)});
            return true;
        }
    }
}