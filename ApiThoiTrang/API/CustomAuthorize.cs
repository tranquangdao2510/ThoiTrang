using API.Models.Entity;
using API.Models.Entity.Admin;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            IRepository<GroupUser> _grUser = new Repository<GroupUser>();
            IRepository<GroupPermission> _grPer = new Repository<GroupPermission>();
            if (httpContext.Session["admin"] == null)
            {
                return false;
            }
            Employes us = (Employes)httpContext.Session["admin"];
            GroupUser groupUser = _grUser.GetById(us.GroupID);
            if (groupUser.IsAdmin)
            {
                return true;

            }
            string controll = httpContext.Request.RequestContext.RouteData.GetRequiredString("controller");
            string action = httpContext.Request.RequestContext.RouteData.GetRequiredString("action");
            string permiss = controll + "Controller-" + action;

            if (!_grPer.GetAll().Any(x => x.GroupId.Equals(us.GroupID) && x.PermissionId == permiss))
            {
                return false;
            }
            return true;

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Home/Error");
        }
    }
}