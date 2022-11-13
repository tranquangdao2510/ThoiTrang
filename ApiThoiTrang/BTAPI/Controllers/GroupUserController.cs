using API.Responsitory;
using API.Models.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class GroupUserController : Controller
    {
        private IRepository<GroupUser> grpUsers;
        private IRepository<Business> business;
        private IRepository<Permission> permission;
        private IRepository<GroupPermission> grouppermission;


        public GroupUserController()
        {
            grpUsers = new Repository<GroupUser>();
            business = new Repository<Business>();
            permission = new Repository<Permission>();
            grouppermission = new Repository<GroupPermission>();
        }

        // GET: Admin/GroupUser
        public ActionResult Index(string findName, int? page)
        {
            var data = grpUsers.GetAll();
            if (!String.IsNullOrEmpty(findName))
            {
                data = grpUsers.Get(x => x.Name.Contains(findName));
            }

            if (page == null)
            {
                page = 1;
            }

            var pageData = data.OrderBy(x => x.Id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            //var d = pageData.ToPagedList(pageNumber, pageSize);

            //return View(d);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GroupUser group)
        {
            if (grpUsers.GetAll().Any(x => x.Name.Equals(group.Name)))
            {
                ModelState.AddModelError("Name", "GroupName is existed.");
            }
            if (ModelState.IsValid)
            {
                grpUsers.Add(group);
                return RedirectToAction("Index");
            }
            return View(group);
        }

        public ActionResult Edit(int id)
        {
            GroupUser grp = grpUsers.GetById(id);
            return View(grp);
        }

        [HttpPost]
        public ActionResult Edit(GroupUser group)
        {
            if (grpUsers.GetAll().Any(x => x.Name.Equals(group.Name) && x.Id != group.Id))
            {
                ModelState.AddModelError("Name", "GroupName is existed.");
            }
            if (ModelState.IsValid)
            {
                grpUsers.Edit(group);
                return RedirectToAction("Index");
            }
            return View(group);
        }

        public ActionResult Delete(int id)
        {
            grpUsers.Remove(id);
            return RedirectToAction("Index");
        }
        public ActionResult GreanPermission(int groupId)
        {
            var _business = business.GetAll().ToList();
            foreach (var item in _business)
            {
                var _premisstion = permission.GetAll().Where(x => x.BusinessId.Equals(item.Id)).ToList();

                foreach (var pre in _premisstion)
                {
                    if (grouppermission.GetAll().Where(x => x.GroupId == groupId && x.PermissionId.Equals(pre.Id)).Count() > 0)
                    {
                        pre.Status = true;
                    }
                    else
                    {
                        pre.Status = false;
                    }
                    item.Permissions = _premisstion;
                }
            }
            ViewBag.gropId = groupId;
            return View(_business);
        }
        [HttpPost]
        public ActionResult Grean(int gropId, string premissionId)
        {
            string mgs = "";
            var gropper = grouppermission.Get(x => x.GroupId == gropId && x.PermissionId.Equals(premissionId)).FirstOrDefault();
            if (gropper != null)
            {
                grouppermission.Remove(gropper);
                mgs = "Cancel permission successfully";
            }
            else
            {
                grouppermission.Add(new GroupPermission { GroupId = gropId, PermissionId = premissionId });
                mgs = "Successful Authorization!";
            }
            return Json(new { Message = mgs }, JsonRequestBehavior.AllowGet);

        }
    }
}