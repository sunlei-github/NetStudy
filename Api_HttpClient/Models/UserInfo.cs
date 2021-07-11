using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_HttpClient.Models
{
    public class UserInfo
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public DateTime CreateTime { set; get; }
    }
}