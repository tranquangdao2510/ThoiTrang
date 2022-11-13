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
        private IRepository<Employes> users;
        private IRepository<GroupUser> groupUsers;
        public EmployeController()
        {
            users = new Repository<Employes>();
            groupUsers = new Repository<GroupUser>();
        }
        // GET: Admin/User
        public ActionResult Index(string findName, int? page)
        {
            var data = users.GetAll();
            data = users.GetInclude("GroupUsers").AsEnumerable();
            if (!String.IsNullOrEmpty(findName))
            {
                data = users.GetInclude("GroupUsers").Where(x => x.Name.Contains(findName) || x.Phone.Contains(findName) || x.Email.Contains(findName));
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
            
            users.Add(input);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = groupUsers.GetAll();
            ViewBag.grpUser = data;

            Employes user = users.GetById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employes input)
        {
            var data = groupUsers.GetAll();
            ViewBag.grpUser = data;

            var _us = users.GetById(input.Id);

            if (users.GetAll().Any(x => x.Name.Equals(input.Name) && x.Id != input.Id))
            {
                ModelState.AddModelError("UserName", "User name has been existed.");
            }
            if (ModelState.IsValid)
            {
                users.Edit(input);
                return RedirectToAction("Index");
            }
            return View(input);
        }

        public ActionResult Delete(int id)
        {
            users.Remove(id);
            return RedirectToAction("Index");
        }

    }
}