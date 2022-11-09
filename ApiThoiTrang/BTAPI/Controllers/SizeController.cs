using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTAPI.Controllers
{
    public class SizeController : Controller
    {
        private IRepository<Size> Table;

        public SizeController()
        {
            Table = new Repository<Size>();

        }
        // GET: Size
        public ActionResult Index()
        {
            return View(Table.GetAll());
        }

        // GET: Size/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Size/Create
        [HttpPost]
        public ActionResult Create(Size input)
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

        // GET: Size/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Table.GetById(id));
        }

        // POST: Size/Edit/5
        [HttpPost]
        public ActionResult Edit(Size input)
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
            Table.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
