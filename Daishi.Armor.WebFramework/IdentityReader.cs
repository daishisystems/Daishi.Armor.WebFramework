#region Includes

using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

#endregion

namespace Daishi.Armor.WebFramework {
    public abstract class IdentityReader {
        protected readonly IPrincipal principal;

        protected IdentityReader(IPrincipal principal) {
            this.principal = principal;
        }

        public abstract bool TryRead(out IEnumerable<Claim> identity);
    }
}