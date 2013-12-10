#region Includes

using System.Security.Principal;

#endregion

namespace Daishi.Armor.WebFramework {
    public abstract class IdentityReaderFactory {
        protected readonly IPrincipal principal;

        protected IdentityReaderFactory(IPrincipal principal) {
            this.principal = principal;
        }

        public abstract IdentityReader Create();
    }
}