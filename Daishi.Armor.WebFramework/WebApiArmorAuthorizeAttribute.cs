#region Includes

using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;

#endregion

namespace Daishi.Armor.WebFramework {
    public class WebApiArmorAuthorizeAttribute : AuthorizeAttribute {
        protected override bool IsAuthorized(HttpActionContext actionContext) {
            if (!ArmorSettings.IsArmed) return true;

            var armorAuthorize =
                new ArmorAuthorize(
                    new WebApiHttpRequestArmorHeaderParserFactory(
                        actionContext.Request.Headers),
                    new WebApiIdentityReaderFactory(Thread.CurrentPrincipal));
            return armorAuthorize.Authorize();
        }
    }
}