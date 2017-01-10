using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestClass;
using System.Data;
using Dao;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        public static int num = 1;
        // GET: Test
        public ActionResult Index()
        {
            Demo demo = new Demo();
            string username=User.Identity.Name;
            demo.djg();
            //Server.Transfer("~/Static/HP.html");
            //Response.Redirect("http://www.jianshu.com/p/9150ec3d1512");

            Test test = new TestClass.Test();
            int num1 =1;
            float num2;
            var result1 = test.meth(ref num1);//ref 使用的变量必须赋初始值
            var result2 = test.meth(out num2);//out 使用的变量可以不赋初始值
            Helper helper = new Helper();
            return View();
            
        }

        public JsonResult UpLoadImg()
        {
            HttpFileCollectionBase files = Request.Files;            
            if (files != null)
            {
                var file = files[0];
                if (file.ContentLength < 20971520) //20M
                {
                    string fileName = file.FileName;
                    string path = Server.MapPath("/Content/upload/") + fileName;
                    file.SaveAs(path);
                    return Json(new { code = 1, url = "/Content/upload/" + fileName,Id=num++ });
                }
            }
            return Json(new { code = -1 });
        }

        public JsonResult SaveImgs()
        {            
            var srcs = System.Web.HttpContext.Current.Request["srcs"];
            if (srcs != null)
            {
                string[] src = srcs.Split(new Char[] { ',' });
            }
            else
            {
                return Json(new { code = -1,msg="请上传图片" });
            }           

            return Json(new { code = 1, msg = "保存成功" });
        }

        public ActionResult City()
        {
            return View();
        }
    }
}