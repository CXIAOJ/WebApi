using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    public class ChangeController : ApiController
    {
        [HttpGet]
        public string GetAllData()
        {
            return "success";
        }

        [HttpPost]
        public string Test([FromBody] Users model)
        {
            System.Web.Mvc.JsonResult jsonresult = new System.Web.Mvc.JsonResult();
            jsonresult.Data = new { msg = model.Name };
            return jsonresult.Data.ToString();
        }
        public class Users
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
