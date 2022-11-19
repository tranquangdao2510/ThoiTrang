using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTAPI.Controllers
{
    public class OrdelDetailController : Controller
    {
        private IRepository<OrderDetail> orderDetail;
        private IRepository<ProductDetail> productDetail;
        private IRepository<Order> order;

        public OrdelDetailController()
        {
            orderDetail = new Repository<OrderDetail>();
            order = new Repository<Order>();
            productDetail = new Repository<ProductDetail>();

        }
        // GET: Size
        public ActionResult Index()
        {
            return View(orderDetail.GetAll());
        }

        // GET: Size/Create
        public ActionResult Create()
        {
            ViewBag.order = order.GetAll();
            ViewBag.productDetail = productDetail.GetAll();
            return View();
        }

        // POST: Size/Create
        [HttpPost]
        public ActionResult Create(OrderDetail input)
        {
            try
            {
                // TODO: Add insert logic here
                orderDetail.Add(input);
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
            ViewBag.order = order.GetAll();
            ViewBag.productDetail = productDetail.GetAll();
            return View(orderDetail.GetById(id));
        }

        // POST: Size/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderDetail input)
        {
            try
            {
                // TODO: Add update logic here
                orderDetail.Edit(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }



        public ActionResult Delete(int id)
        {
            orderDetail.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
