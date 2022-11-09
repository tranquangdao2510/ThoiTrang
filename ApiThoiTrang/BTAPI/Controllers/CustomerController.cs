using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTAPI.Controllers
{
    public class CustomerController : Controller
    {
        private IRepository<Customer> Table;
        public CustomerController()
        {
            Table = new Repository<Customer>();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(Table.GetAll());
        }


        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer input)
        {
            try
            {
                // TODO: Add insert logic here
                Table.Add(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var byId = Table.GetById(id);
            return View(byId);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer input)
        {
            try
            {
                // TODO: Add update logic heres
                Table.Edit(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Table.Remove(id);
            return RedirectToAction("Index");
        }
     
    }
}
