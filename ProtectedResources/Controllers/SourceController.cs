using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProtectedResources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtectedResources.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]  //保护资源
    public class SourceController : ControllerBase
    {

        [HttpGet]
        public JsonResult GetBooks()
        {
            return new JsonResult(InitBooks());
        }

        [HttpGet]
        public JsonResult GetBook()
        {
            return new JsonResult(new Book() { Id = 1, Name = "十万个为什么" });
        }

        private List<Book> InitBooks()
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < 10; i++)
            {
                books.Add(new Book() { Id = i, Name = Guid.NewGuid().ToString() });
            }

            return books;
        }
    }
}
