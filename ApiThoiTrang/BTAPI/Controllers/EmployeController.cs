using API.Models.Entity;
using API.Responsitory;
using API.Models.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class EmployeController : Controller
    {
        private IRepository<Employes> employes;
        private IRepository<GroupUser> groupUsers;
        public EmployeController()
        {
            employes = new Repository<Employes>();
            groupUsers = new Repository<GroupUser>();
        }
        // GET: Admin/User
        public ActionResult Index(string findName, int? page)
        {
            var data = employes.GetAll();
            data = employes.GetInclude("GroupUsers").AsEnumerable();
            if (!String.IsNullOrEmpty(findName))
            {
                data = employes.GetInclude("GroupUsers").Where(x => x.Name.Contains(findName) || x.Phone.Contains(findName) || x.Email.Contains(findName));
            }

            if (page == null)
            {
                page = 1;
            }

            var pageData = data.OrderBy(x => x.Id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            //var d = pageData.ToPagedList(pageNumber, pageSize);

            return View(data);

        }


        public ActionResult Create()
        {
            var data = groupUsers.GetAll();
            ViewBag.grpUser = data;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employes input)
        {
            //input.Password = Unnity.EncryptString(input.Password);
            employes.Add(input);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = groupUsers.GetAll();
            ViewBag.grpUser = data;
            Employes empl = employes.GetById(id);
            //empl.Password = Unnity.DecryptString(empl.Password);
            return View(empl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employes input)
        {

            //if (employes.GetAll().Any(x => x.Name.Equals(input.Name) && x.Id != input.Id))
            //{
            //    ModelState.AddModelError("UserName", "User name has been existed.");
            //}
            if (ModelState.IsValid)
            {

                employes.Edit(input);
                return RedirectToAction("Index");
            }
            return View(input);
        }

        public ActionResult Delete(int id)
        {
            employes.Remove(id);
            return RedirectToAction("Index");
        }

    }
}