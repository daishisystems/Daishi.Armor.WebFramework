#region Includes

using System.Security.Principal;

#endregion

namespace Daishi.Armor.WebFramework {
    public class WebApiIdentityReaderFactory : IdentityReaderFactory {
        public WebApiIdentityReaderFactory(IPrincipal principal)
            : base(principal) {}

        public override IdentityReader Create() {
            return new WebApiIdentityReader(principal);
        }
    }
}