#region Includes

using System.Security.Principal;

#endregion

namespace Daishi.Armor.WebFramework {
    public class MvcIdentityReaderFactory : IdentityReaderFactory {
        public MvcIdentityReaderFactory(IPrincipal principal) : base(principal) {}

        public override IdentityReader Create() {
            return new MvcIdentityReader(principal);
        }
    }
}