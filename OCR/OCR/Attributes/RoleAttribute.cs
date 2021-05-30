using OCR.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OCR.Attributes
{
    public class RoleAttribute : ActionFilterAttribute
    {
        public string[] Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Roles.Contains(filterContext.HttpContext.Session["role"].ToString().ToLower()))
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "User"},
                        {"action", "SignOut"}
                    }
                );
        }
    }
}