using API.Responsitory;
using API.Models.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    [CustomAuthorize]
    public class BusinessController : Controller
    {
        
            // GET: Admin/Business
            private IRepository<Business> business;
            private IRepository<Permission> permiss;

            public BusinessController()
            {
                business = new Repository<Business>();
                permiss = new Repository<Permission>();
            }

            public ActionResult Index()
            {
                var data = business.GetAll();
                return View(data);
            }

            public ActionResult Update()
            {
                var control = Helper.GetControllers("API.Controllers");
                foreach (var ctrl in control)
                {
                    Business b = new Business()
                    {
                        Id = ctrl.Name,
                        Name = ctrl.Name.Substring(0, ctrl.Name.IndexOf("Controll")),
                        Status = true
                    };
                    if (!business.GetAll().Any(x => x.Id.Equals(b.Id)))
                    {
                        business.Add(b);

                    }
                    var action = Helper.GetActions(ctrl);
                    foreach (var act in action)
                    {
                        Permission p = new Permission()
                        {
                            Id = ctrl.Name + "-" + act,
                            Name = act,
                            BusinessId = ctrl.Name,
                            Status = false
                        };
                        if (!permiss.GetAll().Any(x => x.Id.Equals(p.Id)))
                        {
                            permiss.Add(p);
                        }
                    }
                }
                return RedirectToAction("Index");

            }
        
    }
}
