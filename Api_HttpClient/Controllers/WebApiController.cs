using Api_HttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Api_HttpClient.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpGet]
        public JsonResult<List<UserInfo>> Get()
        {
            List<UserInfo> data = new List<UserInfo>();
            for (int i = 0; i < 100; i++)
            {
                data.Add(new UserInfo
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    CreateTime = DateTime.Now.AddHours(i)
                });
            }
            return Json(data);
        }

        [HttpPost]
        public JsonResult<UserInfo> Create(UserInfo userInfo)
        {
            userInfo.Name = "Create";

            return Json(userInfo);
        }

        [HttpPut]
        public JsonResult<UserInfo> Update(UserInfo userInfo)
        {
            userInfo.Name = "Update";

            return Json(userInfo);
        }

        [HttpDelete]
        public JsonResult<int> Delete(int  id)
        {
            return Json(id-=100);
        }
    }
}
