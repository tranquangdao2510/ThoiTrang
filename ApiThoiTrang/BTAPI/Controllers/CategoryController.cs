using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTAPI.Controllers
{
    public class CategoryController : Controller
    {
        private IRepository<Category> Table;
        public CategoryController()
        {
            Table = new Repository<Category>();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(Table.GetAll());
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category input)
        {
            try
            {
                // TODO: Add insert logic here
                Table.Add(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Table.GetById(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category input)
        {
            try
            {
                // TODO: Add update logic here
                Table.Edit(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Table.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
