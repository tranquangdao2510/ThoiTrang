using BTAPI.Models.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace BTAPI.Controllers.API
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public DbConn db;
        public UserController()
        {
            db = new DbConn();
        }
        [HttpGet]
        [Route("lay_danh_sach")]
        public IHttpActionResult Get()
        {
            var data = db.users.AsEnumerable();
            return Content(HttpStatusCode.OK, new
            {
                data = data,
                status = 200,
                mess = "thanh cong"
            });
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var data = db.users.Where(x => x.id == id).SingleOrDefault();
            return Content(HttpStatusCode.OK, new
            {
                data = data,
                status = 200,
                mess = "thanh cong"
            });
        }
        [HttpPost]
        public IHttpActionResult Post(UserView userView)
        {
            
                if (db.users.AsNoTracking().Any(x => x.UserName.Equals(userView.UserName)))
                {
                    ModelState.AddModelError("UserName", "Tên đã tồn tại!");

                }
                if (ModelState.IsValid)
                {
                    var User = new User
                    {
                        UserName = userView.UserName,
                        Email = userView.Email,
                        Password = userView.Password,
                        Phone= userView.Phone,
                        Birthday= userView.Birthday,
                        status= userView.status,
                    };
                    //User.Avatar = UploadFiles();
                    //Xu ly anh
                    if (userView.img != null && userView.img.ContentLength > 0)
                    {
                        string path = HttpContext.Current.Server.MapPath("~/Content/Images/");
                        string filePath = path + userView.img.FileName;
                        userView.img.SaveAs(filePath);
                        User.Avatar = filePath;
                    }
                try
                {

                    db.users.Add(User);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
                    return Content(HttpStatusCode.OK, new Reponse<User>
                    {
                        StatusCode = 200,
                        Data = User,
                        Message = "Thêm mới thành công"
                    });
                
                    
                }
                Dictionary<string, string> errors = new Dictionary<string, string>();
                foreach (var k in ModelState.Keys)
                {
                    foreach (var err in ModelState[k].Errors)
                    {
                        string key = Regex.Replace(k, @"(\w+)\.(\w+)", @"$2");
                        if (!errors.ContainsKey(key))
                        {
                            errors.Add(key, err.ErrorMessage);
                        }
                    }
                }
            return Content(HttpStatusCode.OK, new
                {
                    Mess = "Lỗi",
                    data = errors,
                    status = 400
                });
        }
        //public string UploadFiles()
        //{
        //    //Create the Directory.
        //    string path = HttpContext.Current.Server.MapPath("~/Content/Images/");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    //Fetch the File.
        //    HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

        //    //Fetch the File Name.
        //    string fileName = (postedFile.FileName);

        //    //Save the File.
        //    postedFile.SaveAs(path + fileName);

        //    //Send OK Response to Client.
        //    //return Request.CreateResponse(HttpStatusCode.OK, fileName);
        //    return fileName;
        //    //return fileName;
        //}
        //[Route("api/User/UplaodImg")]
        //public string Upload(string img)
        //{
        //    try
        //    {
        //         var file = HttpContext.Current.Request.Files[0];
        //     //   var file = "/Content/Images/" +;
        //        var filename = Path.GetFileName(file.FileName);
        //        file.SaveAs(HttpContext.Current.Server.MapPath("~/Content/Images/" + filename));
        //        return "ok";
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        [HttpPut]
        public IHttpActionResult Put(UserView us)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    id =us.id,
                    UserName = us.UserName,
                    Password = us.Password,
                    Phone = us.Phone,
                    Email = us.Email,
                    Birthday = us.Birthday,
                    status = us.status
                };
               if (us.img != null && us.img.ContentLength > 0)
                {
                    string path = Path.Combine("/Content/Images/", us.img.FileName);
                    string fullPath = HttpContext.Current.Server.MapPath("~" + path);
                    us.img.SaveAs(fullPath);
                    user.Avatar = path;
                }
                else
                {
                    user.Avatar = db.users.AsNoTracking().SingleOrDefault(x => x.id == us.id).Avatar;
                }
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Content(HttpStatusCode.OK, new
                {
                    Mess = "Thành công",
                    data = us,
                    status = 200
                });
            }
                return Content(HttpStatusCode.OK, new
                {
                    Mess = "Lỗi",
                    data = us,
                    status = 400
                });
            
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var _id = db.users.Find(id);
            db.users.Remove(_id);
            db.SaveChanges();
            return Content(HttpStatusCode.OK, new { 
                mess ="thanh cong",
                status = 200
            });
        }

    }
}
