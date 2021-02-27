using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Common_Microservice.HttpClientConsul.Dto
{
    public class ConsulClientOptionBase
    {
        public string UriAdress { set; get; }

        public string ServiceGroupName { set; get; }
    }

    public class GetConsulClientOption : ConsulClientOptionBase
    {
    }

    public class DeleteConsulClientOption : ConsulClientOptionBase
    {

    }

    public class PostConsulClientOption : ConsulClientOptionBase
    {
        public HttpResponseMessage HttpResponseMessage { set; get; }

    }

    public class PutConsulClientOption : ConsulClientOptionBase
    {
        public HttpResponseMessage HttpResponseMessage { set; get; }

    }
}
