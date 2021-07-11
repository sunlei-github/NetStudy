using Api_HttpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Api_HttpClient.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:13595/api/webapi/");

            //get
            var getResponse1 = await httpClient.GetAsync("get");
            if (getResponse1.IsSuccessStatusCode)
            {
                var result = await getResponse1.Content.ReadAsAsync<List<UserInfo>>();
            }

            //delete
            var deleteResponse = await httpClient.DeleteAsync("delete?id=10");
            if (deleteResponse.IsSuccessStatusCode)
            {
                var result = await deleteResponse.Content.ReadAsAsync<int>();
            }

            UserInfo userInfo = new UserInfo()
            {
                Id = 5,
                CreateTime = DateTime.Now,
                Name = "Tom"
            };
            //post
            var postContent= new StringContent(JsonConvert.SerializeObject(userInfo));
            //这个必须写 表名调用的api应该以json的格式解析数据
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); 
            var postResponse = await httpClient.PostAsync("create", postContent);
            if (postResponse.IsSuccessStatusCode)
            {
                var result = await postResponse.Content.ReadAsAsync<UserInfo>();
            }

            //put
            var putContent = new StringContent(JsonConvert.SerializeObject(userInfo));
            //这个必须写 表名调用的api应该以json的格式解析数据
            putContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var putResponse = await httpClient.PutAsync("update", putContent);
            if (putResponse.IsSuccessStatusCode)
            {
                var result = await putResponse.Content.ReadAsAsync<UserInfo>();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}