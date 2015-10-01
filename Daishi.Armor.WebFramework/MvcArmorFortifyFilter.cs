#region Includes

using System;
using System.Configuration;
using System.Web.Mvc;

#endregion

namespace Daishi.Armor.WebFramework {
    public class MvcArmorFortifyFilter : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            var isArmed = Convert.ToBoolean(ConfigurationManager.AppSettings["IsArmed"]);
            if (!isArmed) return;

            var armorFortify = new ArmorFortify(new MvcIdentityReaderFactory(filterContext.HttpContext.User), filterContext.HttpContext.ApplicationInstance.Context);
            var isFortified = armorFortify.TryFortify();

            if (isFortified)
                base.OnActionExecuted(filterContext);
            else filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}