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
        private IRepository<Employes> employes;
        private DbConn db;
        public HomeController()
        {
            db = new DbConn();
            ColerTable = new Repository<Color>();
            employes = new Repository<Employes>();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var password = Unnity.EncryptString(_password);
                    var data = employes.GetAll().FirstOrDefault(x=>x.Email == email);
                    if (data != null)
                    {
                       if (data.Password.Equals(password) && data.Status == false)
                       {
                            //MessageBox.Show("Tài khoản đã bị khóa");
                            //MessageBox.Show("This account has been locked! Because you login more 3 times.");
                            ModelState.AddModelError("Name", "GroupName is existed.");
                            return RedirectToAction("Login");
                       }
                        else if (data.Password.Equals(password) && data.Status == true)
                        {
                                Session["admin"] = data;
                                Session["email"] = data.Email;
                                Session["username"] = data.Name;
                                Session["UserId"] = data.Id;
                                Session["Layout"] = "~/Views/Shared/_LayoutAdmin.cshtml";
                                return RedirectToAction("Index", "Coler");
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Email không đúng.");
                        //ViewBag.Message = "You input wrong password or email";
                        return RedirectToAction("Login");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public ActionResult Error()
        {
            return View();
        }

    }
}
