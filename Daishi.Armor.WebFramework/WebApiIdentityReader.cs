#region Includes

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

#endregion

namespace Daishi.Armor.WebFramework {
    public class WebApiIdentityReader : IdentityReader {
        public WebApiIdentityReader(IPrincipal principal) : base(principal) {}

        public override bool TryRead(out IEnumerable<Claim> identity) {
            identity = new List<Claim>();

            var claimsIdentity = principal.Identity as ClaimsIdentity;
            if (claimsIdentity == null) return false;

            var subClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type.Equals("sub"));
            if (subClaim == null) return false;

            var subClaimParser = new SubClaimParser(subClaim.Value);
            return subClaimParser.TryParse(out identity);
        }
    }
}