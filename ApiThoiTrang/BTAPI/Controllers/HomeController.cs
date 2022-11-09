using API.Models.DataModel;
using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Color> ColerTable;
        private DbConn db;
        public HomeController()
        {
            db = new DbConn();
            ColerTable = new Repository<Color>();
        }

        public ActionResult Index()
        {
            var data = ColerTable.GetAll();
            var da = (from i in db.Color.AsEnumerable()
                     select new Color
                     {
                         Id = i.Id,
                         Name = i.Name,
                         Status = i.Status,
                     });

            return View(data);
        }
    }
}
