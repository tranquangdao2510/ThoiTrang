using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTAPI.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Order> table;
        private IRepository<Customer> tableCustomer;

        public OrderController()
        {
            table = new Repository<Order>();
            tableCustomer = new Repository<Customer>();

        }
        // GET: Order
        public ActionResult Index()
        {
            return View(table.GetAll());
        }
        
        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.Customer = tableCustomer.GetAll();
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order input)
        {
            try
            {
                // TODO: Add insert logic here
                table.Add(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Customer = tableCustomer.GetAll();
            return View(table.GetById(id));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(Order input)
        {
            try
            {
                // TODO: Add update logic here
                table.Edit(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            table.Remove(id);
            return RedirectToAction("Index");
        }
       
    }
}
