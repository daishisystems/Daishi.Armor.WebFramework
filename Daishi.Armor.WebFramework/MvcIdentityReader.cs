#region Includes

using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

#endregion

namespace Daishi.Armor.WebFramework {
    public class MvcIdentityReader : IdentityReader {
        public MvcIdentityReader(IPrincipal principal) : base(principal) {}

        public override bool TryRead(out IEnumerable<Claim> identity) {
            var claims = new List<Claim>();
            identity = claims;

            if (!principal.Identity.IsAuthenticated) return false;

            claims.AddRange(new List<Claim> {
                new Claim("UserId", principal.Identity.Name),
            });

            return true;
        }
    }
}