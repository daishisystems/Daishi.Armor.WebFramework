#region Includes

using System;
using System.Configuration;
using System.Threading;
using System.Web;
using System.Web.Mvc;

#endregion

namespace Daishi.Armor.WebFramework {
    public class MvcArmorAuthorizeAttribute : AuthorizeAttribute {
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            var isArmed =
                Convert.ToBoolean(ConfigurationManager.AppSettings["IsArmed"]);
            if (!isArmed) return true;

            var armorAuthorize =
                new ArmorAuthorize(
                    new MvcHttpRequestArmorHeaderParserFactory(
                        httpContext.Request.Headers),
                    new MvcIdentityReaderFactory(Thread.CurrentPrincipal));
            return armorAuthorize.Authorize();
        }
    }
}