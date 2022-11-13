using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class ColerController : Controller
    {
        private IRepository<Color> ColerTable;
        public ColerController()
        {
            ColerTable = new Repository<Color>();
        }
        // GET: Coler
        public ActionResult Index()
        {
            return View(ColerTable.GetAll());
        }

        // GET: Coler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coler/Create
        [HttpPost]
        public ActionResult Create(Color input)
        {
            try
            {
                ColerTable.Add(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create"); ;
            }
        }

        // GET: Coler/Edit/5
        public ActionResult Edit(int id)
        {
            var byId = ColerTable.GetById(id);
            return View(byId);
        }

        // POST: Coler/Edit/5
        [HttpPost]
        public ActionResult Edit(Color input)
        {
            try
            {
                ColerTable.Edit(input);
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
                ColerTable.Remove(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
