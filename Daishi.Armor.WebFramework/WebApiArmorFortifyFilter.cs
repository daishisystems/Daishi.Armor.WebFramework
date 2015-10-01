#region Includes

using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

#endregion

namespace Daishi.Armor.WebFramework {
    public class WebApiArmorFortifyFilter : ActionFilterAttribute {
        public override void OnActionExecuted(
            HttpActionExecutedContext actionExecutedContext) {
            if (!ArmorSettings.IsArmed) return;

            var armorFortify =
                new ArmorFortify(
                    new WebApiIdentityReaderFactory(Thread.CurrentPrincipal),
                    HttpContext.Current);
            var isFortified = armorFortify.TryFortify();

            if (isFortified)
                base.OnActionExecuted(actionExecutedContext);
            else throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}